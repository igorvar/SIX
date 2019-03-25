using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SearchInXml
{
    /// <summary>
    /// Class for operations with autocomplete of textbox. Source for data in file MyAutoCompleteSource.xml. 
    /// In data sourse presents all rows it added by function AddItemToCollection(string GroupName, string ItemValue) and 
    /// all rows from tag Item with UsedTimes more of equal  attribute MinUsedTimes of root tag.
    /// 
    /// In constructor filling table _dctnryAllItems with next struct:
    /// Group Name - list of items.
    /// 
    /// Function AddItemToCollection(string GroupName, string ItemValue) add ItemValue in needed group or increment counter UsedTimes
    /// 
    /// Function GetSource(string Group) return object AutoCompleteStringCollection with items of group
    /// 
    /// Function Save() saving current table in xml.
    /// </summary>
    static class MyAutoCompleteSource
    {
        static Dictionary<string, Dictionary<string, int>> _dctnryAllItems = new Dictionary<string, Dictionary<string, int>>();
        static readonly string FILE_NAME;// = "MyAutoCompleteSource.xml";
        const string ELMNT_ROOT_NAME = "MyAutoCompleteSourcesList";
        const string ELMNT_GROUP_NAME = "Group";
        const string ATT_GROUP_NAME = "Name";
        const string ELMNT_ITEM_NAME = "Item";
        const string ATT_COUNTER_NAME = "UsedTimes";
        const string ATT_HASH_CODE_ITEM_NAME = "Code";

        #region Public functions

        static MyAutoCompleteSource()
        {
            //System.IO.FileInfo fi = new System.IO.FileInfo(FILE_NAME);
            //MessageBox.Show(fi.DirectoryName);

            XmlDocument doc = new XmlDocument();
            XmlAttribute attMinUsedTimes;
            string parentName;
            int MinUsedTimes = 0;
            FILE_NAME = Application.StartupPath +  @"\MyAutoCompleteSource.xml";
            if (System.IO.File.Exists(FILE_NAME))
                doc.Load(FILE_NAME);
            else
            {
                //doc.CreateElement(ELMNT_ROOT_NAME);
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", ""));
                XmlElement r = doc.CreateElement(ELMNT_ROOT_NAME);
                attMinUsedTimes = doc.CreateAttribute("MinUsedTimes");
                attMinUsedTimes.Value = "2";
                r.Attributes.Append(attMinUsedTimes);
                doc.AppendChild(r);
                doc.Save(FILE_NAME);
            }
            attMinUsedTimes = (XmlAttribute)doc.SelectSingleNode("/" + ELMNT_ROOT_NAME + "/@MinUsedTimes");

            if (attMinUsedTimes == null || !int.TryParse(attMinUsedTimes.Value, out MinUsedTimes)) MinUsedTimes = 2;

            XmlNodeList nList = doc.SelectNodes("/" + ELMNT_ROOT_NAME + "/" + ELMNT_GROUP_NAME + "/" + ELMNT_ITEM_NAME + "[@" + ATT_COUNTER_NAME + " >= '" + MinUsedTimes.ToString() + "']");
            for (int i = 0; i < nList.Count; i++)
            {
                parentName = nList[i].ParentNode.Attributes[ATT_GROUP_NAME].Value;
                AddItemToCollection(parentName, nList[i].InnerText, false);
            }
        }
        static public void AddItemToCollection(string GroupName, string ItemValue)
        {
            AddItemToCollection(GroupName, ItemValue, true);
        }

        static public AutoCompleteStringCollection GetSource(string Group)
        {
            AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
            if (_dctnryAllItems.ContainsKey(Group))
                foreach (KeyValuePair<string, int> item in _dctnryAllItems[Group])
                    lst.Add(item.Key);
            return lst;
        }
        static public void Save()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode ndRoot = null;
            XmlElement ndParent = null;
            XmlElement ndItm = null;
            XmlAttribute att = null;

            doc.Load(FILE_NAME);
            //ndRoot = doc.SelectSingleNode("/" + ELMNT_ROOT_NAME);
            ndRoot = doc.DocumentElement;
            
            foreach (KeyValuePair<string, Dictionary<string, int>> itemSet in _dctnryAllItems)
            {
                //ndParent = (XmlElement)ndRoot.SelectSingleNode(ELMNT_GROUP_NAME + "[@Name = '" + itemSet.Key + "']");
                ndParent = (XmlElement)ndRoot.SelectSingleNode(ELMNT_GROUP_NAME + "[@" + ATT_GROUP_NAME + " = '" + itemSet.Key + "']");
                if (ndParent == null)
                {
                    ndParent = doc.CreateElement(ELMNT_GROUP_NAME);
                    att = doc.CreateAttribute(ATT_GROUP_NAME);
                    att.Value = itemSet.Key;
                    ndParent.Attributes.Append(att);
                    ndRoot.AppendChild(ndParent);
                }
                foreach (KeyValuePair<string, /*AutocompleteItem*/ int> itemValue in itemSet.Value)
                {
                    ndItm = (XmlElement)ndParent.SelectSingleNode(ELMNT_ITEM_NAME + "[@" + ATT_HASH_CODE_ITEM_NAME + " = '" + itemValue.Key.GetHashCode().ToString() + "']");
                    ///MyAutoCompleteSourcesList/Group/Item[text()='a']/@UsedTimes
                    if (ndItm == null)
                    {
                        ndItm = doc.CreateElement(ELMNT_ITEM_NAME);

                        att = doc.CreateAttribute(ATT_COUNTER_NAME);
                        att.Value = "0";
                        ndItm.Attributes.Append(att);

                        att = doc.CreateAttribute(ATT_HASH_CODE_ITEM_NAME);
                        att.Value = itemValue.Key.GetHashCode().ToString();
                        ndItm.Attributes.Append(att);

                        ndParent.AppendChild(ndItm);
                    }
                    ndItm.Attributes[ATT_COUNTER_NAME].Value =
                        (
                            int.Parse(ndItm.Attributes[ATT_COUNTER_NAME].Value) + itemValue.Value
                        ).ToString();
                    ndItm.InnerText = itemValue.Key;
                }
            }
            doc.Save(FILE_NAME);
        }
#endregion
        static void AddItemToCollection(string GroupName, string ItemValue, bool UsedInCurrentSession)
        {
            Dictionary<string, int> listOfItems = new Dictionary<string, int>(); // list of Items
            if (!_dctnryAllItems.ContainsKey(GroupName))
                _dctnryAllItems.Add(GroupName, new Dictionary<string, int>());
            listOfItems = _dctnryAllItems[GroupName];

            if (listOfItems.ContainsKey(ItemValue))
                listOfItems[ItemValue]++;
            else
            {
                listOfItems.Add(ItemValue, (UsedInCurrentSession) ? 1 : 0);
                if (UsedInCurrentSession)
                    Updated(null, new MyAutocompleteItemEventHandlerArg(GroupName));
            }

            _dctnryAllItems[GroupName] = listOfItems;
        }
        public static event MyAutocompleteItemEventHandler Updated;
        public delegate void MyAutocompleteItemEventHandler(object sender, MyAutocompleteItemEventHandlerArg e);
    }
    class MyAutocompleteItemEventHandlerArg
    {
        public string GroupName { get; private set; }
        public MyAutocompleteItemEventHandlerArg(string GroupName )
        {
            this.GroupName = GroupName;
        }
    }
    //struct AutocompleteItem
    //{

    //    public AutocompleteItem(string name, bool UsedInCurrentSession):this()
    //    {
    //        Name = name;
    //        if (UsedInCurrentSession) SessionUsedTimes = 1;
    //        else SessionUsedTimes = 0;
    //    }
    //    private AutocompleteItem(string name, int UsedTimes):this()
    //    {
    //        Name = name;
    //        SessionUsedTimes = UsedTimes;
    //    }
    //    public string Name  { get; private set; }
    //    public int SessionUsedTimes { get; private set; }

    //    public AutocompleteItem IncrementUsing()
    //    {
    //        AutocompleteItem newItm = new AutocompleteItem(this.Name, this.SessionUsedTimes + 1);
    //        return newItm;
    //    }
    //    public override int GetHashCode()
    //    {
    //        //return base.GetHashCode();
    //        return Name.GetHashCode();
    //    }
    //}


    //class AutocompleteItemCounter
    //{
    //    private AutocompleteItemCounter()
    //    {

    //    }
    //    public AutocompleteItemCounter(int UsedFromFile)
    //    {
    //        this.UsedFile = UsedFromFile; 
    //    }
    //    public void AddUsing()
    //    {
    //        UsedSession++;
    //    }

    //    public int UsedFile { get; private set; }

    //    public int UsedSession
    //    {
    //        get;
    //        private set;
    //    }
    //}
}
