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
        //string page_title;
        //default contents
        private readonly FrameworkElement _submenuView;
        private readonly FrameworkElement _bodyView;
        public static readonly DependencyProperty page_titleProperty =
            DependencyProperty.Register("page_title", typeof(string), typeof(MainWindow), new UIPropertyMetadata(string.Empty));

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = this;

            //page_title = "SignIn";
            _submenuView = new SignIn();
            _bodyView = new SignIn();
            //pageTitle.DataContext = page_title;
            this.page_title = "Muwonge";
            mainbody.Children.Add(_bodyView); // set the default view
        }
        //method for switching user conrols
        public static void  changeUserControl(StackPanel main, StackPanel sub,UserControl userControl)
        {
            main.Children.Clear();
            main.Children.Add(userControl);
            sub.Children.Clear();
        }

        public string page_title
        {
            get { return (string)GetValue(page_titleProperty); }
            set { SetValue(page_titleProperty, value); }
        }
        
        
        private void btn_log_in(object sender, RoutedEventArgs e)
        {
            
        }
       
        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            SignIn si = new SignIn();
            mainbody.Children.Clear();
            mainbody.Children.Add(si);
            //sub_menu.Children.Clear();
            page_title = "SignIn";

        }
        private void SignUp_click(object sender, RoutedEventArgs e)
        {
            Signup su = new Signup();
            mainbody.Children.Clear();
            mainbody.Children.Add(su);
            //sub_menu.Children.Clear();

        }

        private void Jobs_click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("You are in Jobs", "Jobs", MessageBoxButton.YesNoCancel, MessageBoxImage.Hand);
            Jobs jobs = new Jobs();
            mainbody.Children.Clear();
            mainbody.Children.Add(jobs);
            //sub_menu.Children.Clear();
        }

        private void Office_click(object sender, RoutedEventArgs e)
        {

        }

        private void Appointment_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
