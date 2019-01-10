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
    /// Interaction logic for testUpdateWindow.xaml
    /// </summary>
    public partial class testUpdateWindow : Window
    {
        IBL bl = FactoryBL.GetInstance();
        MY_BE.Test testcontrol = new MY_BE.Test();
        public testUpdateWindow(Test test)
        {
            testcontrol = test;
            InitializeComponent();
            testUpdateGrid.DataContext = test;
            par1.ItemsSource = Enum.GetValues(typeof(Rating));
            par2.ItemsSource = Enum.GetValues(typeof(Rating));
            par3.ItemsSource = Enum.GetValues(typeof(Rating));
            par4.ItemsSource = Enum.GetValues(typeof(Rating));
        }

        private void Submit_test(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateTestOnFinish(testcontrol);
            }catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "ERROR!");
            }
            this.Close();
        }
    }
}
