using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangerine_Tournament
{
    public partial class ManagerView : Form
    {
        public ManagerView()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateTournament create = new CreateTournament();
            create.Show();
        }
    }
}
