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
using System.IO;

namespace DiaxeirisiErgasiwn
{
    public partial class Professor_Assignement_Creation : Form
    {
        public Professor_Assignement_Creation()
        {
            InitializeComponent();
        }

        private void Professor_Assignement_Creation_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Professor_Front_Page form = new Professor_Front_Page();
            form.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //anoigma arxeiou ,epilogi kai save locally 
            if (dialog.ShowDialog() == DialogResult.OK) // meta to ok 
            {
                String path = @"Doc\Ergasia"; // get name of file
               

                var arxio = System.IO.Path.GetFileName(dialog.FileName);
                path = path + arxio;
                File.Copy(dialog.FileName,path);
                
                this.Refresh();
                    
                
            }
        }
    }
}
