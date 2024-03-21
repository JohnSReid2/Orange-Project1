using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Tournament.Objects;
using MySql;

using MySql.Data.MySqlClient;

namespace Tangerine_Tournament
{
    internal class TournamentGetter
    {

        public List<Player> GetPlayers(string connectionString)
        {
            List<Player> players = new List<Player>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Players";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
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

        public List<Team> GetTeams(string connectionString)
        {
            List<Team> teams = new List<Team>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Teams";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
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
            PopulateTeamCaptains(teams, connectionString);
            return teams;
        }

        private void PopulateTeamCaptains(List<Team> teams, string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                foreach (var team in teams)
                {
                    string query = $"SELECT * FROM Players WHERE PlayerID = {team.TeamCaptain.Id}";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
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

        public Player GetPlayer(int playerId, string connectionString)
        {
            Player player = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Players WHERE PlayerID = {playerId}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
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

        public Team GetTeam(int teamId, string connectionString)
        {
            Team team = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Teams WHERE TeamID = {teamId}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
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
                    PopulateTeamCaptain(team, connectionString);
                }
            }
            return team;
        }

        private void PopulateTeamCaptain(Team team, string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Players WHERE PlayerID = {team.TeamCaptain.Id}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
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

        public SingleElimination GetTournamentInfo(string connectionString)
        {
            SingleElimination tournamentInfo = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM TournamentInfo";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string date = reader.GetString(1);
                            string type = reader.GetString(2);
                            bool matchLocked = reader.GetBoolean(3);
                            bool isTeams = reader.GetBoolean(3);
                            int size = reader.GetInt32(4);
                            tournamentInfo = new SingleElimination(name, date, type, matchLocked, isTeams, size);
                        }
                    }
                }
            }
            return tournamentInfo;
        }
    }
}
