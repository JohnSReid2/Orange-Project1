using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Tournament.Objects;
using MySql;
using MySql.Data.MySqlClient;

namespace Tangerine_Tournament
{
    internal class TournamentBuilder
    {
        public void CreateTournament(MySqlConnection connection, string tournamentType, int size, string tournamentName, bool isTeams)
        {
            try
            {
                //Create and Use Database
                string createDatabaseQuery = $"CREATE DATABASE {tournamentName};";

                using (MySqlCommand command = new MySqlCommand(createDatabaseQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string useQuery = $"USE {tournamentName}";
                using (MySqlCommand command = new MySqlCommand(useQuery, connection))
                {
                    command.ExecuteNonQuery();
                }


                //Create Tables
                string createTableQuery = "CREATE TABLE Players (PlayerID int PRIMARY KEY, FirstName varchar(255), LastName varchar(255), Gamertag varchar(255), Timezone int, Email varchar(255));";

                using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                createTableQuery = $"CREATE TABLE Teams (TeamID int PRIMARY KEY,TeamName varchar(255), TeamCaptainID int, Timezone int, FOREIGN KEY (TeamCaptainID) REFERENCES Players(PlayerID));";
                using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                createTableQuery = $"CREATE TABLE PlayerTeams (TeamID int, PlayerID int, PRIMARY KEY (TeamID, PlayerID), FOREIGN KEY (TeamID) REFERENCES Teams(TeamID), FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID));";
                using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                createTableQuery = $"CREATE TABLE TournamentInfo (Name varchar(255), Date DATETIME, Type varchar(255), MatchLocked BIT DEFAULT 0, IsTeams BIT DEFAULT 0, Size int);";
                using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }


                //Populate Tables

                string editTableQuery = $"INSERT INTO TournamentInfo (Name, Date, Type, Size, IsTeams) VALUES ('{tournamentName}', '{System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}', '{tournamentType}', {size}, {isTeams});";
                using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string createTableQuery2 = $"CREATE TABLE Matches (MatchID int, Contestant1ID int, Contestant2ID int, WinnerID int, Stage int);";
                using (MySqlCommand command = new MySqlCommand(createTableQuery2, connection))
                {
                    command.ExecuteNonQuery();
                }


                if (tournamentType == "Single Elimination")
                {

                }
                else if (tournamentType == "Round Robin")
                {

                }
                MessageBox.Show("DataBase is Created Sucessfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AddPlayer (MySqlConnection connection, Player player)
        {
            try
            {
                string editTableQuery = $"INSERT INTO Players (PlayerID, FirstName, LastName, Gamertag, Timezone, Email) VALUES ({player.Id}, '{player.FirstName}', '{player.LastName}', '{player.GamerTag}', '{player.Timezone}', '{player.EmailAddress}')";
                using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
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

        public void AddTeam(MySqlConnection connection, Team team)
        {
            try
            {
                string editTableQuery = $"INSERT INTO Teams (TeamID, TeamName, TeamCaptainID) VALUES ({team.TeamID}, '{team.TeamName}', {team.TeamCaptain.Id})";
                using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        public void AssignPlayer(MySqlConnection connection, Team team, Player player)
        {
            try
            {
                string editTableQuery = $"INSERT INTO PlayerTeams (PlayerID, TeamID) VALUES ({player.Id}, {team.TeamID})";
                using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                team.CalculateAverageTimezone();

                string updateAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {team.AverageTimezone} WHERE TeamID = {team.TeamID}";
                using (MySqlCommand command = new MySqlCommand(updateAverageTimezoneQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void RemovePlayer(MySqlConnection connection, int playerID)
        {
            try
            {
                // Remove the player from the PlayerTeams table first
                string deletePlayerTeamsQuery = $"DELETE FROM PlayerTeams WHERE PlayerID = {playerID}";
                using (MySqlCommand command = new MySqlCommand(deletePlayerTeamsQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Then remove the player from the Players table
                string deletePlayerQuery = $"DELETE FROM Players WHERE PlayerID = {playerID}";
                using (MySqlCommand command = new MySqlCommand(deletePlayerQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void RemoveTeam(MySqlConnection connection, Team team)
        {
            try
            {
                // Remove the team from the PlayerTeams table first
                string deletePlayerTeamsQuery = $"DELETE FROM PlayerTeams WHERE TeamID = {team.TeamID}";
                using (MySqlCommand command = new MySqlCommand(deletePlayerTeamsQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Then remove the team from the Teams table
                string deleteTeamQuery = $"DELETE FROM Teams WHERE TeamID = {team.TeamID}";
                using (MySqlCommand command = new MySqlCommand(deleteTeamQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Function to remove a player from a team
        public void RemovePlayerFromTeam(MySqlConnection connection, Team team, Player player)
        {
            try
            {
                // Remove the player from the PlayerTeams table
                string deletePlayerTeamsQuery = $"DELETE FROM PlayerTeams WHERE PlayerID = {player.Id} AND TeamID = {team.TeamID}";
                using (MySqlCommand command = new MySqlCommand(deletePlayerTeamsQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Recalculate the team's average timezone
                team.CalculateAverageTimezone();

                string updateAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {team.AverageTimezone} WHERE TeamID = {team.TeamID}";
                using (MySqlCommand command = new MySqlCommand(updateAverageTimezoneQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdatePlayer(MySqlConnection connection, Player player)
        {
            try
            {
                // Construct the UPDATE query to update player information
                string updatePlayerQuery = $"UPDATE Players SET FirstName = '{player.FirstName}', LastName = '{player.LastName}', Gamertag = '{player.GamerTag}', Timezone = {player.Timezone}, Email = '{player.EmailAddress}' WHERE PlayerID = {player.Id}";

                // Execute the UPDATE query
                using (MySqlCommand command = new MySqlCommand(updatePlayerQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Check if the player is in a team
                string checkPlayerTeamQuery = $"SELECT TeamID FROM PlayerTeams WHERE PlayerID = {player.Id}";
                using (MySqlCommand command = new MySqlCommand(checkPlayerTeamQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
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
        }

        public void UpdateTeam(MySqlConnection connection, Team team)
        {
            try
            {
                // Construct the UPDATE query to update team information
                string updateTeamQuery = $"UPDATE Teams SET TeamName = '{team.TeamName}', TeamCaptainID = {team.TeamCaptain.Id} WHERE TeamID = {team.TeamID}";

                // Execute the UPDATE query
                using (MySqlCommand command = new MySqlCommand(updateTeamQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                // Recalculate team's average timezone
                RecalculateTeamAverageTimezone(connection, team.TeamID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Helper method to recalculate team's average timezone
        private void RecalculateTeamAverageTimezone(MySqlConnection connection, int teamID)
        {
            string calculateAverageTimezoneQuery = $"SELECT AVG(Timezone) FROM Players WHERE PlayerID IN (SELECT PlayerID FROM PlayerTeams WHERE TeamID = {teamID})";
            using (MySqlCommand command = new MySqlCommand(calculateAverageTimezoneQuery, connection))
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    double averageTimezone = Convert.ToDouble(result);
                    // Update the team's average timezone in the database
                    string updateTeamAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {averageTimezone} WHERE TeamID = {teamID}";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateTeamAverageTimezoneQuery, connection))
                    {
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        public void SetMatchWinner(string tournamentName, int matchId, int winnerID)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (MySqlConnection connection = new MySqlConnection())
            {
                connection.Open();
                string deleteTeamQuery = $"Update Matches SET Winner = {winnerID} WHERE MatchID = {matchId}; ";
                using (MySqlCommand command = new MySqlCommand (deleteTeamQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

        /*
        public void AssignPlayers(string tournamentName, Team team)
        {
            string connectionString = $"Data Source={tournamentName}.db";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    for (int i = 0; i < team.Players.Count; i++)
                    {
                        string editTableQuery = $"INSERT INTO PlayerTeams (PlayerID, TeamID) VALUES ({team.Players[i].Id}, {team.TeamID})";
                        using (MySqlCommand command = new MySqlCommand(editTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    // Calculate and update the team's average timezone
                    team.CalculateAverageTimezone();

                    string updateAverageTimezoneQuery = $"UPDATE Teams SET Timezone = {team.AverageTimezone} WHERE TeamID = {team.TeamID}";
                    using (MySqlCommand command = new MySqlCommand(updateAverageTimezoneQuery, connection))
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
        */
    }
}
