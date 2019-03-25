using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using RtfCreator;

namespace SearchInXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            spliterXmlSource.Panel1Collapsed = true;
            spliterMain.SplitterDistance = 25;
            spliterEditor.Panel2Collapsed = true;
            rtfXpathHelp.Text = "";
            try
            {
                rtfXpathHelp.LoadFile("XpathHelp.rtf");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                rtfXpathHelp.ForeColor = Color.Red;
                rtfXpathHelp.Text = ex.Message;
            }
            MyAutoCompleteSource.Updated += new MyAutoCompleteSource.MyAutocompleteItemEventHandler(MyAutoCompleteSource_Updated);
            RtfCreator.RtfCreator.AddColor("Even", Color.FromArgb(235,235,235));
            //RtfCreator.RtfCreator.Equals("Odd", Color.Red);
        }

        void MyAutoCompleteSource_Updated(object sender, MyAutocompleteItemEventHandlerArg e)
        {
            txtXpath.AutoCompleteCustomSource = MyAutoCompleteSource.GetSource(e.GroupName);
        }

//        XmlDocument _XmlDocument = null;
        XPathDocument _XPathDoc = null;
        Dictionary<Point, string[]> _tblRezXpath = null;
        public XPathDocument XPathDoc
        {
            get { return _XPathDoc; }
            set
            {
                _XPathDoc = value;
                if (_XPathDoc == null) return;
                FillXpathHelperSourse();

                XPathNavigator nav = value.CreateNavigator();
                nav.MoveToFirstChild();
                /*XPathNodeIterator lst = nav.SelectChildren(XPathNodeType.Element);
                lst.MoveNext();*/
                //txtXpath.AutoCompleteCustomSource = MyAutoCompleteSource.GetSource(nav.Name); now using event Updated of MyAutoCompleteSource
                
/////
            }
        }

        static string _defaultNameSpacePrefix = "MyNameSpace";


        private void btnRun_Click(object sender, EventArgs e)
        {
            string xPath = txtXpath.Text;
            int curentCursorPosition = 0;
            StringBuilder sb = null;
            RtfCreator.RtfCreator rtfCreator = null;
            List<Point> lstOddsItems = new List<Point>();
            bool isOddItem = false;
            
            //XPathNavigator navigator = _XPathDoc.CreateNavigator();
            
            if (XPathDoc == null)
            {
                MessageBox.Show("Insert document or load it from file before", "No seted document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XPathNavigator navigator = XPathDoc.CreateNavigator();

            XPathExpression expr = null;
            navigator.MoveToFirstChild();
            XPathNodeIterator nList = null;

            
            try
            {
                expr = EvaluateXpathExpr(xPath, navigator);
                nList = navigator.Select(expr);
            }
            catch (XPathException ex)
            {
                MessageBox.Show(ex.Message, "Check your XPath",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }

            sb = new StringBuilder(nList.Count);
            _tblRezXpath = new Dictionary<Point, string[]>(nList.Count);
            while (nList.MoveNext())
            {
                List<string> lstPath = new List<string>();
                int xpi = 0;
                //sbPath.Append("/" + nList.Current.Name + (xpi < 0 ? "" : string.Format("[{0}]",xpi)));

                if (nList.Current.NodeType == XPathNodeType.Attribute)
                    lstPath.Add("@" + nList.Current.Name);
                else
                {
                    xpi = GetXpathIndex(nList.Current);
                    lstPath.Add(nList.Current.Name + (xpi < 0 ? "" : string.Format("[{0}]", xpi)));
                }
                XPathNavigator nParent = nList.Current.Clone();
                while (nParent.MoveToParent() && nParent.NodeType != XPathNodeType.Root)
                {
                    xpi = GetXpathIndex(nParent);
                    //sbPath.Insert(0, "/" + nParent.Name + (xpi < 0 ? "" : string.Format("[{0}]",xpi)));
                    lstPath.Add("" + nParent.Name + (xpi < 0 ? "" : string.Format("[{0}]", xpi)));
                }
                _tblRezXpath.Add(new Point(curentCursorPosition, curentCursorPosition + nList.Current.InnerXml.Length + 0), lstPath.ToArray());
                if (isOddItem)
                    lstOddsItems.Add(new Point(curentCursorPosition, nList.Current.InnerXml.Length));
                isOddItem = !isOddItem;
                curentCursorPosition += nList.Current.InnerXml.Length + 1;

                sb.AppendFormat("{0}\n", nList.Current.InnerXml);
                //sb.AppendFormat(RtfCreator.RtfCreator.
                

            }
            txtRezult.Clear();
            //txtRezult.Text = sb.ToString();
            rtfCreator = new RtfCreator.RtfCreator(sb.ToString());
            for (int i = 0; i < lstOddsItems.Count; i++)
                rtfCreator.MarkText(RtfCreator.RtfCreator.MarkType.BackGround, "Even", lstOddsItems[i].X, lstOddsItems[i].Y);

            txtRezult.Rtf = rtfCreator.Rtf;

            ////
            
            MyAutoCompleteSource.AddItemToCollection(navigator.Name, txtXpath.Text);
            //txtXpath.AutoCompleteCustomSource = MyAutoCompleteSource.GetSource(navigator.Name); now using event Updated of MyAutoCompleteSource
            ////
        }

        private void txtXpath_TextChanged(object sender, EventArgs e)
        {
            //errorProvider1.ContainerControl = txtXpath;

            try
            {
                errorProvider1.SetError(txtXpath, "");
                FillXpathHelperSourse();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtXpath, ex.Message);
            }

        }
        void FillXpathHelperSourse()
        {
            string xPathOriginal = txtXpath.Text;
            if (string.IsNullOrEmpty(xPathOriginal)) return;
            //string xml = txtXml.Text;
            string xPath = "";
            string[] newAutocompleteCollection = null;
            lstXpathHelperSourse.Items.Clear();
            //XPathExpression xpExpr = null;
            if (xPathOriginal[xPathOriginal.Length - 1] == '/')
            {
                //newAutocompleteCollection = GetXPathHelperList(_XPathDoc, xPathOriginal + "*");
                newAutocompleteCollection = GetXPathHelperList(XPathDoc, xPathOriginal + "*");
                if (newAutocompleteCollection != null) lstXpathHelperSourse.Items.AddRange(newAutocompleteCollection);
                //newAutocompleteCollection = GetXPathHelperList(_XPathDoc, xPathOriginal + "@*");
                newAutocompleteCollection = GetXPathHelperList(XPathDoc, xPathOriginal + "@*");
                if (newAutocompleteCollection != null)
                {
                    for (int i = 0; i < newAutocompleteCollection.Length; i++)
                        lstXpathHelperSourse.Items.Add("@" + newAutocompleteCollection[i]);
                }
            }
            else
            {

                //Match mtchLastSlaesh = Regex.Match(xPathOriginal, "^.*(/).*$"); //Last '/' char in expression
                //string xpathTmp = Regex.Replace(xPathOriginal, @"(\[.*?)/+(.*?\])", "$1~$2");
                //xpathTmp = Regex.Replace(xpathTmp, @"(\(.*?)/(.*?\))", "$1~$2");
                //\[(?:.*?(/)?)+\] all '\' between '[' and ']'
                Match mtchLastSlaesh = Regex.Match(xPathOriginal, @"^.*(/)[^\[\])].*$"); //Last '/' char in expression if no before "]" or ")"
                if (mtchLastSlaesh.Success && mtchLastSlaesh.Groups[1].Success)
                    xPath = xPathOriginal.Substring(0, mtchLastSlaesh.Groups[1].Index);

                //newAutocompleteCollection = GetXPathHelperList(_XPathDoc, xPath + "/*");
                newAutocompleteCollection = GetXPathHelperList(XPathDoc, xPath + "/*");
                if (newAutocompleteCollection != null) lstXpathHelperSourse.Items.AddRange(newAutocompleteCollection);
                //newAutocompleteCollection = GetXPathHelperList(_XPathDoc, xPath + "/@*");
                newAutocompleteCollection = GetXPathHelperList(XPathDoc, xPath + "/@*");
                if (newAutocompleteCollection != null)
                {
                    for (int i = 0; i < newAutocompleteCollection.Length; i++)
                        lstXpathHelperSourse.Items.Add("@" + newAutocompleteCollection[i]);
                }
            }
        }

        string[] GetXPathHelperList(XPathDocument doc, string xPath)
        {
            XPathNavigator firstChild = doc.CreateNavigator();
            firstChild.MoveToFirstChild();
            XPathExpression xpExpr = EvaluateXpathExpr(xPath, firstChild);
            XPathNodeIterator nList = null;
            List<string> lstRes = null;
            //XPathNavigator nav = doc.CreateNavigator(); now using firstChild
            string nodeName = string.Empty;
            //nList = nav.Select(xPath);
            nList = firstChild.Select(xpExpr);
            //nList = nav.Select(xpExpr);
            if (nList.Count == 0) return null;
            lstRes = new List<string>(nList.Count);
            while (nList.MoveNext())
            {
                nodeName = nList.Current.Name;
                if (!lstRes.Contains(nodeName)) lstRes.Add(nodeName);
            }
            return lstRes.ToArray();
        }
        //string[] GetXPathHelperList(XmlDocument xmlDoc, string xPath)
        //{
        //    //XmlDocument doc = new XmlDocument();
        //    XmlNodeList nList = null;
        //    List<string> lstRes = null;
        //    string nodeName = "";
        //    //xmlDoc.LoadXml(txtXml.Text);
        //    //string tmpXpath = xPath/*.Substring(0, xPath.Length - 1)*/ /*+ @"/"*/;
        //    //tmpXpath = xPath;
        //    nList = xmlDoc.SelectNodes(xPath);
        //    if (nList.Count == 0) return null;// throw new Exception();

        //    lstRes = new List<string>();
        //    for (int p = 0; p < nList.Count; p++)
        //    {
        //        nodeName = nList[p].Name;
        //        if (!lstRes.Contains(nodeName))
        //            lstRes.Add(nodeName);
        //    }
        //    return lstRes.ToArray();


        //}




        //private void button1_Click(object sender, EventArgs e)
        //{
        //    /*XmlDataDocument doc = new XmlDataDocument();
        //    doc.LoadXml(txtXml.Text);
        //    XmlNodeList nList = doc.SelectNodes(@"//*");*/
        //}

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int cursorPosition = txtXpath.SelectionStart;
            string xPath = txtXpath.Text;
            if (cursorPosition == xPath.Length || xPath.Length <= 1) cursorPosition = -1;
            Match mtchLastSlaesh = Regex.Match(xPath, "^.*(/).*$");
            //if (!mtchLastSlaesh.Success || !mtchLastSlaesh.Groups[1].Success) return;
            xPath = xPath.Substring(0, mtchLastSlaesh.Groups[1].Index) + "/" + lstXpathHelperSourse.SelectedItem;
            txtXpath.Text = xPath;
            if (cursorPosition < 0) cursorPosition = xPath.Length;
            txtXpath.Focus();
            txtXpath.SelectionStart = cursorPosition;
            txtXpath.SelectionLength = 0;
        }



        private void lblShowHideBuilder_Click(object sender, EventArgs e)
        {
            /*spliterEditor.Panel2Collapsed = !spliterEditor.Panel2Collapsed;
            if (spliterMain.SplitterDistance != spliterMain.Panel1MinSize)
                spliterMain.SplitterDistance = spliterMain.Panel1MinSize;
            else
                spliterMain.SplitterDistance = 121;*/
            spliterEditor.Panel2Collapsed = !spliterEditor.Panel2Collapsed;
            if (spliterEditor.Panel2Collapsed)
                spliterMain.SplitterDistance = spliterMain.Panel1MinSize;
            else
                spliterMain.SplitterDistance = 121;
            
        }




        /*private void XmlToTreeView(ref TreeView twCntrl, XmlDocument doc)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            twCntrl.Nodes.Clear();
            for (int i = 0; i < doc.ChildNodes.Count; i++)
                twCntrl.Nodes.Add(XmlNodeToTreeNode(doc.ChildNodes[i], -1));
        }*/
        private void XmlToTreeView(ref TreeView twCntrl, XPathDocument doc)
        {

            twCntrl.Nodes.Clear();
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator nList /*= nav.Select("/")*/;
            nList = nav.SelectChildren(XPathNodeType.All);
            while (nList.MoveNext())
                twCntrl.Nodes.Add(XmlNodeToTreeNode(nList.Current, -1));

        }

        TreeNode XmlNodeToTreeNode(XPathNavigator xn, int xPathIndex)
        {
            //XPathNodeIterator nList = xn.Select("/");
            //xn.SelectChildren(XPathNodeType.All);
            string xnValue = "";
            TreeNode tn = new TreeNode();
            NodeExtentionData ned = new NodeExtentionData();
            
            switch (xn.NodeType)
            {
                case XPathNodeType.All:
                    break;
                case XPathNodeType.Attribute:
                    ned = new NodeExtentionData(xn.Name, xn.Value, xn.NodeType);
                    tn.Tag = ned;
                    break;
                case XPathNodeType.Comment:
                    /*tn.Text = xn.OuterXml;
                    tn.ForeColor = Color.Gray;*/
                    ned = new NodeExtentionData("", xn.OuterXml, xn.NodeType);
                    tn.Tag = ned;
                    /*tn.Text = ned.ToString();
                    tn.ForeColor = ned.Color;*/
                    break;
                case XPathNodeType.Element:
                    //XPathNodeIterator nList = xn.SelectChildren(XPathNodeType.Text);
                    /*if (nList.MoveNext())
                        xnValue = nList.Current.Value;*/
                    XPathNodeIterator nList = null;
                    XPathNavigator nav = null;
                    /*nav = xn.Clone().CreateNavigator();
                    if (nav.MoveToFirstNamespace())
                        do
                        {
                            tn.Nodes.Add(XmlNodeToTreeNode(nav, -1));
                        } while (nav.MoveToNextNamespace());*/
                    
                    nav = xn.Clone().CreateNavigator();
                    if (nav.MoveToFirstAttribute())
                        do
                        {
                            //TreeNode tna = new TreeNode();
                            tn.Nodes.Add(XmlNodeToTreeNode(nav, -1));
                            /*tna.Text = nav.OuterXml;
                            tna.Tag = "@" + nav.Name;
                            tna.ForeColor = Color.MidnightBlue;*/
                            
                            //Moved to Case Attribute:
                            /*tn.Nodes.Add(tna);
                            ned = new NodeExtentionData(nav.Name, nav.Value, nav.NodeType);
                            tna.Tag = ned;
                            tna.Text = ned.ToString();
                            tna.ForeColor = ned.Color;*/

                        } while (nav.MoveToNextAttribute());
                    
                    nList = xn.SelectChildren(XPathNodeType.All);
                    while (nList.MoveNext())
                    {
                        if (nList.Current.NodeType == XPathNodeType.Text)
                            xnValue = nList.Current.Value;
                        else if (nList.Current.NodeType == XPathNodeType.Comment)
                            tn.Nodes.Add(XmlNodeToTreeNode(nList.Current, -1));
                        else
                        {
                            int xpi = GetXpathIndex(nList.Current);
                            tn.Nodes.Add(XmlNodeToTreeNode(nList.Current, xpi));
                        }
                    }
                    ned = new NodeExtentionData(xn.Name, xnValue, xPathIndex, xn.NodeType);
                    /*tn.ForeColor = Color.Brown;
                    tn.Text = xn.Name + " >> " + xnValue;
                    tn.Tag = xn.Name + (xPathIndex > 0 ? "[" + xPathIndex.ToString() + "]" : "");*/
                    /*tn.ForeColor = ned.Color;
                    tn.Text = ned.ToString();*/
                    tn.Tag = ned;
                    break;
                case XPathNodeType.Namespace:
                    ned = new NodeExtentionData(xn.Name, xn.Value, xn.NodeType);
                    tn.Tag = ned;
                    break;
                case XPathNodeType.ProcessingInstruction:
                    /*tn.Text = xn.OuterXml;
                    tn.ForeColor = Color.Gray;*/
                    ned = new NodeExtentionData("", xn.OuterXml, xn.NodeType);
                    /*tn.Text = ned.ToString();
                    tn.ForeColor = ned.Color;*/
                    tn.Tag = ned;
                    break;
                case XPathNodeType.Root:
                    break;
                case XPathNodeType.SignificantWhitespace:
                    break;
                case XPathNodeType.Text:
                    break;
                case XPathNodeType.Whitespace:
                    break;
                default:
                    break;
            }
            tn.Text = ned.ToString();
            tn.ForeColor = ned.Color;
            
            return tn;
        }

        

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            XPathDoc = null;
            try
            {
                XPathDoc = new XPathDocument(openFileDialog1.FileName);
                System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog1.FileName);
                txtFileInfo.Text = string.Format("Loaded file {0}\r\nsize {1:N0} byte", openFileDialog1.FileName, fi.Length);
                
            }
            catch (System.ArgumentException /*ex*/)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                    MessageBox.Show("Enter or select file before", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (!System.IO.File.Exists(openFileDialog1.FileName))
                        MessageBox.Show("No found file", "File not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Impossible processing file. Is it XML?", "File not opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message, "Error on open XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtXml_Validating(object sender, CancelEventArgs e)
        //private void txtXml_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtXml.Text == string.Empty) return;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    string encodingName;
                    Encoding enc = null;
                    byte[] ba = null;
                    encodingName = Regex.Match(txtXml.Text, @"\<\?xml\s+.*encoding\s*=\s*[\x22'](.+)[\x22'].*\?\>").Groups[1].Value;
                    if (string.IsNullOrEmpty(encodingName))
                        enc = Encoding.UTF8;
                    else
                        try
                        {
                            enc = Encoding.GetEncoding(encodingName);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message, "Error in encoding Xml", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                            //txtXml.Focus();
                            return;
                        }
                    ba = enc.GetBytes(txtXml.Text.ToCharArray());
                    ms.Write(ba, 0, ba.Length);

                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    //_XPathDoc = new XPathDocument(ms);
                    XPathDoc = new XPathDocument(ms);
                }
                //FillXpathHelperSourse();
            }
            catch (XmlException ex)
            {
                //txtXml.SelectedText = "DDDDDD";
                MessageBox.Show(ex.Message, "Error in Xml", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int errorPosition = 0;
                string[] rows = txtXml.Text.Split("\n".ToCharArray());

                for (int i = 0; i < ex.LineNumber - 1; i++)
                    errorPosition += rows[i].Length + 1;

                errorPosition += ex.LinePosition - 1;
                if (errorPosition < 0) errorPosition = 0;
                txtXml.SelectionStart = errorPosition;
                txtXml.SelectionLength = 1;
                txtXml.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //                throw;
            }

        }

        
        private void VisualizateInputXml()
        {
                //XmlToTreeView(ref twSourceXml, _XmlDocument);
                //XmlToTreeView(ref twSourceXml, _XPathDoc);
            XmlToTreeView(ref twSourceXml, XPathDoc);
            spliterXmlSource.Panel1Collapsed = false;
        }
        private void btnVisualizateXmlText_Click(object sender, EventArgs e)
        {
            //if (_XmlDocument == null)
            //if (_XPathDoc == null) 
            if (XPathDoc == null) 
            {
                MessageBox.Show("Insert a xml and try again.", "No xml loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VisualizateInputXml();
        }

        private void btnVisualizateXmlFile_Click(object sender, EventArgs e)
        {
            //if (_XmlDocument == null)
            //if (null== _XPathDoc)
            if (null == XPathDoc)
            {
                MessageBox.Show("Load xml before", "No file loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VisualizateInputXml();
        }
        private string GetXpathByNode(TreeNode treeNode)
        {
            StringBuilder sbXpath = new StringBuilder();
            NodeExtentionData nde = new NodeExtentionData();
            TreeNode n = treeNode;
            if (n.Tag is NodeExtentionData == false) return string.Empty;
            do
            {
                nde = (NodeExtentionData)n.Tag;
                if (string.IsNullOrEmpty(nde.XPathPart))
                    return string.Empty;
                sbXpath.Insert(0, "/" + nde.XPathPart);
                n = n.Parent;
            } while (n != null);
            return sbXpath.ToString();
        }
        private void twSourceXml_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*StringBuilder sbXpat = new StringBuilder();
            TreeNode n = e.Node;
            do
            {
                NodeExtentionData nde;
                if (n.Tag is NodeExtentionData )
                {
                    nde = (NodeExtentionData)n.Tag;
                    if (nde.XPathPart == string.Empty)
                    {
                        sbXpat = new StringBuilder();
                        break;
                    }
                    sbXpat.Insert(0, "/" + nde.XPathPart);
                }
                n = n.Parent;
            } while (n != null);
            txtXpathToNode.Text = sbXpat.ToString();*/
            txtXpathToNode.Text = GetXpathByNode(e.Node);

        }

        /*int GetXpathIndex(XmlNode n)
        {
            if (n.NodeType != XmlNodeType.Element) return 0;
            string nodeName = n.Name;
            int i = 0;

            System.Xml.XPath.XPathNavigator navigator = n.CreateNavigator();
            XmlNamespaceManager mngr = new XmlNamespaceManager(navigator.NameTable);
            mngr.AddNamespace("nodeName", n.NamespaceURI);

            //navigator = _XmlDocument.CreateNavigator();
            //mngr = new XmlNamespaceManager(navigator.NameTable);

            XmlNodeList siblingsNamesakeList = n.ParentNode.SelectNodes(String.Format("nodeName:{0}", nodeName), mngr);
            //XmlNodeList siblingsNamesakeList = n.ParentNode.SelectNodes("nodeName", mngr);

            if (siblingsNamesakeList.Count == 1) return -1;
            for (i = 0; i < siblingsNamesakeList.Count; i++)
                if (n.GetHashCode() == siblingsNamesakeList[i].GetHashCode()) return i + 1;
            throw new Exception("Node no present");
        }*/
        int GetXpathIndex(XPathNavigator n)
        {
            XPathNavigator parent = n.Clone();
            parent.MoveToParent();

            XPathNodeIterator siblingsNamesake = null;

            XmlNamespaceManager mngr = new XmlNamespaceManager(n.NameTable);// (new NameTable());
            mngr = new XmlNamespaceManager(parent.NameTable);

            IDictionary<string, string> nsCollection = parent.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);
            nsCollection = n.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);
            foreach (KeyValuePair<string, string> item in nsCollection)
                if (string.IsNullOrEmpty(item.Key))
                    mngr.AddNamespace(_defaultNameSpacePrefix, item.Value);
                else
                    mngr.AddNamespace(item.Key, item.Value);

            if (string.IsNullOrEmpty(n.Prefix) && mngr.HasNamespace(_defaultNameSpacePrefix))
                siblingsNamesake = parent.Select(_defaultNameSpacePrefix + ":" + n.Name, mngr);
            else
                siblingsNamesake = parent.Select(n.Name, mngr);
            //siblingsNamesake = parent.Select(_defaultNameSpacePrefix + ":" + n.Name, mngr);
            if (siblingsNamesake.Count == 1) return -1;

            int i = 1;

            while (siblingsNamesake.MoveNext() && !n.IsSamePosition(siblingsNamesake.Current))
                i++;

            return i;
        }

        XPathExpression EvaluateXpathExpr(string xpathNoDefaultNs, XPathNavigator parent)
        {
            XmlNamespaceManager mngr = new XmlNamespaceManager(parent.NameTable);// (new NameTable());
            string xpath = xpathNoDefaultNs;
            XPathExpression xpe = null;
            IDictionary<string, string> nsCollection = parent.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);

            foreach (KeyValuePair<string, string> item in nsCollection)
                if (string.IsNullOrEmpty(item.Key))
                {
                    //xpath = Regex.Replace(xpathNoDefaultNs, @"([\[/])([a-zA-Z]\w*(?=[^:]))", @"$1" + _defaultNameSpacePrefix + ":$2");
                    //xpath = Regex.Replace(xpath, @"([A-Za-z][\w:]*)", new MatchEvaluator(AddNameSpace));
                    //xpath = Regex.Replace(xpath, @"[\[\]/]([a-zA-Z][:\w]*)", new MatchEvaluator(AddNameSpace));
                    //xpath = Regex.Replace(xpath, @"(?:^|[\[\]/])([a-zA-Z][:\w]*)", new MatchEvaluator(AddNameSpace));
                    xpath = Regex.Replace(xpath, @"(?:^|[\[/])([a-zA-Z][:\w]*)", new MatchEvaluator(AddNameSpace));
                    
                    mngr.AddNamespace(_defaultNameSpacePrefix, item.Value);
                }
                else
                    mngr.AddNamespace(item.Key, item.Value);
            xpe = parent.Compile(xpath);
            xpe.SetContext(mngr);
            return xpe;
        }
        static string AddNameSpace(Match ElementName)
        {
            string elmNm = ElementName.ToString();
            //return ElementName.ToString();
            if (elmNm.IndexOf(':') < 0)
                elmNm = elmNm.Replace(ElementName.Groups[1].Value, _defaultNameSpacePrefix + ":" + ElementName.Groups[1].Value);
            return elmNm;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyAutoCompleteSource.Save();
        }
        #region menues items
        
        private void itmShowInTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tblRezXpath == null) return;
            //int nowSelectedPosition = txtRezult.SelectionStart;
            string[] fullNameInTree = null;
            TreeNodeCollection currentTreeNodeColl = null;
            foreach (KeyValuePair<Point, string[]> kvp in _tblRezXpath)
                if (kvp.Key.X <= txtRezult.SelectionStart && kvp.Key.Y >= txtRezult.SelectionStart)
                {
                    fullNameInTree = kvp.Value;
                    break;
                }
            if (fullNameInTree == null) return;
            //currentTreeNode = twSourceXml.Nodes[0];
            //currentTreeNode.Expand();
            currentTreeNodeColl = twSourceXml.Nodes;
            for (int part = fullNameInTree.Length - 1; part >= 0; part--)
                //{
                for (int n = 0; n < currentTreeNodeColl.Count; n++)
                    //{
                    //if ((string)(currentTreeNodeColl[n].Tag) == fullNameInTree[part])
                    if (((NodeExtentionData)currentTreeNodeColl[n].Tag).XPathPart == fullNameInTree[part])
                    {
                        currentTreeNodeColl[n].Expand();
                        twSourceXml.SelectedNode = currentTreeNodeColl[n];
                        currentTreeNodeColl = currentTreeNodeColl[n].Nodes;
                        break;
                    }
            //}
            //}
            twSourceXml.Focus();
        }
        private void itmCopyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject data = new DataObject();
            //data.SetText(txtRezult.Text, TextDataFormat.Text);
            data.SetText(txtRezult.Rtf, TextDataFormat.Rtf);
            data.SetText(txtRezult.Text.Replace("\n","\r\n"), TextDataFormat.UnicodeText);
            Clipboard.SetDataObject(data);
        }
        private void itmCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject data = new DataObject();
            data.SetText(txtRezult.SelectedText.Replace("\n","\r\n"), TextDataFormat.UnicodeText);
            data.SetText(txtRezult.SelectedRtf, TextDataFormat.Rtf);
            Clipboard.SetDataObject(data);
        }
        private void twSourceXml_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            TreeNode n = twSourceXml.GetNodeAt(e.X, e.Y);
            if (n == null) return;
            twSourceXml.SelectedNode = n;
        }
        private void mnuXmlTree_Opening(object sender, CancelEventArgs e)
        {
            object o = twSourceXml.SelectedNode.Tag;
            mnuXmlTree.Items["itmFindItToolStripMenuItem"].Enabled =
                o is NodeExtentionData && !string.IsNullOrEmpty(((NodeExtentionData)o).XPathPart);
                
        }
        private void itmCopyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodeExtentionData ned = (NodeExtentionData)twSourceXml.SelectedNode.Tag;
            Clipboard.SetDataObject(ned.NodeValue);
        }
        private void itmFindItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtXpath.Text = GetXpathByNode(twSourceXml.SelectedNode);
        }

        private void mnuTxtXml_Opening(object sender, CancelEventArgs e)
        {
            txtXml.Select();
            mnuTxtXml.Items["itnUundoToolStripMenuItem"].Enabled = txtXml.CanUndo;
            mnuTxtXml.Items["itnUundoToolStripMenuItem"].Text = "Undo " + txtXml.UndoActionName;
        }


        private void itnUundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //txtXml.UndoActionName
            txtXml.Undo();
            
        }

        private void itmCleareAndPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //txtXml.Clear();
            //txtXml.Text = "";
            txtXml.SelectAll();
            
            txtXml.Paste();
            return;
            //if (Clipboard.ContainsText(TextDataFormat.Rtf))
            //    txtXml.Rtf = Clipboard.GetText(TextDataFormat.Rtf);
            //else if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            //    txtXml.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
            //else if (Clipboard.ContainsText(TextDataFormat.Text))
            //    txtXml.Text = Clipboard.GetText(TextDataFormat.Text);
            //else
            //    MessageBox.Show("No present text in clipboard", "Error paste", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        
#endregion

        

        
        
       

        

 /*       private void txtXml_Validating(object sender, CancelEventArgs e)
        {

        }*/

        

    }
}