using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        // Constructor
        public Team(string teamName)
        {
            TeamName = teamName;
            Players = new List<Player>();
        }

        // Method to add a player to the team
        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        // Method to remove a player from the team
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        // Method to get the number of players in the team
        public int GetNumberOfPlayers()
        {
            return Players.Count;
        }

        // Method to display team information
        public override string ToString()
        {
            string playerList = "";
            foreach (var player in Players)
            {
                playerList += player.GetFullName() + ", ";
            }
            playerList = playerList.TrimEnd(',', ' ');

            return $"Team Name: {TeamName}\nPlayers: {playerList}";
        }
    }
}
