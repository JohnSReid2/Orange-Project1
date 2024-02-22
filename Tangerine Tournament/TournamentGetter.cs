using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    internal class TournamentGetter
    {
        private string connectionString;

        public TournamentGetter(string tournamentName)
        {
            connectionString = $"Data Source={tournamentName}.db";
        }

        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Players";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            string gamertag = reader.GetString(3);
                            int timezone = reader.GetInt32(4);
                            string email = reader.GetString(5);
                            Player player = new Player(id, firstName, lastName, timezone, gamertag, email);
                            players.Add(player);
                        }
                    }
                }
            }
            return players;
        }

        public List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
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
                            Team team = new Team(teamID, teamName, null); // Team captain will be populated later
                            teams.Add(team);
                        }
                    }
                }
            }
            // Populate team captains
            PopulateTeamCaptains(teams);
            return teams;
        }

        private void PopulateTeamCaptains(List<Team> teams)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                foreach (var team in teams)
                {
                    string query = $"SELECT * FROM Players WHERE PlayerID = {team.TeamCaptain.Id}";
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string gamertag = reader.GetString(3);
                                int timezone = reader.GetInt32(4);
                                string email = reader.GetString(5);
                                Player teamCaptain = new Player(id, firstName, lastName, timezone, gamertag, email);
                                team.TeamCaptain = teamCaptain;
                            }
                        }
                    }
                }
            }
        }

        public Player GetPlayer(int playerId)
        {
            Player player = null;
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Players WHERE PlayerID = {playerId}";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            string gamertag = reader.GetString(3);
                            int timezone = reader.GetInt32(4);
                            string email = reader.GetString(5);
                            player = new Player(playerId, firstName, lastName, timezone, gamertag, email);
                        }
                    }
                }
            }
            return player;
        }

        public Team GetTeam(int teamId)
        {
            Team team = null;
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Teams WHERE TeamID = {teamId}";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string teamName = reader.GetString(1);
                            int teamCaptainID = reader.GetInt32(2);
                            team = new Team(teamId, teamName, null); // Team captain will be populated later
                        }
                    }
                }
                if (team != null)
                {
                    // Populate team captain
                    PopulateTeamCaptain(team);
                }
            }
            return team;
        }

        private void PopulateTeamCaptain(Team team)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Players WHERE PlayerID = {team.TeamCaptain.Id}";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            string gamertag = reader.GetString(3);
                            int timezone = reader.GetInt32(4);
                            string email = reader.GetString(5);
                            Player teamCaptain = new Player(id, firstName, lastName, timezone, gamertag, email);
                            team.TeamCaptain = teamCaptain;
                        }
                    }
                }
            }
        }
    }
}
