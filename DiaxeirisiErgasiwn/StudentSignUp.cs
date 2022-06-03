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
        public StudentSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != textBox6.Text)
                {
                    MessageBox.Show("Password are not the same, Try again", "Error");
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
                    string query1 = "INSERT INTO Student(name,surname,email,username,password) VALUES ('" + name + "','" + surname + "','"+email+"','"+username+"','"+password+"');";
                    SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("welcome " + reader.GetString(1) + " " + reader.GetString(2) + "!! :)", "Login Successful");
                    }
                    else
                    {
                        MessageBox.Show("There is no such user...sorry", "ERROR");
                    }

                    conn.Close();
                }
            }
            catch(Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
