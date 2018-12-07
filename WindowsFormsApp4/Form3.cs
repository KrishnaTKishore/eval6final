using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\source\repos\WindowsFormsApp4\WindowsFormsApp4\Database1.mdf;Integrated Security=True");
       
        public Form3()
        {
            InitializeComponent();
        }

        private void show_Click(object sender, EventArgs e)
        {
            string cmd = "Select Id,name,section,branch from regtable  where Id='" + tb_id.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(cmd, con);
            //  SqlCommandBuilder cb = new SqlCommandBuilder(dp);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dataGridView1.DataSource = bs;
        }
    }
}
