using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaxeirisiErgasiwn
{
    public partial class StudentSignUp : Form
    {
        Form1 globalForm;
        public StudentSignUp(Form1 form1)
        {
            globalForm = form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != textBox6.Text)
                {
                    MessageBox.Show("Οι 2 κωδικοί που πληκτρολογήσατε δεν είναι ίδιοι. Πρακαλώ προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Όνομα\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Επίθετο\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Email\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(textBox4.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Username\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Password\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    string name = textBox1.Text;
                    string surname = textBox2.Text;
                    string email = textBox3.Text;
                    string username = textBox4.Text;
                    string password = textBox5.Text;

                    // Name of database file
                    string fileName = "HomeworkManagement.db";
                    FileInfo f = new FileInfo(fileName);
                    // Full path to it
                    string path = f.FullName;

                    // Connection string with relative path
                    string connectionstring = "Data Source=" + path + ";Version=3;";

                    SQLiteConnection conn = new SQLiteConnection(connectionstring);
                    conn.Open();
                    string query1 = "INSERT INTO Student(name,surname,email,username,password) VALUES ('" + name + "','" + surname + "','" + email + "','" + username + "','" + password + "');";
                    SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    conn.Close();
                    MessageBox.Show("Έχετε καταχωρηθεί στο σύστημα επιτυχώς!! Σας μεταφέρουμε πίσω στην φόρμα εισαγωγής.", "Sign in successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    globalForm.Show();
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }

        }

        private void StudentSignUp_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            globalForm.Show();
            this.Close();
        }
    }
}
