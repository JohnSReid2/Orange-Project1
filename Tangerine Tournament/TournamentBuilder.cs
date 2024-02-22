using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    internal class TournamentBuilder
    {
        public void CreateTournament(string tournamentName, string tournamentType)
        {
            

            if (tournamentName != null && !File.Exists(tournamentName + ".db"))
            {

                string connectionString = $"Data Source={tournamentName}.db";

                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    try
                    {
                        string createTableQuery = "CREATE TABLE Players (PlayerID int PRIMARY KEY, FirstName varchar(255), LastName varchar(255), Gamertag varchar(255), Timezone int, Email varchar(255));";

                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        createTableQuery = $"CREATE TABLE Teams (TeamID int PRIMARY KEY,TeamName varchar(255), TeamCaptainID int, Timezone int, FOREIGN KEY (TeamCaptainID) REFERENCES Players(PlayerID));";
                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        createTableQuery = $"CREATE TABLE PlayerTeams (TeamID int, PlayerID int, PRIMARY KEY (TeamID, PlayerID), FOREIGN KEY (TeamID) REFERENCES Teams(TeamID), FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID));";
                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        createTableQuery = $"CREATE TABLE TournamentInfo (Name varchar(255), Date varchar(255), Type varchar(255), MatchLocked BIT DEFAULT 0);";
                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        if (tournamentType == "Single Elimination")
                        {
                            string editTableQuery = $"INSERT INTO TournamentInfo (Name, Date, Type) VALUES ('{tournamentName}', '{System.DateTime.Now.ToString()}', 'Single Elimination')";
                            using (SqliteCommand command = new SqliteCommand(editTableQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("DataBase is Created Su cessfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The tournament name entered is either invalid, or already exists. Please enter a valid tournament name.");
            }
        }

        public void AddPlayer (string tournamentName, Player player)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string editTableQuery = $"INSERT INTO Players (PlayerID, FirstName, LastName, Gamertag, Timezone, Email) VALUES ({player.Id}, '{player.FirstName}', '{player.LastName}', '{player.GamerTag}', '{player.Timezone}', '{player.EmailAddress}')";
                    using (SqliteCommand command = new SqliteCommand(editTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void AddTeam(string tournamentName, Team team)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string editTableQuery = $"INSERT INTO Teams (TeamID, TeamName, TeamCaptainID) VALUES ({team.TeamID}, '{team.TeamName}', {team.TeamCaptain.Id})";
                    using (SqliteCommand command = new SqliteCommand(editTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }


            }
        }

        public void AssignPlayers(string tournamentName, Team team)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    for (int i = 0; i < team.Players.Count; i++)
                    {
                        string editTableQuery = $"INSERT INTO PlayerTeams (PlayerID, TeamID) VALUES ({team.Players[i].Id}, {team.TeamID})";
                        using (SqliteCommand command = new SqliteCommand(editTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    // Calculate and update the team's average timezone
                    team.CalculateAverageTimezone();

                    string updateAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {team.AverageTimezone} WHERE TeamID = {team.TeamID}";
                    using (SqliteCommand command = new SqliteCommand(updateAverageTimezoneQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void AssignPlayer(string tournamentName, Team team, Player player)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string editTableQuery = $"INSERT INTO PlayerTeams (PlayerID, TeamID) VALUES ({player.Id}, {team.TeamID})";
                    using (SqliteCommand command = new SqliteCommand(editTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    team.CalculateAverageTimezone();

                    string updateAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {team.AverageTimezone} WHERE TeamID = {team.TeamID}";
                    using (SqliteCommand command = new SqliteCommand(updateAverageTimezoneQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void RemovePlayer(string tournamentName, Player player)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Remove the player from the PlayerTeams table first
                    string deletePlayerTeamsQuery = $"DELETE FROM PlayerTeams WHERE PlayerID = {player.Id}";
                    using (SqliteCommand command = new SqliteCommand(deletePlayerTeamsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Then remove the player from the Players table
                    string deletePlayerQuery = $"DELETE FROM Players WHERE PlayerID = {player.Id}";
                    using (SqliteCommand command = new SqliteCommand(deletePlayerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void RemoveTeam(string tournamentName, Team team)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Remove the team from the PlayerTeams table first
                    string deletePlayerTeamsQuery = $"DELETE FROM PlayerTeams WHERE TeamID = {team.TeamID}";
                    using (SqliteCommand command = new SqliteCommand(deletePlayerTeamsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Then remove the team from the Teams table
                    string deleteTeamQuery = $"DELETE FROM Teams WHERE TeamID = {team.TeamID}";
                    using (SqliteCommand command = new SqliteCommand(deleteTeamQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void UpdatePlayer(string tournamentName, Player player)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Construct the UPDATE query to update player information
                    string updatePlayerQuery = $"UPDATE Players SET FirstName = '{player.FirstName}', LastName = '{player.LastName}', Gamertag = '{player.GamerTag}', Timezone = {player.Timezone}, Email = '{player.EmailAddress}' WHERE PlayerID = {player.Id}";

                    // Execute the UPDATE query
                    using (SqliteCommand command = new SqliteCommand(updatePlayerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Check if the player is in a team
                    string checkPlayerTeamQuery = $"SELECT TeamID FROM PlayerTeams WHERE PlayerID = {player.Id}";
                    using (SqliteCommand command = new SqliteCommand(checkPlayerTeamQuery, connection))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int teamID = reader.GetInt32(0); // Assuming the first column is TeamID
                                                                 // Recalculate team's average timezone
                                RecalculateTeamAverageTimezone(connection, teamID);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        // Helper method to recalculate team's average timezone
        private void RecalculateTeamAverageTimezone(SqliteConnection connection, int teamID)
        {
            string calculateAverageTimezoneQuery = $"SELECT AVG(Timezone) FROM Players WHERE PlayerID IN (SELECT PlayerID FROM PlayerTeams WHERE TeamID = {teamID})";
            using (SqliteCommand command = new SqliteCommand(calculateAverageTimezoneQuery, connection))
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    double averageTimezone = Convert.ToDouble(result);
                    // Update the team's average timezone in the database
                    string updateTeamAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {averageTimezone} WHERE TeamID = {teamID}";
                    using (SqliteCommand updateCommand = new SqliteCommand(updateTeamAverageTimezoneQuery, connection))
                    {
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
