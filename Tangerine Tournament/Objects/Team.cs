using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament.Objects
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public Player TeamCaptain { get; set; }
        public List<Player> Players { get; set; }
        public double AverageTimezone { get; private set; }

        public Team(int teamID, string teamName, Player teamCaptain)
        {
            TeamID = teamID;
            TeamName = teamName;
            TeamCaptain = teamCaptain;
            Players = new List<Player>();
            CalculateAverageTimezone();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void CalculateAverageTimezone()
        {
            if (Players.Count == 0)
            {
                AverageTimezone = 0; // or any default value you prefer
                return;
            }

            double total = 0;
            foreach (var player in Players)
            {
                total += player.Timezone;
            }
            AverageTimezone = total / Players.Count;
        }
    }
}
