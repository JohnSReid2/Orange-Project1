using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class SingleElimination
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }

        public SingleElimination(string name, string date, string type)
        {
            Name = name;
            Date = date;
            Type = type;
        }
    }
}
