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
    }
}
