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

namespace FindMe
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

        
        
        private void btn_log_in(object sender, RoutedEventArgs e)
        {

        }
       
        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            SignIn si = new SignIn();
            mainbody.Children.Clear();
            mainbody.Children.Add(si);
            sub_menu.Children.Clear();

        }
        private void SignUp_click(object sender, RoutedEventArgs e)
        {
            Signup su = new Signup();
            mainbody.Children.Clear();
            mainbody.Children.Add(su);
            sub_menu.Children.Clear();

        }

        private void Jobs_click(object sender, RoutedEventArgs e)
        {

        }

        private void Office_click(object sender, RoutedEventArgs e)
        {

        }

        private void Appointment_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
