using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Stock_Management_System.FORMS
{
    public partial class FRM_HOME : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        public FRM_HOME()
        {
            InitializeComponent();
        }

        private void FRM_HOME_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FRM_HOME_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            FRM_PRODUCT ss = new FRM_PRODUCT();
            ss.MdiParent = this;
            ss.Show();
        }
    }
}
 