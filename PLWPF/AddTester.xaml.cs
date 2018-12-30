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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        IBL bl = FactoryBL.GetInstance();
        Tester tester = new Tester();
        public AddTester()
        {
            InitializeComponent();
            addtestergrid.DataContext = tester;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.addTester(tester);
            Administrator admin = new Administrator();
            admin.Show();
            this.Close();
        }
    }
}
