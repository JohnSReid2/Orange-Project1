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
            string tournamentType = "null";
            if (checkSingleElim.Checked)
            {
                tournamentType = "Single Elimination";
            }    
            TournamentBuilder builder = new TournamentBuilder();
            builder.CreateTournament(txtTournamentName.Text, tournamentType);
        }
    }


}
