﻿using Microsoft.VisualBasic.Logging;
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
    public class SingleElimination : Tournament
    {
        public SingleElimination(string name, DateTime date, string type, bool matchLocked, bool isTeams, int size) : base(name, date, type, matchLocked, isTeams, size)
        {
            this.Name = name;
            this.Date = date;
            this.Type = type;
            this.MatchLocked = matchLocked;
            this.IsTeams = isTeams;
            this.Size = size;

        }

        public int Stages { get; set; }

        public int Stage { get; set; }

     

        public override void GenerateMatches(MySqlConnection connection)
        {
            using (connection)
            {
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
                GenerateNextRound(connection);
                return;
            }

            TournamentGetter getter = new TournamentGetter();
            
            if (IsTeams)
            {
                List<Team> teams = getter.GetTeams(connection);
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
                List<Player> players = getter.GetPlayers(connection);
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
                            string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, stage) VALUES ({match.Player1.Id}, {match.Player2.Id}, 1)";
                            using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            
        }
        public void GenerateNextRound(MySqlConnection connection)
        {
            TournamentGetter getter = new TournamentGetter();

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

            if (IsTeams)
            {
                List<Team> teams = new List<Team>();

                query = $"SELECT Winner FROM Matches WHERE Stage = {Stage - 1}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(getter.GetTeam(reader.GetInt32(0), connection));
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
                        string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, Stage) VALUES ({match.Team1.TeamID}, {match.Team2.TeamID}, 1)";
                        using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            else
            {
                List<Player> players = new List<Player>();
                query = $"SELECT Winner FROM Matches WHERE Stage = {Stage - 1}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            players.Add(getter.GetPlayer(reader.GetInt32(0), connection));
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
                        string editTableQuery = $"INSERT INTO Matches (Contestant1ID, Contestant2ID, stage) VALUES ({match.Player1.Id}, {match.Player2.Id}, 1)";
                        using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
