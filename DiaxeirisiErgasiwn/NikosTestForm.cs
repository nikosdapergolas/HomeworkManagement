using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaxeirisiErgasiwn
{
    public partial class NikosTestForm : Form
    {
        Form1 globalForm;

        // Name of google account credentials json
        public static string jsonName = "homeworkmanagement-dc212cac1689.json";
        public static FileInfo f = new FileInfo(jsonName);

        // Full path to it
        static string PathToServiceAccountKey2 = @f.FullName;

        //static string PathToServiceAccountKey = @"S:\visual_studio_projects\C#\HomeworkManagement\DiaxeirisiErgasiwn\bin\Debug\homeworkmanagement-dc212cac1689.json";
        //static string DirectoryId = "1j5GrlfQMXjDwSwYw2VhbixhC16jj4TtS";
        //static string UploadFileName = "Test1.txt";

        public NikosTestForm(Form1 form1)
        {
            InitializeComponent();
            globalForm = form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            globalForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string fileFormat = file.Substring(file.Length - 3);
                if (fileFormat == "zip" || fileFormat == "pdf" || fileFormat == "rar")
                {
                    MessageBox.Show(file,"Success!");
                    UploadFile(file);
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
                    string query1 = "insert into Homework(file) values('"+e.Data.GetData(DataFormats.FileDrop)+"');";
                    SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    MessageBox.Show("Successfully added the file...i think");
                    */
                }
                else
                {
                    MessageBox.Show("Wrong file format");
                }                
            }
                

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void UploadFile(string filePath)
        {
            try
            {
                string serviceAccountEmail = "homework-uploader@homeworkmanagement.iam.gserviceaccount.com";
                string directoryId = "1j5GrlfQMXjDwSwYw2VhbixhC16jj4TtS";

                // Load the Service account credentials and define the scope of its access.
                var credential = GoogleCredential.FromFile(PathToServiceAccountKey2).CreateScoped(DriveService.ScopeConstants.Drive);

                // Create the  Drive service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });

                // Upload fiole MetaData
                var fileMetaData = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = "test1.pdf",
                    Parents = new List<string>() { directoryId }
                };

                string uploadedFileId;
                using (var fsSource = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    // Create a new file with MetaData and stream
                    var request = service.Files.Create(fileMetaData, fsSource, "*/*");
                    request.Fields = "*";
                    var results = request.Upload();


                    if (results.Status.Equals(UploadStatus.Failed))
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        MessageBox.Show("Success!!");
                    }


                    uploadedFileId = request.ResponseBody?.Id;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void NikosTestForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PathToServiceAccountKey2);

            // Load the Service account credentials and define the scope of its access.
            var credential = GoogleCredential.FromFile(PathToServiceAccountKey2).CreateScoped(DriveService.ScopeConstants.Drive);

            // Create the  Drive service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            // Search for text files in the directory on my account.
            var request = service.Files.List();
            request.Q = "parents in '1j5GrlfQMXjDwSwYw2VhbixhC16jj4TtS'";
            var response = request.Execute();
            foreach(var file in response.Files)
            {
                MessageBox.Show(file.Name.ToString());
            }

            // Download a file
            if(response.Files.Count() > 0) 
            {
                // Trying to download them all
                foreach (var file in response.Files)
                {
                    var getRequest = service.Files.Get(file.Id);
                    var fileStream = new FileStream(file.Name, FileMode.Create, FileAccess.Write);
                    getRequest.Download(fileStream);
                }
                /*
                var downloadFile = response.Files.FirstOrDefault();
                var getRequest = service.Files.Get(downloadFile.Id);
                var fileStream = new FileStream(downloadFile.Name, FileMode.Create, FileAccess.Write);
                getRequest.Download(fileStream);
                */
            }

            MessageBox.Show("Files Downloaded successfully!");
            MessageBox.Show("End.");

            // A Lamda expression that filters the text files
            //file => file.MimeType.Equals("tetx/plain")
        }
    }
}
