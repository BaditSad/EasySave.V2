using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class ListSave
    {
        public class SaveLineDataGridView
        {
            public string Date
            {
                get; set;
            }
            public string Source
            {
                get; set;
            }
            public string Target
            {
                get; set;
            }
        }
        public List<SaveLineDataGridView> LoadDataGridView(string csvFile)
        {
            var nonEmptyLines = File.ReadAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv")
                        .Where(x => !x.Split(';')
                                     .Take(2)
                                     .Any(cell => string.IsNullOrWhiteSpace(cell))
                         ).ToList();

            File.WriteAllLines(Values.Instance.PathConfig + "\\Config\\Save.csv", nonEmptyLines);
            var query = from l in File.ReadLines(csvFile)
                        let data = l.Split(';')
                        select new SaveLineDataGridView
                        {
                            Source = data[0],
                            Target = data[1],
                            Date = data[2]
                        };
            return query.ToList();
        }
    }
}
