using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public Player TeamCaptain { get; set; }
        public List<Player> Players { get; set; }

        public Team(int teamID, string teamName, Player teamCaptain)
        {
            TeamID = teamID;
            TeamName = teamName;
            TeamCaptain = teamCaptain;
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}
