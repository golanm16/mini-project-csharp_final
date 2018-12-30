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
using MY_BE;
using MY_BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for testerScreen.xaml
    /// </summary>
    public partial class testerScreen : UserControl
    {
        IBL bl = FactoryBL.GetInstance();
        public testerScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Test item in bl.getAllTests())
            {
                if(item.TestNumber== testIdBox.Text)
                {
                    testUpdateUserControl testUp = new testUpdateUserControl(item);
                    testblock.Children.Clear();
                    testblock.Children.Add(testUp);
                }
            }
        }
    }
}
