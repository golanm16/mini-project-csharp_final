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
using MY_BL;
using MY_BE;

namespace PLWPF
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = FactoryBL.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AdminUsername.Text=="admin"&& AdminPassword.Password == "admin")
            {
                Administrator admin = new Administrator();
                admin.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (testerId.Text == "00000000")
            {
                testerwindow tester = new testerwindow();
                tester.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
