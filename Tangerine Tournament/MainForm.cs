using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;
using Tangerine_Tournament.Objects;

namespace Tangerine_Tournament
{
    public partial class MainForm : Form
    {

        bool mouseDown;

        public string connectionString = String.Empty;

        private TournamentBuilder builder = new TournamentBuilder();
        private TournamentGetter getter = new TournamentGetter();

        public MySqlConnection connection = new MySqlConnection();
        public MainForm()
        {
            InitializeComponent();
        }

        private void tabPage1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }


        // ======================================== Basic UI Controls ========================================

        //Allow dragging the window
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int mousex = MousePosition.X - 400; int mousey = MousePosition.Y - 20;
                this.SetDesktopLocation(mousex, mousey);
            }
        }
        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        //Close button functionality
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimise buttton functionality
        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // ======================================== CONNECT TAB ========================================

        //Show Password Button functionality
        private void btnShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }
        private void btnShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            string filepath = txtConnectTournament.Text;
            string username = @"" + txtUsername.Text;
            string password = txtPassword.Text;

            connectionString = GenerateConnectionString(url, filepath, username, password);
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connection successful.");
            }
            catch (MySqlException)
            {
                MessageBox.Show("Connection failed. Please try again.");
                connectionString = string.Empty;
            }
        }

        private void btnConnectDatabase_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }

            try
            {
                string useQuery = $"USE {txtConnectTournament.Text}";
                using (MySqlCommand command = new MySqlCommand(useQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                MessageBox.Show($"Successfully connected to {txtConnectTournament.Text} tournament");
            }
            catch
            {
                MessageBox.Show("Cannot connect. If this tournament does not exist, create a new one in the \"create\" tab.");
            }
        }



        // =========== CREATE TAB ==========
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }

            if (rbtnSingleElim.Checked)
            {
                double d = Math.Log2((double)numTournamentSize.Value);
                bool isInt = d == (int)d;
                if (isInt)
                {
                    builder.CreateTournament(connection, "Single Elimination", (int)numTournamentSize.Value, txtTournamentName.Text, checkIsTeams.Checked);
                }
                else
                {
                    MessageBox.Show("Invalid Tournament Size. Single Elimation tournaments must be a power of 2.");
                }
            }
        }


        // ======================================== INFO TAB ========================================



        private void btnPopulateInfo_Click(object sender, EventArgs e)
        {
            Tournament tournamentInfo = null;
            if (!CheckConnection()) { return; }

            string typeQuery = $"SELECT Type FROM TournamentInfo;";
            string type = string.Empty;

            using (MySqlCommand command = new MySqlCommand(typeQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
            }


            if (type == "Single Elimination")
            {
                tournamentInfo = getter.GetTournamentInfoSingleElim(connection);
            }

            txtNameInfo.Text = tournamentInfo.Name;
            datetimeInfo.Value = tournamentInfo.Date;
            txtTypeInfo.Text = tournamentInfo.Type.ToString();
            numSizeInfo.Value = tournamentInfo.Size;
            checkIsLockedInfo.Checked = tournamentInfo.MatchLocked;
            checkIsTeamsInfo.Checked = tournamentInfo.IsTeams;

            if (tournamentInfo.MatchLocked)
            {
                datetimeInfo.Enabled = false;
                numSizeInfo.Enabled = false;

                checkIsLockedInfo.Enabled = false;
                checkIsTeamsInfo.Enabled = false;
            }
            else
            {
                datetimeInfo.Enabled = true;
                numSizeInfo.Enabled = true;

                checkIsLockedInfo.Enabled = true;
                checkIsTeamsInfo.Enabled = true;
            }
        }


        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string typeQuery = $"SELECT Type FROM TournamentInfo;";
            string type = string.Empty;
            bool locked = false;

            using (MySqlCommand command = new MySqlCommand(typeQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(0);
                    }
                }
            }


            string updateInfo = $"UPDATE TournamentInfo SET Date = '{datetimeInfo.Value.ToString("yyyy-MM-dd hh:mm:ss")}', Size = {numSizeInfo.Value}, MatchLocked = {checkIsLockedInfo.Checked}, IsTeams = {checkIsTeamsInfo.Checked};";


            if (type == "Single Elimination")
            {
                double d = Math.Log2((double)numSizeInfo.Value);
                bool isInt = d == (int)d;
                if (isInt)
                {
                    using (MySqlCommand command = new MySqlCommand(updateInfo, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Tournament Size. Single Elimation tournaments must be a power of 2.");
                }
            }
        }


        // ======================================== PLAYERS TAB ========================================
        private void btnLoadPlayers_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }


            string typeQuery = $"SELECT * FROM Players;";

            using (MySqlCommand command = new MySqlCommand(typeQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Clear existing data if any
                        dataGridPlayer.Rows.Clear();

                        // Loop through the rows
                        while (reader.Read())
                        {
                            dataGridPlayer.Rows.Add(reader.GetValue(0),
                                reader.GetValue(1), reader.GetValue(2),
                                reader.GetValue(3), reader.GetValue(5),
                                reader.GetValue(4));
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found!");
                    }
                }
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string playerIDString = txtPlayerID.Text;
            string playerFName = txtPlayerFName.Text;
            string playerLName = txtPlayerLName.Text;
            string playerTag = txtPlayerTag.Text;
            string playerEmail = txtPlayerEmail.Text;
            int playerTimezone = (int)numPlayerTimezone.Value;

            int playerID;
            bool toInt = int.TryParse(playerIDString, out playerID);


            if (string.IsNullOrWhiteSpace(playerIDString) || string.IsNullOrWhiteSpace(playerFName) ||
                string.IsNullOrWhiteSpace(playerLName) || string.IsNullOrWhiteSpace(playerTag) ||
                string.IsNullOrWhiteSpace(playerEmail))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            if (!toInt)
            {
                MessageBox.Show("Player ID must be a numeric value");
                return;
            }


            Player player = new Player(playerID, playerFName, playerLName, playerTimezone, playerTag, playerEmail);
            builder.AddPlayer(connection, player);
        }

        private void dataGridPlayer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridPlayer.Rows[e.RowIndex];
                txtPlayerID.Text = row.Cells[0].Value.ToString();
                txtPlayerFName.Text = row.Cells[1].Value.ToString();
                txtPlayerLName.Text = row.Cells[2].Value.ToString();
                txtPlayerTag.Text = row.Cells[3].Value.ToString();
                txtPlayerEmail.Text = row.Cells[5].Value.ToString();
                numPlayerTimezone.Value = (int)row.Cells[4].Value;

            }
        }

        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string playerIDString = txtPlayerID.Text;
            string playerFName = txtPlayerFName.Text;
            string playerLName = txtPlayerLName.Text;
            string playerTag = txtPlayerTag.Text;
            string playerEmail = txtPlayerEmail.Text;
            int playerTimezone = (int)numPlayerTimezone.Value;

            int playerID;
            bool toInt = int.TryParse(playerIDString, out playerID);

            if (toInt)
            {
                Player player = new Player(playerID, playerFName, playerLName, playerTimezone, playerTag, playerEmail);
                builder.UpdatePlayer(connection, player);
            }
            else
            {
                MessageBox.Show("Player ID must be a numeric value");
            }
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            //Get player ID and then delete the player from the database
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string playerIDString = txtPlayerID.Text;
            int playerID;
            bool toInt = int.TryParse(playerIDString, out playerID);
            if (toInt)
            {
                builder.RemovePlayer(connection, playerID);
            }
            else
            {
                MessageBox.Show("Player ID must be a numeric value");
            }
        }

        // ======================================== TEAMS TAB ========================================

        private void btnLoadTeams_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }

            string typeQuery = $"SELECT * FROM Teams;";

            using (MySqlCommand command = new MySqlCommand(typeQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Clear existing data if any
                        dataGridTeams.Rows.Clear();

                        // Loop through the rows
                        while (reader.Read())
                        {
                            dataGridTeams.Rows.Add(reader.GetValue(0),
                                reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found!");
                    }
                }
            }
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string teamIDString = txtTeamID.Text;
            string teamCaptainIDString = txtCaptainID.Text;
            string teamName = txtTeamName.Text;

            int teamID;
            bool toInt = int.TryParse(teamIDString, out teamID);

            int captainID;
            bool toInt2 = int.TryParse(teamCaptainIDString, out captainID);

            if (string.IsNullOrWhiteSpace(teamIDString) || string.IsNullOrWhiteSpace(teamName))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            if (!toInt)
            {
                MessageBox.Show("Team ID must be a numeric value");
                return;
            }
            if (!toInt2)
            {
                MessageBox.Show("Captain ID must be a numeric value");
                return;
            }

            Team team = new Team(teamID, teamName, getter.GetPlayer(captainID, connection));
            builder.AddTeam(connection, team);
        }

        private void btnUpdateTeam_Click(object sender, EventArgs e)
        {
            //Function to update a teams name and team captain
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string teamIDString = txtTeamID.Text;
            string teamCaptainIDString = txtCaptainID.Text;
            string teamName = txtTeamName.Text;
            int teamID;
            bool toInt = int.TryParse(teamIDString, out teamID);

            int captainID;
            bool toInt2 = int.TryParse(teamCaptainIDString, out captainID);

            if (toInt)
            {
                Team team = new Team(teamID, teamName, getter.GetPlayer(captainID, connection));
                builder.UpdateTeam(connection, team);
            }
            else
            {
                MessageBox.Show("Team ID must be a numeric value");
            }
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            //Function to remove a team from the database
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string teamIDString = txtTeamID.Text;
            int teamID;
            bool toInt = int.TryParse(teamIDString, out teamID);
            if (toInt)
            {
                builder.RemoveTeam(connection, getter.GetTeam(teamID, connection));
            }
            else
            {
                MessageBox.Show("Team ID must be a numeric value");
            }
        }

        private void btnAssignPlayer_Click(object sender, EventArgs e)
        {
            //Function to assign a player to a team
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string teamIDString = txtTeamID.Text;
            string playerIDString = txtPlayerID.Text;

            int teamID;
            bool toInt = int.TryParse(teamIDString, out teamID);

            int playerID;
            bool toInt2 = int.TryParse(playerIDString, out playerID);

            if (toInt && toInt2)
            {
                builder.AssignPlayer(connection, getter.GetTeam(teamID, connection), getter.GetPlayer(playerID, connection));
            }
            else
            {
                MessageBox.Show("Team ID and Player ID must be numeric values");
            }
        }

        private void btnRemoveTeamPlayer_Click(object sender, EventArgs e)
        {
            //function to remove a player from a team
            if (!CheckConnection()) { return; }
            if (CheckLocked()) { return; }

            string teamIDString = txtTeamID.Text;
            string playerIDString = txtPlayerID.Text;
            int teamID;
            bool toInt = int.TryParse(teamIDString, out teamID);
            int playerID;
            bool toInt2 = int.TryParse(playerIDString, out playerID);
            if (toInt && toInt2)
            {
                builder.RemovePlayerFromTeam(connection, getter.GetTeam(teamID, connection), getter.GetPlayer(playerID, connection));
            }
            else
            {
                MessageBox.Show("Team ID and Player ID must be numeric values");
            }
        }

        private void dataGridTeams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Function to load team information into the textboxes
            //And populate the team players datagrid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridTeams.Rows[e.RowIndex];
                txtTeamID.Text = row.Cells[0].Value.ToString();
                txtTeamName.Text = row.Cells[1].Value.ToString();
                txtCaptainID.Text = row.Cells[2].Value.ToString();

                int teamID = (int)row.Cells[0].Value;

                string typeQuery = $"SELECT * FROM TeamPlayers WHERE TeamID = {teamID};";

                using (MySqlCommand command = new MySqlCommand(typeQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Clear existing data if any
                            dataGridTeamPlayers.Rows.Clear();

                            // Loop through the rows
                            while (reader.Read())
                            {
                                dataGridTeamPlayers.Rows.Add(reader.GetValue(1),
                                                                       reader.GetValue(2), reader.GetValue(3),
                                                                                                          reader.GetValue(4), reader.GetValue(5),
                                                                                                                                             reader.GetValue(6));
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found!");
                        }
                    }
                }
            }
        }

        private void dataGridTeamPlayers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Function to load player information into the player textboxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridTeamPlayers.Rows[e.RowIndex];
                txtPlayerID.Text = row.Cells[0].Value.ToString();
                txtPlayerFName.Text = row.Cells[1].Value.ToString();
                txtPlayerLName.Text = row.Cells[2].Value.ToString();
                txtPlayerTag.Text = row.Cells[3].Value.ToString();
                txtPlayerEmail.Text = row.Cells[5].Value.ToString();
                numPlayerTimezone.Value = (int)row.Cells[4].Value;
            }
        }
        /*
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            Thread t = new Thread((ThreadStar) =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                    }
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            txtConnectTournament.Text = filePath;
        }
        */

        // ======================================== OTHER METHODS ========================================

        private bool CheckConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                MessageBox.Show("No connection established. Please try again.");
                return false;
            }
            return true;
        }

        private bool CheckLocked()
        {
            if (!CheckConnection()) { return true; }

            bool locked = true;
            string typeQuery = $"SELECT MatchLocked FROM TournamentInfo;";

            using (MySqlCommand command = new MySqlCommand(typeQuery, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        locked = reader.GetBoolean(0);
                    }
                }
            }

            if (locked)
            {
                MessageBox.Show("Tournament is locked. No changes can be made.");
            }
            return locked;
        }

        public string GenerateConnectionString(string url, string filepath, string username, string password)
        {
            return $"Data Source={url};User Id={username};Password={password};";
        }

        
    }
}
