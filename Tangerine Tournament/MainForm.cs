using System;
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


        // ==================== Basic UI Controls ====================

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

        // ==================== CONNECT TAB ====================

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
                    builder.CreateTournament(connection, "Single Elimination", (int)numTournamentSize.Value, txtTournamentName.Text);
                }
                else
                {
                    MessageBox.Show("Invalid Tournament Size. Single Elimation tournaments must be a power of 2.");
                }
            }
        }


        // ==================== INFO TAB ====================

        private void btnUpdateInfo_Click(object sender, EventArgs e)
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

        // ========== OTHER METHODS ==========

        private bool CheckConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                MessageBox.Show("No connection established. Please try again.");
                return false;
            }
            return true;
        }

        public string GenerateConnectionString(string url, string filepath, string username, string password)
        {
            return $"Data Source={url};User Id={username};Password={password};";
        }

        
    }
}
