using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
namespace DataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
                    "password varchar(10) unique not null,Telephone varchar(13) not null,email varchar(30) not null," +
                    "photo BLOB)";
                MySqlCommand memberCreate = new MySqlCommand(tbMember,con);
                memberCreate.ExecuteNonQuery();
                //creating office table
                string tbOffice = "create table IF NOT EXISTS Office(OfficeID int(20) primary key not null auto_increment," +
                    "OfficeLocation varchar(15) not null,Building varchar(20) not null,RoomNo varchar(10))";
                MySqlCommand officeCreate = new MySqlCommand(tbOffice,con);
                officeCreate.ExecuteNonQuery();
                //creating Jobs table
                string tbJobs = "create table IF NOT EXISTS Jobs(JobID int(20) primary key not null auto_increment," +
                    "JobTitle varchar(20) not null,Qualification varchar(20) not null,Status varchar(20) not null,AdvertisedBy varchar(30) not null)";
                MySqlCommand jobCreate = new MySqlCommand(tbJobs, con);
                jobCreate.ExecuteNonQuery();
				//creating appointment table
				String tbAppoint ="create NOT EXISTS table Appointment(AppointmentID int(20) primary key not null auto_increment, status varchar(10),requestedBy varchar(30) not null,DateOfRequest varchar(11) not null )";
				MySqlCommand appointCreate = new MySqlCommand(tbAppoint,con);
				appointCreate.ExecuteNonQuery();
               // DataTable t = con.GetSchema("Tables");
                MessageBox.Show("Database "+con.Database+" has been successfully created. You can now check Your sql Server for the tables.");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

        }
    }
}
