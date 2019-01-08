using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            bl.addmyTrainees();
            bl.addmyTesters();
            bl.addmytests();
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
            int tid;
            int.TryParse(testerId.Text,out tid);
            Tester tester = bl.getAllTesters().Where(x => x.id == tid).First();
            if (tester!=null)
            {
                testerwindow testerw = new testerwindow();
                testerw.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int tid;
            bool flag=int.TryParse(traineeid.Text, out tid);
            Trainee trainee = bl.getAllTrainees().Where(item => item.id == tid).First();

            if (trainee != null)
            {
                traineeWindow traineew = new traineeWindow(trainee);
                traineew.Show();
                this.Close();
            }
        }
    }
}
