using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class SingleElimination
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public bool IsTeams { get; set; }
        public Team[] Teams { get; set; }
        public Player[] Players { get; set; }

        public SingleElimination(string name, string date, string type)
        {
            Name = name;
            Date = date;
            Type = type;

        }


        public void GenerateMatches()
        {

            try
            {
                // Retrieve team information
                List<Team> teams = new List<Team>();

                string connectionString = $"Data Source={Name}.db";
                TournamentBuilder builder = new TournamentBuilder();
                TournamentGetter getter = new TournamentGetter(Name);

                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Teams";
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int teamID = reader.GetInt32(0);
                                string teamName = reader.GetString(1);
                                int teamCaptainID = reader.GetInt32(2);
                                // Assuming TeamCaptainID is the PlayerID of the team captain
                                Player teamCaptain = getter.GetPlayer(teamCaptainID);
                                Team team = new Team(teamID, teamName, teamCaptain);
                                teams.Add(team);
                            }
                        }
                    }
                }

                // Shuffle teams to randomize matches
                Shuffle(teams);

                // Generate matches
                List<Match> matches = new List<Match>();
                for (int i = 0; i < teams.Count; i += 2)
                {
                    Team team1 = teams[i];
                    Team team2 = i + 1 < teams.Count ? teams[i + 1] : null; // Handle odd number of teams
                    Match match = new Match(team1, team2);
                    matches.Add(match);
                }

                // Store matches in the database
                //toreMatches(matches);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenerateNextRound()
        {
            try
            {
                List<Match> previousRoundMatches = GetCompletedMatches();
                List<Team> winners = new List<Team>();

                // Determine winners of previous round matches
                foreach (Match match in previousRoundMatches)
                {
                    if (match.Winner != null)
                    {
                        winners.Add(match.Winner);
                    }
                    else
                    {
                        // Handle cases where winner is not determined yet
                        MessageBox.Show($"Winner of match between {match.Team1.TeamName} and {match.Team2.TeamName} is not determined.", "Incomplete Match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Generate matches for the next round
                List<Match> nextRoundMatches = new List<Match>();
                for (int i = 0; i < winners.Count; i += 2)
                {
                    Team team1 = winners[i];
                    Team team2 = i + 1 < winners.Count ? winners[i + 1] : null; // Handle odd number of winners
                    Match match = new Match(team1, team2);
                    nextRoundMatches.Add(match);
                }

                // Store next round matches in the database
                StoreMatches(nextRoundMatches);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Match> GetCompletedMatches()
        {
            List<Match> matches = new List<Match>();

            string connectionString = $"Data Source={Name}.db";
            TournamentBuilder builder = new TournamentBuilder();
            TournamentGetter getter = new TournamentGetter(Name);

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Matches WHERE Winner IS NOT NULL";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int team1ID = reader.GetInt32(1);
                            int team2ID = reader.GetInt32(2);
                            // Assuming Team1ID and Team2ID are the foreign keys referencing Teams table
                            Team team1 = GetTeam(team1ID);
                            Team team2 = GetTeam(team2ID);
                            Team winner = reader.IsDBNull(3) ? null : reader.GetInt32(3) == team1ID ? team1 : team2;
                            Match match = new Match(team1, team2) { Winner = winner };
                            matches.Add(match);
                        }
                    }
                }
            }

            return matches;
        }


        private void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        private Team GetTeam(int teamId)
        {
            // Implement code to retrieve team information from the database
            // You can use the TournamentGetter class or directly execute SQL queries
            // Return a Team object based on the teamId
            throw new NotImplementedException();
        }

        private void StoreMatches(List<Match> matches)
        {
            // Implement code to store matches in the database
            // You need to define a schema for the Matches table and insert match information into it
            throw new NotImplementedException();
        }
    }
}
