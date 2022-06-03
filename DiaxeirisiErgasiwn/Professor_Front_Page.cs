using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaxeirisiErgasiwn
{
    public partial class Professor_Front_Page : Form
    {
        public Professor_Front_Page()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form=new Form1();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Professor_Assignement_Creation form = new Professor_Assignement_Creation();
            form.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
