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
    /// Interaction logic for Jobs.xaml
    /// </summary>
    public partial class Jobs : UserControl
    {
        public Jobs()
        {
            InitializeComponent();
        }

        private void btn_log_in(object sender, RoutedEventArgs e)
        {
            Signup su = new Signup();
            MessageBox.Show("You have called another userControl from another", "UserControls", MessageBoxButton.YesNoCancel, MessageBoxImage.Hand);
            MainWindow mw = Window.GetWindow(this) as MainWindow;
            mw.mainbody.Children.Clear();
            mw.mainbody.Children.Add(su);

        }
    }
}
