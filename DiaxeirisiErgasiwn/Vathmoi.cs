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
    public partial class Vathmoi : Form
    {
        StudentForm globalForm;
        public Vathmoi(StudentForm form)
        {
            globalForm = form;
            InitializeComponent();
        }

        private void Vathmoi_Load(object sender, EventArgs e)
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
            string query1 = "SELECT * FROM Student";
            //SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            //SQLiteDataReader reader = cmd.ExecuteReader();

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query1, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Info");
            guna2DataGridView1.DataSource = ds.Tables[0];

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            globalForm.Show();
        }
    }
}
