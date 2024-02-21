using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class SingleElimination
    {
        public List<Team> Teams { get; private set; }
        public List<Team> Winners { get; private set; }
        public List<Team> Losers { get; private set; }

        // Constructor
        public SingleElimination()
        {
            Teams = new List<Team>();
            Winners = new List<Team>();
            Losers = new List<Team>();
        }

        // Method to add a team to the tournament
        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        // Method to remove a team from the tournament
        public void RemoveTeam(Team team)
        {
            Teams.Remove(team);
        }

        // Method to start the tournament
        public void StartTournament()
        {
            if (Teams.Count < 2)
            {
                Console.WriteLine("Cannot start tournament. Insufficient number of teams.");
                return;
            }

            // Shuffle teams for random pairing
            ShuffleTeams();

            // Pair up teams for matches
            for (int i = 0; i < Teams.Count; i += 2)
            {
                PlayMatch(Teams[i], Teams[i + 1]);
            }

            // Display winners and losers
            Console.WriteLine("\nWinners Bracket:");
            DisplayBracket(Winners);

            Console.WriteLine("\nLosers Bracket:");
            DisplayBracket(Losers);
        }

        // Method to shuffle teams for random pairing
        private void ShuffleTeams()
        {
            Random rng = new Random();
            int n = Teams.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Team value = Teams[k];
                Teams[k] = Teams[n];
                Teams[n] = value;
            }
        }

        // Method to play a match between two teams
        private void PlayMatch(Team team1, Team team2)
        {
            Console.WriteLine($"Match: {team1.TeamName} vs {team2.TeamName}");
            // Simulate match here
            // For simplicity, let's just randomly select a winner
            Random rng = new Random();
            if (rng.Next(2) == 0)
            {
                Winners.Add(team1);
                Losers.Add(team2);
            }
            else
            {
                Winners.Add(team2);
                Losers.Add(team1);
            }
        }

        // Method to display the bracket
        private void DisplayBracket(List<Team> bracket)
        {
            for (int i = 0; i < bracket.Count; i++)
            {
                Console.WriteLine($"Round {i + 1}: {bracket[i].TeamName}");
            }
        }
    }
}
