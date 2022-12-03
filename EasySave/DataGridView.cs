using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave
{
    internal class DataGridView
    {
        public DataTable jsonDataDiplay()
        {
            StreamReader sr = new StreamReader(Values.Instance.PathConfig + "\\Config\\Save.json");
            string json = sr.ReadToEnd();
            dynamic table = JsonConvert.DeserializeObject(json);
            DataTable newTable = new DataTable();
            newTable.Columns.Add("source", typeof(string));
            newTable.Columns.Add("target", typeof(string));
            newTable.Columns.Add("date", typeof(string));
            foreach (var row in table.value.data)
            {
                newTable.Rows.Add(row.source, row.target, row.date);
            }
            return newTable;
        }
        GridView.DataSource = newTable ;
        GridView.DataBind();
    }
}
