using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\source\repos\WindowsFormsApp4\WindowsFormsApp4\Database1.mdf;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                img.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = img.Text;
        }

        private void upload_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            Byte[] Imagebytes = File.ReadAllBytes(openFileDialog1.FileName);
            cmd.CommandText = "insert into regtable values(" + id.Text + ",'" + name.Text + "','" + sec.Text + "','" + branch.Text + "',@pic)";
            SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, Imagebytes.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, Imagebytes);
            cmd.Parameters.Add(prm);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("saved");
        }

        private void show_Click(object sender, EventArgs e)
        {
            string cmd = "Select Id,name,section,branch from regtable  ";
            SqlDataAdapter dp = new SqlDataAdapter(cmd, con);
            //  SqlCommandBuilder cb = new SqlCommandBuilder(dp);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dataGridView1.DataSource = bs;
        }

        private void showimg_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
