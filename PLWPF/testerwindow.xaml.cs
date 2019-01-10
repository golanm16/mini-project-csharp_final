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
using System.Windows.Shapes;
using MY_BE;
using MY_BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for testerwindow.xaml
    /// </summary>
    public partial class testerwindow : Window
    {
        IBL bl = FactoryBL.GetInstance();
        Tester tester = new Tester();
        public testerwindow(Tester t)
        {
            tester = t;
            InitializeComponent();
            this.Closing += this.On_Closed;
            //schedulegrid.Children.Clear();
            //testerSchedule ts = new testerSchedule(tester);
        }

        private void On_Closed(Object sender,System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(testIdBox.Text, out id))
            {
                Test test = bl.getAllTests().Where(x => x.TestNumber == id.ToString("00000000")).First();
                testUpdateWindow testUp = new testUpdateWindow(test);
                testUp.ShowDialog();
            }
            else
            {
                MessageBox.Show("must enter a number in id field!", "Error!");
            }
        }

        private void tib_Enter_Pressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(this, new RoutedEventArgs());
            }
        }
    }
}
