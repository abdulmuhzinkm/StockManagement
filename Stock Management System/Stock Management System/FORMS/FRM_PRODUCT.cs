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
    public partial class FRM_PRODUCT : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        public FRM_PRODUCT()
        {
            InitializeComponent();
            loadGridView();
        }

        private void FRM_PRODUCT_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            bool status;
            if(comboBox1.SelectedIndex==0)
            {
                status = true;
            }

            else
            {
                status = false;
            }


            var query = "";

            if (IfProductExist(con,textBoxCode.Text))
            {

                query = @"UPDATE [dbo].[Products] SET [ProductName] = '"+textBoxName.Text+"',[ProductStatus] = '"+status+"'WHERE [ProductCode] = '"+textBoxCode.Text+"' ";
                       

            }

            else
            {

                query = @"INSERT INTO[dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus])
            VALUES('" + textBoxCode.Text.Trim() + "','" + textBoxName.Text.Trim() + "','" + status + "')";
            }



            SqlCommand cmd = new SqlCommand(query ,con);
            cmd.ExecuteNonQuery();
            con.Close();  
            loadGridView();
            
            
        }

        private bool IfProductExist(SqlConnection con,string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT 1
             FROM [Products] WHERE [ProductCode] = '"+productCode+"' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count>0)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }

        public void loadGridView()
        {
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM[Stock].[dbo].[Products]", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
            }
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            if(dataGridView1.SelectedRows[0].Cells[2].Value.ToString()=="Active")
            {
                comboBox1.SelectedIndex = 0;
            }

            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            con.Open();
            var query = "";

            if (IfProductExist(con, textBoxCode.Text))
            {

                query = @"DELETE FROM [dbo].[Products] WHERE [ProductCode] = '"+textBoxCode.Text+"' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                loadGridView();

            }

            else
            {

                MessageBox.Show("RECORD NOT EXIST");
            }



        }
    }
}
