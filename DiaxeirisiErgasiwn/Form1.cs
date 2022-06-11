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
    public partial class Form1 : Form
    {

        public static bool student_logging_in;
        public static bool professor_logging_in;
        public static bool admin_logging_in;

        //euakiii

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The exit button
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Depending on who logs in, it calls their login function
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if(student_logging_in == true)
            {
                // From here we call the student login function
                student_login(textBox1.Text, textBox2.Text);
            }  
            if(professor_logging_in == true)
            {
                // From here we call the professor login function
                professor_login(textBox1.Text, textBox2.Text);
            }
            if(admin_logging_in == true)
            {
                // From here we call the admin login function
                admin_login(textBox1.Text, textBox2.Text);
            }
        }

        /// <summary>
        /// The function is here for the student to login when the student_logging_in flag is true
        /// </summary>
        void student_login(string username, string password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select * from Student where username='"+username+"' and password='"+password+"';";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
                      
            if(reader.Read())
            {
                MessageBox.Show("welcome "+ reader.GetString(1) + " " + reader.GetString(2) + "!! :)","Login Successful");
            }
            else
            {
                MessageBox.Show("There is no such user...sorry", "ERROR");
            }
            
            conn.Close();
        }

        /// <summary>
        /// The function is here for the professor to login when the professor_logging_in flag is true
        /// </summary>
        void professor_login(string username, string password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select * from Professor where username='" + username + "' and password='" + password + "';";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("welcome " + reader.GetString(1) + " " + reader.GetString(2) + "!! :)", "Login Successful");
                this.Hide();
                Professor_Front_Page form = new Professor_Front_Page();
                form.Show();
            }
            else
            {
                MessageBox.Show("There is no such user...sorry", "ERROR");
            }

            conn.Close();
        }

        /// <summary>
        /// The function is here for the admin to login when the admin_logging_in flag is true
        /// </summary>
        void admin_login(string username, string password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select * from Admin where username='" + username + "' and password='" + password + "';";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialising some flags
            studentLoginToolStripMenuItem.BackColor = Color.Black;
            student_logging_in = true;
            professor_logging_in = false;
            admin_logging_in = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NikosTestForm test = new NikosTestForm(this);
            test.Show();
            this.Hide();
            /*
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring);

            conn.Open();
            string query1 = "select * from Admin;";
            SQLiteCommand cmd = new SQLiteCommand(query1,conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                MessageBox.Show(reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " ");
            }
            */
        }

        

        private void studentLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // When this is clicked, i do the checks in the login form to ensure
            // that the program knows who is logging in (In this case the student)

            // Some flags
            student_logging_in = true;
            professor_logging_in = false;
            admin_logging_in = false;

            studentLoginToolStripMenuItem.BackColor = Color.Black;
            professorLoginToolStripMenuItem.BackColor = panel1.BackColor;
            adminLoginToolStripMenuItem.BackColor = panel1.BackColor;

            label4.Text = "Welcome to the Students Portal";
        }

        private void professorLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // When this is clicked, i do the checks in the login form to ensure
            // that the program knows who is logging in (In this case the professor)

            // Some flags
            student_logging_in = false;
            professor_logging_in = true;
            admin_logging_in = false;

            studentLoginToolStripMenuItem.BackColor = panel1.BackColor;
            professorLoginToolStripMenuItem.BackColor = Color.Black;
            adminLoginToolStripMenuItem.BackColor = panel1.BackColor;

            label4.Text = "             Professors Login";
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // When this is clicked, i do the checks in the login form to ensure
            // that the program knows who is logging in (In this case the admin)

            // Some flags
            student_logging_in = false;
            professor_logging_in = false;
            admin_logging_in = true;

            studentLoginToolStripMenuItem.BackColor = panel1.BackColor;
            professorLoginToolStripMenuItem.BackColor = panel1.BackColor;
            adminLoginToolStripMenuItem.BackColor = Color.Black;

            label4.Text = "                Admins only!";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentSignUp signup = new StudentSignUp(this);
            signup.Show();
            this.Hide();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (student_logging_in == true)
            {
                // From here we call the student login function
                student_login(textBox1.Text, textBox2.Text);
            }
            if (professor_logging_in == true)
            {
                // From here we call the professor login function
                professor_login(textBox1.Text, textBox2.Text);
            }
            if (admin_logging_in == true)
            {
                // From here we call the admin login function
                admin_login(textBox1.Text, textBox2.Text);
            }
        }
    }

    public class Person 
    {
        string name;
        string surname;
        string email;

        public string getName()
        {
            return this.name;
        }
        public string getSurname()
        {
            return this.surname;
        }
        public string getEmail()
        {
            return this.email;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public void setSurame(string surname)
        {
            this.surname = surname;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }

    }

    public class Student : Person
    {
        string A_M;

        public string getA_M()
        {
            return this.A_M;
        }

        public void setA_M(string AM)
        {
            this.A_M = AM;
        }
    }

    public class Professor : Person
    {
        int ID;

        void setHomework(string nameOfHomework, string deadline)
        {
            Homework homework = new Homework(nameOfHomework,deadline);
        }

        void setpoints(int pointsOfHomework)
        {
            Points points = new Points();
            points.setPointsOfHomework(pointsOfHomework);
        }

        public int getID()
        {
            return this.ID;
        }

        public void setID(int id)
        {
            this.ID = id;
        }

    }

    public class Admin : Person
    {
        int adminID;

        void createProfessor(string name, string surname, string email, int id)
        {
            Professor professor = new Professor();
            professor.setName(name);
            professor.setSurame(surname);
            professor.setEmail(email);
            professor.setID(id);
        }

        public int getID()
        {
            return this.adminID;
        }

        public void setID(int id)
        {
            this.adminID = id;
        }
    }

    public class Team
    {
        public List<string> listOfStudents = new List<string>();
    }

    public class Homework
    {
        string nameofHomework;
        string deadline;

        public Homework(string nameofHomework, string deadline)
        {
            this.nameofHomework = nameofHomework;
            this.deadline = deadline;
        }
    }

    public class Points
    {
        int pointsOfHomework;

        public int getPointsOfHomework()
        {
            return this.pointsOfHomework;
        }

        public void setPointsOfHomework(int points)
        {
            this.pointsOfHomework = points;
        }
    }

}
