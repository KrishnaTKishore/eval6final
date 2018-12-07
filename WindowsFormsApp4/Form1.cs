using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void log_Click(object sender, EventArgs e)
        {
            if (usrnm.Text == "rose" && pass.Text == "123")
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
        }
    }
}
