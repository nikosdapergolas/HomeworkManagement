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

        public static Student student;
        public static Professor professor;
        public static Admin admin;

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
                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                student = new Student();

                student.A_M = (int)reader.GetInt32(0);
                student.Name = reader.GetString(1);
                student.Surname = reader.GetString(2);
                student.Email = reader.GetString(3);

                // Μηνυμα επιτυχίας και χαράς
                // και καλώ τη δευτερη φόρμα
                MessageBox.Show("welcome "+ reader.GetString(1) + " " + reader.GetString(2) + "!! :)","Login Successful");
                StudentForm sform = new StudentForm(this,student);
                sform.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("There is no such user...sorry", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                // Κώδικας για το αν πατήσει το οκ αντι για cancel
                // (Σε περίπτωση που χρειαστεί κάπου)
                
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

                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                professor = new Professor();

                professor.ID = (int)reader.GetInt32(0);
                professor.Name = reader.GetString(1);
                professor.Surname = reader.GetString(2);
                professor.Email = reader.GetString(3);
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


                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                admin = new Admin();

                admin.AdminID = (int)reader.GetInt32(0);
                admin.Name = reader.GetString(1);
                admin.Surname = reader.GetString(2);
                admin.Email = reader.GetString(3);
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

            label4.Text = "Καλωσορίσατε στο Students Portal";

            // Eργοποίηση δυνατότητας sign up
            panel2.Enabled = true;
            panel2.Visible = true;
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

            label4.Text = "               Professors Login";

            // Aπενεργοποίηση δυνατότητας sign up
            panel2.Enabled = false;
            panel2.Visible = false;
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

            label4.Text = "                  Admins μόνο!";

            // Aπενεργοποίηση δυνατότητας sign up
            panel2.Enabled = false;
            panel2.Visible = false;
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
        string name { get; set; }
        string surname { get; set; }
        string email { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }

    public class Student : Person
    {
        int a_m;
        public int A_M
        {
            get { return a_m; }
            set { a_m = value; }
        }
        void createTeam(string teamName)
        {
            Team team = new Team();
            team.TeamName = teamName;
            // Μενει σε αυτο το σημείο Να βαλω ως παράμετρο τον αριθμό
            // των ατόμων της ομάδας, και ανάλογα με αυτόν τον αριθμό, να τρέχει ένα 
            // for loop που θα ζητάει τα ονόματα και τα ΑΜ για να τα προσθέτει
        }
    }

    public class Professor : Person
    {
        int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        void setHomework(string nameOfHomework, string deadline)
        {
            Homework homework = new Homework(nameOfHomework,deadline);
        }

        void setpoints(int pointsOfHomework)
        {
            Points points = new Points();
            points.PointsOfHomework = pointsOfHomework;
        }

    }

    public class Admin : Person
    {
        int adminID;
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        void createProfessor(string name, string surname, string email, int id)
        {
            Professor professor = new Professor();
            professor.Name = name;
            professor.Surname = surname;
            professor.Email = email;
            professor.ID = id;
        }
    }

    public class Team
    {
        string teamName;
        public string TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public List<string> listOfStudents = new List<string>();
    }

    public class Homework
    {
        string nameofHomework;
        string deadline;
        public string NameofHomework
        {
            get { return nameofHomework; }
            set { nameofHomework = value; }
        }
        public string Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }

        public Homework(string nameofHomework, string deadline)
        {
            this.NameofHomework = nameofHomework;
            this.Deadline = deadline;
        }
    }

    public class Points
    {
        int pointsOfHomework;
        public int PointsOfHomework
        {
            get { return pointsOfHomework; }
            set { pointsOfHomework = value; }
        }
    }

}
