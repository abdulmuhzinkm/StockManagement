using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Stock_Management_System.FORMS
{
    public partial class FRM_LOGIN : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                           FROM[dbo].[Login] WHERE UserName = '"+textBox1.Text.Trim()+"' AND Password = '"+textBox2.Text.Trim()+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count==1)

            {
                    this.Hide();
                    FRM_HOME ss = new FRM_HOME();
                    ss.Show(); 
            }

            else
            {
                MessageBox.Show("Invalid user name or password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                button2_Click(sender, e);
            }

        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {

        }
    }
}
