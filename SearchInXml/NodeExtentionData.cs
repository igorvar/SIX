using System;
using System.Collections.Generic;
using System.Text;

namespace SearchInXml
{
    public struct NodeExtentionData
    {
        /*private NodeExtentionData()
        {
            this.NodeName = "";
            this.NodeValue = "";
            this.Counter = 0;
            this.NodeType = System.Xml.XPath.XPathNodeType.All;
        }*/
        public NodeExtentionData(string NodeName, string NodeValue, System.Xml.XPath.XPathNodeType NodeType):
            this (NodeName,NodeValue,-1, NodeType)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NodeName">Empty for nodes without name (comment, namespace...)</param>
        /// <param name="NodeValue"></param>
        /// <param name="Counter">For xpath. If less then 0 no showed in xpath</param>
        /// <param name="NodeType"></param>
        public NodeExtentionData(string NodeName, string NodeValue, int Counter, System.Xml.XPath.XPathNodeType NodeType)
        {
            this.NodeName = NodeName;
            this.NodeValue = NodeValue;
            this.Counter = Counter;
            this.NodeType = NodeType;

        }
        //public string Xpath { get; private set; }
        private System.Xml.XPath.XPathNodeType NodeType ;//{ get; set; }
        /// <summary>
        /// >= 0 - More then one instanse on this level
        /// </summary>
        private int Counter ;//{ get; set; }

        public string NodeName;// { get; private set; }
        public string NodeValue;// { get; private set; }


        public string XPathPart
        {

            get
            {
                if (NodeType == System.Xml.XPath.XPathNodeType.Attribute) return "@" + this.NodeName;
                if (NodeType == System.Xml.XPath.XPathNodeType.Element)
                    if (this.Counter < 0)
                        return "" + this.NodeName;
                    else
                        return string.Format(@"{0}[{1}]", this.NodeName, this.Counter);
                //throw new System.Xml.XPath.XPathException("Illegal node type: " + NodeType.ToString());
                return string.Empty;
            }
        }

        public override string ToString()
        {
            string res = "Not implemented for " + NodeType.ToString();
            switch (this.NodeType)
            {
                case System.Xml.XPath.XPathNodeType.All:
                    break;
                case System.Xml.XPath.XPathNodeType.Namespace:
                    if (string.IsNullOrEmpty(NodeName))
                        res = "xmlns = " + NodeValue;
                    else
                        res = string.Format("xmlns:{0} = {1}", NodeName, NodeValue);
                    break;
                case System.Xml.XPath.XPathNodeType.Attribute:
                    res = string.Format("{0} = {1}", NodeName, NodeValue);
                    break;
                case System.Xml.XPath.XPathNodeType.ProcessingInstruction:
                case System.Xml.XPath.XPathNodeType.Comment:
                    res = NodeValue;
                    break;
                case System.Xml.XPath.XPathNodeType.Element:
                    res = string.Format("{0} >> {1}", NodeName, NodeValue);
                    break;
                case System.Xml.XPath.XPathNodeType.Root:
                    break;
                case System.Xml.XPath.XPathNodeType.SignificantWhitespace:
                    break;
                case System.Xml.XPath.XPathNodeType.Text:
                    break;
                case System.Xml.XPath.XPathNodeType.Whitespace:
                    break;
                default:
                    break;
            }
            return res;
        }
        public System.Drawing.Color Color
        {
            get
            {
                System.Drawing.Color clr = System.Drawing.Color.Black;
                switch (NodeType)
                {
                    case System.Xml.XPath.XPathNodeType.All:
                        break;
                    case System.Xml.XPath.XPathNodeType.Attribute:
                        clr = System.Drawing.Color.MidnightBlue;
                        break;
                    case System.Xml.XPath.XPathNodeType.Comment:
                        clr = System.Drawing.Color.Gray;
                        break;
                    case System.Xml.XPath.XPathNodeType.Element:
                        clr = System.Drawing.Color.Brown;
                        break;
                    case System.Xml.XPath.XPathNodeType.Namespace:
                        clr = System.Drawing.Color.BlueViolet;
                        break;
                    case System.Xml.XPath.XPathNodeType.ProcessingInstruction:
                        clr = System.Drawing.Color.Gray;
                        break;
                    case System.Xml.XPath.XPathNodeType.Root:
                        break;
                    case System.Xml.XPath.XPathNodeType.SignificantWhitespace:
                        break;
                    case System.Xml.XPath.XPathNodeType.Text:
                        break;
                    case System.Xml.XPath.XPathNodeType.Whitespace:
                        break;
                    default:
                        break;
                }
                return clr;
            }
        }
    }
}
