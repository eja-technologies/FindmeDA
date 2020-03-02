using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.IO;

namespace FindMe
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : UserControl
    {
        string strName, imageName;        
        public Signup()
        {
            InitializeComponent();
        }
        //method that encrypts
        public static string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
            }
        }

        private void btn_Sign_up(object sender, RoutedEventArgs e)
        {
            //obtainin form parameters
            string fname = fName.Text;
            string lname = lName.Text;
            string usname = uname.Text;
            string p1 = pass1.Password;
            string p2 = pass2.Password;
            string tel = phone.Text;
            string mail = email.Text;
            try
            {
                //Initialize a file stream to read the image file
                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                //Initialize a byte array with size of stream
                byte[] imgByteArr = new byte[fs.Length];
                //Read data from the file stream and put into the byte array
                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                //Close a file stream
                fs.Close();
                //checking if the form fields are empty
                if (fname.Equals(string.Empty) || lname.Equals(string.Empty) || usname.Equals(string.Empty)
                   || p1.Equals(string.Empty) || p2.Equals(string.Empty) || tel.Equals(string.Empty) ||
                   mail.Equals(string.Empty))
                {
                    MessageBox.Show("Please Fill all the fields");
                }
                else
                {
                    //Verifying if the email is valid
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(mail);
                    if (match.Success)
                    {
                        //checking if passwords are equal 
                        if (p1.Equals(p2))
                        {
                            try
                            {
                                //encrypting the password
                                string pass = Hash(p1);
                                //connection string
                                string conString = "datasource=127.0.0.1;port=3306;username=root;password=;";
                                //establishing a connection to the database
                                MySqlConnection con = new MySqlConnection(conString);
                                //creating the database

                                string create = "CREATE DATABASE IF NOT EXISTS FindMe";
                                //prepare the statement
                                MySqlCommand commCreate = new MySqlCommand(create, con);
                                commCreate.CommandTimeout = 60;
                                //execute the query
                                con.Open();
                                commCreate.ExecuteNonQuery();
                                //choosing the database
                                con.ChangeDatabase("findMe");
                                //creating table Member
                                string tbMember = "create table IF NOT EXISTS Member(MemberID int(20) primary key not null auto_increment," +
                                    "fName varchar(15) not null,lName varchar(15) not null,username varchar(15) unique not null," +
                                    "password varchar(40) not null,Telephone varchar(13) not null,email varchar(30) not null," +
                                    "photo blob, name varchar(100))";
                                MySqlCommand memberCreate = new MySqlCommand(tbMember, con);
                                memberCreate.ExecuteNonQuery();
                                //creating office table
                                string tbOffice = "create table IF NOT EXISTS Office(OfficeID int(20) primary key not null auto_increment," +
                                    "OfficeLocation varchar(15) not null,Building varchar(20) not null,RoomNo varchar(10))";
                                MySqlCommand officeCreate = new MySqlCommand(tbOffice, con);
                                officeCreate.ExecuteNonQuery();
                                //creating Jobs table
                                string tbJobs = "create table IF NOT EXISTS Jobs(JobID int(20) primary key not null auto_increment," +
                                    "JobTitle varchar(20) not null,Qualification varchar(20) not null,Status varchar(20) not null,AdvertisedBy varchar(30) not null)";
                                MySqlCommand jobCreate = new MySqlCommand(tbJobs, con);
                                jobCreate.ExecuteNonQuery();
                                //creating appointment table
                                String tbAppoint = "create table IF NOT EXISTS  Appointment(AppointmentID int(20) primary key not null auto_increment, status varchar(10),requestedBy varchar(30) not null,DateOfRequest varchar(11) not null )";
                                MySqlCommand appointCreate = new MySqlCommand(tbAppoint, con);
                                appointCreate.ExecuteNonQuery();
                                // Inserting form data to table members                          
                                MySqlCommand insert_member = new MySqlCommand("INSERT INTO member(fName,lName,username,password,Telephone,email,photo,name) VALUES ('" + fname + "','" + lname + "','" + usname + "','" + pass + "','" + tel + "','" + mail + "','" + imgByteArr + "','"+strName+"')", con);
                                int i = insert_member.ExecuteNonQuery();
                                if (i == 1)
                                {
                                    MessageBox.Show("You have successfully Registered. You can now LogIn");
                                   // Signup su = new Signup();
                                   /*
                                    Window window = new Window
                                    {
                                        Title = "Second User Control",
                                        Content = new SignIn(),
                                        WindowStartupLocation = WindowStartupLocation.CenterScreen,
                                        ResizeMode = ResizeMode.NoResize
                                    };
                                    window.ShowDialog();
                                    */
                                }
                                else
                                {
                                    MessageBox.Show("Registration failed. please try again");

                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                            }


                        }
                        else
                        {
                            MessageBox.Show("The passwords do not match");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Email is not correct");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        //uploading a photo
        
        private void btnBrowse_photo(object sender, RoutedEventArgs e)
        {
            try
            {
                //opening the file dialog
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png";
                fldlg.ShowDialog();
                strName = fldlg.SafeFileName;
                imageName = fldlg.FileName;
                ImageSourceConverter isc = new ImageSourceConverter();
                profilePic.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                //closing the file dialog
                fldlg = null;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
