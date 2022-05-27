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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world");
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
