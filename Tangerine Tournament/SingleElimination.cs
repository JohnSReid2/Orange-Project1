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
                            Team team1 = getter.GetTeam(team1ID);
                            Team team2 = getter.GetTeam(team2ID);
                            Team winner = reader.IsDBNull(3) ? null : reader.GetInt32(3) == team1ID ? team1 : team2;
                            Match match = new Match(team1, team2) { Winner = winner };
                            matches.Add(match);
                        }
                    }
                }
            }

            return matches;
        }

        public void UpdateMatchWinner(int matchId, int winnerTeamId)
        {
            string connectionString = $"Data Source={Name}.db";

            try
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = $"UPDATE Matches SET Winner = {winnerTeamId} WHERE MatchID = {matchId}";

                    using (SqliteCommand command = new SqliteCommand(updateQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
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


        private void StoreMatches(List<Match> matches)
        {

            string connectionString = $"Data Source={Name}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (Match match in matches)
                        {
                            string insertMatchQuery = "INSERT INTO Matches (Team1ID, Team2ID, WinnerID) VALUES (@team1ID, @team2ID, @winnerID)";
                            using (SqliteCommand command = new SqliteCommand(insertMatchQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@team1ID", match.Team1.TeamID);
                                command.Parameters.AddWithValue("@team2ID", match.Team2.TeamID);
                                if (match.Winner != null)
                                {
                                    command.Parameters.AddWithValue("@winnerID", match.Winner.TeamID);
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@winnerID", DBNull.Value);
                                }
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
