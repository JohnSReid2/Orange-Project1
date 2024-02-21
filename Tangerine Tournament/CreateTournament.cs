using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Tangerine_Tournament
{
    public partial class CreateTournament : Form
    {
        public CreateTournament()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tournamentName = txtTournamentName.Text;

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

                        if (checkSingleElim.Checked)
                        {
                            string editTableQuery = $"INSERT INTO TournamentInfo (Name, Date, Type) VALUES ('{tournamentName}', '{System.DateTime.Now.ToString()}', 'Single Elimination')";
                            using (SqliteCommand command = new SqliteCommand(editTableQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }


}
