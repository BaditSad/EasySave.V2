using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
    class List
    {
        public class ExtList
        {
            public string Ext
            {
                get; set;
            }
        }
        public List<ExtList> ExtListDo()
        {
            var nonEmptyLines = File.ReadAllLines(Values.Instance.ExtValues)
                        .Where(x => !x.Split(';')
                                     .Take(2)
                                     .Any(cell => string.IsNullOrWhiteSpace(cell))
                         ).ToList();

            File.WriteAllLines(Values.Instance.ExtValues, nonEmptyLines);
            var query = from l in File.ReadLines(Values.Instance.ExtValues)
                        let data = l.Split(';')
                        select new ExtList
                        {
                            Ext = data[0],
                        };
            return query.ToList();
        }
    }
}
