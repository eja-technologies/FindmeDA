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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btn_log_in(object sender, RoutedEventArgs e)
        {

        }

        private void btn_sign_up(object sender, RoutedEventArgs e)
        {
            Signup su = new Signup();
            //mainbody.Children.Clear();
            //mainbody.Children.Add(su);
            //sub_menu.Children.Clear();
        }
    }
}
