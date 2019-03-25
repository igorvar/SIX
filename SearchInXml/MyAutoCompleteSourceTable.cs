using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SearchInXml
{
    static class MyAutoCompleteSource
    {
        const string FILE_NAME = @"C:\Documents and Settings\igorva\My Documents\Visual Studio 2005\Projects\SearchInXml\SearchInXml\MyAutoCompleteSource.xml";
        static DataTable _SourceDataTable = new DataTable("Item");
        static MyAutoCompleteSource()
        {
            //_SourceDataTable = new 
            //_SourceDataTable.ReadXml(FILE_NAME);
            _SourceDataTable.Columns.Add("Name", typeof (string));
            _SourceDataTable.Columns.Add("Value", typeof(string));
            _SourceDataTable.Columns.Add("UsedTimesFromFile", typeof(int));
            _SourceDataTable.Columns.Add("UsedTimesSession", typeof(int));
            _SourceDataTable.Rows.Add("AAA", "xpath", 4, 5);
            _SourceDataTable.Rows.Add("BBB", "XP", 1, 1);
            _SourceDataTable.WriteXml(FILE_NAME);

        }
        public static AutoCompleteStringCollection GetSource(string name)
        {
            return null;
        }
        public static void Save()
        {
        }
        public static void AddItemToCollection(string Name, string Value)
        {
        }
    }
}
