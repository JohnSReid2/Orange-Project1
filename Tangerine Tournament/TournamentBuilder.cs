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
                        string createTableQuery = "CREATE TABLE Players (PlayerID int PRIMARY KEY, FirstName varchar(255), LastName varchar(255), Gamertag varchar(255), Country varchar(255), Email varchar(255));";

                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        createTableQuery = $"CREATE TABLE Teams (TeamID int PRIMARY KEY,TeamName varchar(255), TeamCaptainID int, FOREIGN KEY (TeamCaptainID) REFERENCES Players(PlayerID));";
                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        createTableQuery = $"CREATE TABLE TeamPlayers (TeamID int, PlayerID int, PRIMARY KEY (TeamID, PlayerID), FOREIGN KEY (TeamID) REFERENCES Teams(TeamID), FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID));";
                        using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        createTableQuery = $"CREATE TABLE TournamentInfo (Name varchar(255), Date varchar(255), Type varchar(255));";
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
                    string editTableQuery = $"INSERT INTO Players (PlayerID, FirstName, LastName, Gamertag, Country, Email) VALUES ({player.Id}, '{player.FirstName}', '{player.LastName}', '{player.GamerTag}', '{player.Country}', '{player.EmailAddress}')";
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

        }

        public void RemoveTeam(string tournamentName, Team team)
        {

        }
    }
}
