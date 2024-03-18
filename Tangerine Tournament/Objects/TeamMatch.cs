using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Tournament.Objects;

namespace Tangerine_Tournament.Objects
{
    public class TeamMatch
    {
        public Team Team1 { get; }
        public Team Team2 { get; }
        public Team Winner { get; set; }
        public int stage {  get; set; }

        public TeamMatch(Team team1, Team team2)
        {
            Team1 = team1;
            Team2 = team2;
        }
    }
}