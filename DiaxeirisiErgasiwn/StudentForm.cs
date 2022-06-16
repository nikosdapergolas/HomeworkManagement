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
    public partial class StudentForm : Form
    {
        Form1 globalForm;
        Student student2;

        public StudentForm(Form1 form, Student student)
        {
            globalForm = form;
            student2 = student;
            
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // Εμφανίζω την πληροφορία που πήρα απο την φόρμα του login
            label1.Text = student2.A_M.ToString();
            label2.Text = student2.Name;
            label3.Text = student2.Surname;
            label4.Text = student2.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            globalForm.Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vathmoi v = new Vathmoi(this);
            v.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HWupload v = new HWupload(this);
            v.Show();
        }
    }
}
