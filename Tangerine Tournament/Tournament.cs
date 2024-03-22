using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tangerine_Tournament.Objects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tangerine_Tournament
{
    public class Tournament
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public bool MatchLocked { get; set; }
        public bool IsTeams { get; set; }
        public int Size { get; set; }
        public Team[] Teams { get; set; }
        public Player[] Players { get; set; }

        public Tournament(string name, string date, string type, bool matchLocked, bool isTeams, int size)
        {
            Name = name;
            Date = date;
            Type = type;
            IsTeams = isTeams;
            Size = size;
        }
    }
}
