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
    public partial class HWupload : Form
    {
        StudentForm globalForm;

        public HWupload(StudentForm form)
        {
            globalForm = form;
            InitializeComponent();
        }

        private void HWupload_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            globalForm.Show();
            this.Close();
        }
    }
}
