using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tangerine_Tournament.Objects;

namespace Tangerine_Tournament
{
    public class SingleElimination
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public bool MatchLocked { get; set; }
        public bool IsTeams { get; set; }
        public int Size {  get; set; }
        public Team[] Teams { get; set; }
        public Player[] Players { get; set; }

        public int Stages { get; set; }

        public int Stage { get; set; }

        private string connectionString;

        public SingleElimination(string name, string date, string type,bool matchLocked, bool isTeams, int size)
        {
            Name = name;
            Date = date;
            Type = type;
            IsTeams = isTeams;
            Size = size;
            Stages = (int)Math.Log2(8);
            connectionString = $"Data Source={Name}.db";
        }


        public void GenerateMatches()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(Stage) FROM Matches";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stage = reader.GetInt32(0);
                        }
                    }
                }
            }

            if (Stage != 0)
            {
                GenerateNextRound();
                return;
            }

            TournamentGetter getter = new TournamentGetter();
            
            if (IsTeams)
            {
                List<Team> teams = getter.GetTeams(connectionString);
                if (teams.Count != Size)
                {
                    MessageBox.Show("Unable to generate matches. Amount of teams not equal to the tournament size.");
                    return;
                }
                else
                {
                    // Group teams by timezone offset
                    var groupedTeams = teams.GroupBy(t => t.AverageTimezone).ToList();

                    // Shuffle teams within each timezone group
                    Random rnd = new Random();
                    List<TeamMatch> matches = new List<TeamMatch>();
                    foreach (var group in groupedTeams)
                    {
                        List<Team> shuffledTeams = group.OrderBy(t => rnd.Next()).ToList();
                        for (int i = 0; i < shuffledTeams.Count; i += 2)
                        {
                            matches.Add(new TeamMatch(shuffledTeams[i], shuffledTeams[i + 1]));
                        }
                        foreach (TeamMatch match in matches)
                        {
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, Stage) VALUES ({match.Team1.TeamID}, {match.Team2.TeamID}, 1)";
                                using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                                connection.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                List<Player> players = getter.GetPlayers(connectionString);
                if (players.Count != Size)
                {
                    MessageBox.Show("Unable to generate matches. Amount of players not equal to the tournament size.");
                    return;
                }
                else
                {
                    // Group teams by timezone offset
                    var groupedPlayers = players.GroupBy(t => t.Timezone).ToList();

                    // Shuffle teams within each timezone group
                    Random rnd = new Random();
                    List<PlayerMatch> matches = new List<PlayerMatch>();
                    foreach (var group in groupedPlayers)
                    {
                        List<Player> shuffledPlayers = group.OrderBy(t => rnd.Next()).ToList();
                        for (int i = 0; i < shuffledPlayers.Count; i += 2)
                        {
                            matches.Add(new PlayerMatch(shuffledPlayers[i], shuffledPlayers[i + 1]));
                        }
                        foreach (PlayerMatch match in matches)
                        {
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                connection.Open();
                                string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, stage) VALUES ({match.Player1.Id}, {match.Player2.Id}, 1)";
                                using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                                connection.Close();
                            }
                        }
                    }
                }
            }
            
        }
        public void GenerateNextRound()
        {
            TournamentGetter getter = new TournamentGetter();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(Stage) FROM Matches";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stage = reader.GetInt32(0) + 1;
                        }
                    }
                }
            }

            if (IsTeams)
            {
                List<Team> teams = new List<Team>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT Winner FROM Matches WHERE Stage = {Stage - 1}";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                teams.Add(getter.GetTeam(reader.GetInt32(0), connectionString));
                            }
                        }
                    }
                }

                // Group teams by timezone offset
                var groupedTeams = teams.GroupBy(t => t.AverageTimezone).ToList();

                // Shuffle teams within each timezone group
                Random rnd = new Random();
                List<TeamMatch> matches = new List<TeamMatch>();
                foreach (var group in groupedTeams)
                {
                    List<Team> shuffledTeams = group.OrderBy(t => rnd.Next()).ToList();
                    for (int i = 0; i < shuffledTeams.Count; i += 2)
                    {
                        matches.Add(new TeamMatch(shuffledTeams[i], shuffledTeams[i + 1]));
                    }
                    foreach (TeamMatch match in matches)
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, Stage) VALUES ({match.Team1.TeamID}, {match.Team2.TeamID}, 1)";
                            using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                List<Player> players = new List<Player>();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT Winner FROM Matches WHERE Stage = {Stage - 1}";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                players.Add(getter.GetPlayer(reader.GetInt32(0), connectionString));
                            }
                        }
                    }
                }


                // Group teams by timezone offset
                var groupedPlayers = players.GroupBy(t => t.Timezone).ToList();

                // Shuffle teams within each timezone group
                Random rnd = new Random();
                List<PlayerMatch> matches = new List<PlayerMatch>();
                foreach (var group in groupedPlayers)
                {
                    List<Player> shuffledPlayers = group.OrderBy(t => rnd.Next()).ToList();
                    for (int i = 0; i < shuffledPlayers.Count; i += 2)
                    {
                        matches.Add(new PlayerMatch(shuffledPlayers[i], shuffledPlayers[i + 1]));
                    }
                    foreach (PlayerMatch match in matches)
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, stage) VALUES ({match.Player1.Id}, {match.Player2.Id}, 1)";
                            using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}
