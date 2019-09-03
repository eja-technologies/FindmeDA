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
        //method for switching user conrols
        public static void  changeUserControl(StackPanel main, StackPanel sub,UserControl userControl)
        {
            main.Children.Clear();
            main.Children.Add(userControl);
            sub.Children.Clear();
        }
        private void btn_log_in(object sender, RoutedEventArgs e)
        {
            
        }
       
        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            SignIn si = new SignIn();
            changeUserControl(mainbody,sub_menu,si);
        }
        private void SignUp_click(object sender, RoutedEventArgs e)
        {
            Signup su = new Signup();
            changeUserControl(mainbody, sub_menu, su);

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
