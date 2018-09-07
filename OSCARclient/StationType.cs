using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMOOSCARClient
{
    public class StationType
    {
        [ExcelColumn("Station types")]
        public String MyType
        {
            get;
            set;
        }

        [ExcelColumn("Variables")]
        public String MyVariables
        {
            get;
            set;
        }


        public int[] StationVariables
        {
            get
            {
                List<int> ret = new List<int>();
                char[] commaSeparator = new char[] { ',' };

                var result = MyVariables.Split(commaSeparator);
                foreach (string r in result)
                {
                    ret.Add(int.Parse(r));
                }

                return ret.ToArray();
            } 
        }

    }
}
