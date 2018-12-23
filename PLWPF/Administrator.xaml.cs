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
using MY_BL;
using MY_BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        IBL bl = FactoryBL.GetInstance();
        public Administrator()
        {
            
            InitializeComponent();
            Tester golan = new Tester();
            Trainee ori = new Trainee();
            Test infi = new Test();
            bl.addTrainee(ori);
            bl.addTester(golan);
            bl.addTest(infi);
            testers_list.ItemsSource = bl.getAllTesters();
            tests_list.ItemsSource = bl.getAllTests();
            trainees_list.ItemsSource = bl.getAllTrainees();
            //testsgrid.Items.Add(golan);
        }
    }
}
