using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ReportImport
{
    public class ChangedItem
    {
        public Guid ItemId { get; private set; }
        public string ItemName { get; private set; }
        public string MatchedFilePath { get; private set; }
        public List<string> SourceDirectories { get; private set; }
        public List<string> FilesContainingItem { get; private set; }
        public XmlDocument Xml { get; private set; }

        private XmlNamespaceManager _xmlNS;
        private string _destinationFile;
        private string _changeFile;

        public ChangedItem()
        {
            FilesContainingItem = new List<string>();
        }

        public void LoadItemXml(string XmlPath)
        {
            _changeFile = XmlPath;

            string content;
            using (StreamReader reader = new StreamReader(XmlPath, Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content); // This errors  

            Xml = xmlDocument;
            _xmlNS = Program.CreateNsMgrForDocument(Xml);

            // Program.CreateNsMgrForDocument adds a default namespace that points to the default (xmlns) namespace
            string[] nodesToRemove = { 
                                         "/*/adc:State", 
                                         "/*/*/arr:anyType[@i:type='adc:ItemAssociations']/adc:AssociatedItemIds[not(node())]/parent::node()",
                                         "/*/*/arr:anyType[@i:type='ItemAssociations']/default:AssociatedItemIds[not(node())]/parent::node()",
                                         "/*/default:Links/default:Link/default:LinkMappings/default:LinkParameterMapping/default:MappingType",
                                         "/*/default:Links/default:Link/default:LinkMappings/default:LinkParameterMapping/default:TargetInfo",
                                         "/*/default:Links/default:Link/default:LinkMappings/default:LinkParameterMapping/default:TargetParameterTypeAlias"
                                     };

            foreach (var XPathToRemove in nodesToRemove)
            {
                var removeNodes = Xml.SelectNodes(XPathToRemove, _xmlNS);
                if (removeNodes == null || removeNodes.Count <= 0)
                    continue;

                foreach (XmlNode removeNode in removeNodes)
                {
                    if (removeNode.ParentNode != null)
                        removeNode.ParentNode.RemoveChild(removeNode);
                }
            }

            CollapseEmptyElements(Xml.DocumentElement);

            var selectSingleNode = xmlDocument.SelectSingleNode("/*/adc:ItemId", _xmlNS);
            if (selectSingleNode != null)
                ItemId = Guid.Parse(selectSingleNode.InnerText);
            else
                throw new Exception("Unable to extract ItemId from Xml");

            selectSingleNode = xmlDocument.SelectSingleNode("/*/adc:Name", _xmlNS);
            if (selectSingleNode != null)
                ItemName = selectSingleNode.InnerText;
            else
                throw new Exception("Unable to extract ItemName from Xml");
        }

        private IEnumerable<string> GetSolutionXmlFiles()
        {
            var results = new List<string>();
            foreach (var directory in SourceDirectories)
            {
                if (!Directory.Exists(directory))
                    continue;

                results.AddRange(Directory.GetFiles(directory, "*.xml"));
                if (Directory.Exists(Path.Combine(directory, "SmpImported")))
                {
                    results.AddRange(Directory.GetFiles(Path.Combine(directory, "SmpImported"), "*.xml"));
                }
            }

            return results;
        }

        private void SaveXml(XmlDocument xmlDocument, string xmlPath)
        {
            MergeProgress.Instance.LogMessage("Saving '{0}' to {1}", ItemName, TruncatePath(xmlPath));

            CollapseEmptyElements(xmlDocument.DocumentElement);
            xmlDocument.Save(xmlPath);
        }

        private static void CollapseEmptyElements(XmlElement node)
        {
            if (!node.IsEmpty && node.ChildNodes.Count == 0)
                node.IsEmpty = true;

            foreach (var child in node.ChildNodes.Cast<XmlNode>().Where(child => child.NodeType == XmlNodeType.Element))
                CollapseEmptyElements((XmlElement)child);
        }

        private static string TruncatePath(string FilePath)
        {
            var numberOfSlashes = FilePath.Count(c => c == '\\');
            if (numberOfSlashes > 3)
                numberOfSlashes -= 3;

            if (FilePath.Contains("\\SmpImported"))
                numberOfSlashes -= 1;

            var truncatedPath = FilePath;
            for (int i = 0, c = 0; i < FilePath.Length; i++)
            {
                if (FilePath[i] != '\\') 
                    continue;

                if (++c != numberOfSlashes) 
                    continue;

                i++; //move past 3rd last slash
                truncatedPath = FilePath.Substring(i);
                break;
            }

            return truncatedPath;
        }

        private static void WriteXmlForImport(string Directory, XmlNode Element)
        {
            var xmlPath = Path.Combine(Directory, "ImportMe.xml");
            var solutionXml = new XmlDocument();
            XmlNode root;

            if (!File.Exists(xmlPath))
            {
                var dec = solutionXml.CreateXmlDeclaration("1.0", "utf-8", null);
                solutionXml.AppendChild(dec);

                root = solutionXml.CreateElement("items");
                solutionXml.AppendChild(root);
            }
            else
            {
                solutionXml.Load(xmlPath);
                root = solutionXml.SelectSingleNode("/items");
            }

            if (Element != null && root != null && root.OwnerDocument != null)
                root.AppendChild(root.OwnerDocument.ImportNode(Element, true));

            solutionXml.Save(xmlPath);
        }

        private string GetDestinationFile()
        {
            // We did not find the ItemId in the source directory,
            // Check to see if its already been copied over 
            // to an Xml file in the destination directory
            if (!string.IsNullOrEmpty(MatchedFilePath))
            {
                // We found an Xml file containing our ItemId
                // Check to see if there is a known mapping to the destination file
                foreach (var kvp in Program.FileOverrides)
                {
                    if (MatchedFilePath.EndsWith(kvp.Key))
                        return MatchedFilePath.Replace(kvp.Key, kvp.Value);
                }

                if (MatchedFilePath.Contains("\\SmpImported\\") && File.Exists(MatchedFilePath.Replace("\\SmpImported", "")))
                    return MatchedFilePath.Replace("\\SmpImported", "");

                return MatchedFilePath;
            }

            // Couldnt automatically determine destination file
            // Prompt user
            foreach (var file in GetSolutionXmlFiles())
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(file);

                var namespaceManager = Program.CreateNsMgrForDocument(xmlDoc);

                var xmlNode =
                    xmlDoc.SelectSingleNode(
                        string.Format("/items/*/adc:ItemId[text()='{0}']", ItemId),
                        namespaceManager);

                if (xmlNode != null)
                    return file;
            }

            MergeProgress.Instance.LogMessage("Unable to find {0} ({1})", ItemName, ItemId);

            var targetFiles = GetSolutionXmlFiles().ToList();
            foreach (var file in GetSolutionXmlFiles())
            {
                if (!file.Contains("\\SmpImported")) 
                    continue;

                foreach (var kvp in Program.FileOverrides)
                {
                    // Not a match for our override list
                    if (!file.EndsWith(kvp.Key)) 
                        continue;

                    if (targetFiles.IndexOf(file) >= 0)
                        targetFiles.RemoveAt(targetFiles.IndexOf(file));

                    if (targetFiles.IndexOf(file.Replace(kvp.Key, kvp.Value)) >= 0)
                        targetFiles.RemoveAt(targetFiles.IndexOf(file.Replace(kvp.Key, kvp.Value)));
                }

                if (targetFiles.IndexOf(file) >= 0)
                    targetFiles.RemoveAt(targetFiles.IndexOf(file));

                if (targetFiles.IndexOf(file.Replace("\\SmpImported", "")) >= 0)
                    targetFiles.RemoveAt(targetFiles.IndexOf(file.Replace("\\SmpImported", "")));
            }

            using (var filePicker = new FilePicker(ItemName, ItemId, targetFiles))
                return filePicker.GetFile();
        }

        public bool PerformMerge(List<string> Directories, bool TestRun, bool CreateXml)
        {
            SourceDirectories = Directories;

            foreach (var xmlFile in GetSolutionXmlFiles())
            {
                var xmlDocToCheck = new XmlDocument();
                xmlDocToCheck.Load(xmlFile);

                var namespaceManager = Program.CreateNsMgrForDocument(xmlDocToCheck);
                var xmlNodeList = xmlDocToCheck.SelectNodes(string.Format("/items/*/adc:ItemId[text()='{0}']", ItemId), namespaceManager);

                if (xmlNodeList == null || xmlNodeList.Count == 0)
                    continue;

                if (xmlNodeList.Count > 1)
                {
                    MergeProgress.Instance.LogMessage("Multiple instances of {0} found in {1}", ItemId, Path.GetFileName(xmlFile));
                    MessageBox.Show(string.Format("Multiple instances of {0} found in {1}", ItemId,
                                                  Path.GetFileName(xmlFile)), "Duplicate instances",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                FilesContainingItem.Add(xmlFile);
            }

            if (FilesContainingItem.Count == 1)
            {
                MatchedFilePath = FilesContainingItem[0];
            }
            else if (FilesContainingItem.Count > 1)
            {
                MergeProgress.Instance.LogMessage("Multiple instances of {0} ({1}) found", ItemName, ItemId);

                for (var i = FilesContainingItem.Count - 1; i >= 0; i--)
                {
                    var path = FilesContainingItem[i];
                    MergeProgress.Instance.LogMessage(" - {0}", path);

                    foreach (var kvp in Program.FileOverrides)
                    {
                        if (path.EndsWith(kvp.Key))
                        {
                            path = path.Replace(kvp.Key, kvp.Value);
                            MergeProgress.Instance.LogMessage(" - {0} (override)", path);
                            FilesContainingItem.Add(path);
                        }
                    }

                    if (path.Contains("\\SmpImported\\") && File.Exists(path.Replace("\\SmpImported", "")))
                    {
                        path = path.Replace("\\SmpImported", "");
                        if (!FilesContainingItem.Contains(path))
                        {
                            MergeProgress.Instance.LogMessage(" - {0}", path);
                            FilesContainingItem.Add(path);
                        }
                    }
                }

                using (var filePicker = new FilePicker(ItemName, ItemId, FilesContainingItem))
                    MatchedFilePath = filePicker.GetFile();

                if (string.IsNullOrEmpty(MatchedFilePath))
                    return false;

                foreach (var path in FilesContainingItem)
                {
                    if (path != MatchedFilePath)
                    {
                        MergeProgress.Instance.LogMessage("Checking {0} for a duplicate of {1} ({2})", path, ItemName, ItemId);
                        if (!TestRun)
                            RemoveItemFromXml(path);
                    }
                }
            }

            _destinationFile = GetDestinationFile();

            if (string.IsNullOrEmpty(_destinationFile))
                return false;

            // Replace existing node if this item has already been converted
            if (_destinationFile == MatchedFilePath)
            {
                var xmlMatchedDoc = new XmlDocument();
                xmlMatchedDoc.Load(_destinationFile);

                var namespaceManager = Program.CreateNsMgrForDocument(xmlMatchedDoc);
                var matchedNode = xmlMatchedDoc.SelectSingleNode(string.Format("/items/*/adc:ItemId[text()='{0}']", ItemId), namespaceManager);

                var rootNode = xmlMatchedDoc.SelectSingleNode("/items");
                if (rootNode != null && rootNode.OwnerDocument != null && matchedNode != null && matchedNode.ParentNode != null && Xml.DocumentElement != null)
                {
                    if (CreateXml)
                        WriteXmlForImport(Path.GetDirectoryName(_changeFile), Xml.DocumentElement);

                    if (Xml.DocumentElement.OuterXml.Equals(matchedNode.ParentNode.OuterXml))
                    {
                        MergeProgress.Instance.LogMessage("No changes detected for '{0}' in {1}, skipping", ItemName, TruncatePath(_destinationFile));
                        return true;
                    }

                    if (TestRun)
                        using (var xmlViewer = new XmlViewer(this)) 
                            return DialogResult.OK == xmlViewer.ShowDialog();

                    rootNode.ReplaceChild(rootNode.OwnerDocument.ImportNode(Xml.DocumentElement, true),
                                            matchedNode.ParentNode);

                    SaveXml(xmlMatchedDoc, _destinationFile);
                    return true;
                }
            }

            // If changes have been detected then remove existing item
            if (!TestRun && !string.IsNullOrEmpty(MatchedFilePath))
                RemoveItemFromXml(MatchedFilePath);

            var xmlDestinationDoc = new XmlDocument();
            xmlDestinationDoc.Load(_destinationFile);

            var rootDestinationNode = xmlDestinationDoc.SelectSingleNode("/items");
            if (rootDestinationNode == null || rootDestinationNode.OwnerDocument == null || Xml.DocumentElement == null)
                return true;

            if (TestRun)
                using (var xmlViewer = new XmlViewer(this)) 
                    return DialogResult.OK == xmlViewer.ShowDialog();

            rootDestinationNode.AppendChild(rootDestinationNode.OwnerDocument.ImportNode(Xml.DocumentElement, true));
            
            SaveXml(xmlDestinationDoc, _destinationFile);
            if (CreateXml)
                WriteXmlForImport(Path.GetDirectoryName(_changeFile), Xml.DocumentElement);

            return true;
        }

        private void RemoveItemFromXml(string XmlPath)
        {
            var solutionXml = new XmlDocument();
            solutionXml.Load(XmlPath);

            var namespaceManager = Program.CreateNsMgrForDocument(solutionXml);
            var matchedNode = solutionXml.SelectSingleNode(string.Format("/items/*/adc:ItemId[text()='{0}']", ItemId), namespaceManager);

            if (matchedNode != null && matchedNode.ParentNode != null && matchedNode.ParentNode.ParentNode != null)
            {
                MergeProgress.Instance.LogMessage("Removing '{0}' from {1}", ItemName, TruncatePath(XmlPath));
                matchedNode.ParentNode.ParentNode.RemoveChild(matchedNode.ParentNode);
                SaveXml(solutionXml, XmlPath);
            }
        }
    }
}
