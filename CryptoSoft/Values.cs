using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
    class Values
    {
        public class ExtList
        {
            public string Ext
            {
                get; set;
            }
        }
        public List<ExtList> ExtListDo(string ExtLinesFile)
        {
            var nonEmptyLines = File.ReadAllLines(ExtLinesFile)
                        .Where(x => !x.Split(';')
                                     .Take(2)
                                     .Any(cell => string.IsNullOrWhiteSpace(cell))
                         ).ToList();

            File.WriteAllLines(ExtLinesFile, nonEmptyLines);
            var query = from l in File.ReadLines(ExtLinesFile)
                        let data = l.Split(';')
                        select new ExtList
                        {
                            Ext = data[0],
                        };
            return query.ToList();
        }
    }
}
