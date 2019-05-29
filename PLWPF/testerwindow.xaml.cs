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
            List<Test> my_tests = bl.getAllTests().Where(x => x.TesterId == tester.id).ToList();
            scheduledatagrid.ItemsSource = my_tests.Where(x=>x.TestDate>=DateTime.Now);
            testIdComboBox.ItemsSource = my_tests.Where(x=> x.TestDate <= DateTime.Now&&x.TestParams["distance"]  ==0).Select(x => x.TestNumber);
            welcomeLabel.Content = welcomeLabel.Content+tester.FamilyName+" "+ tester.PrivateName;
            testerGender.ItemsSource = Enum.GetValues(typeof(Gender));
            testerVehicle.ItemsSource = Enum.GetValues(typeof(VehicleType));
            testerinfogrid.DataContext = tester;
        }

        private void On_Closed(Object sender,System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }//when pressing x open the main window

        private void submitButtonClick(object sender, RoutedEventArgs e)
        {
            if (testIdComboBox.SelectedItem != null)
            {
                Test test = bl.getAllTests().Where(x => x.TestNumber == testIdComboBox.SelectedItem.ToString()).FirstOrDefault();
                testUpdateWindow testUp = new testUpdateWindow(test);
                testUp.ShowDialog();
            }
            else
            {
                MessageBox.Show("test doesn't exist", "ERROR!");
            }
        }//update test grading on pervious tests

        private void tib_Enter_Pressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                submitButtonClick(this, new RoutedEventArgs());
            }
        }
        public void editInfo(object sender, RoutedEventArgs e)
        {
            testerButton.Content = "update Details";
            testerButton.Click -= editInfo;
            testerButton.Click += updateDetails;
            privateName.IsEnabled = true;
        }
        public void updateDetails(object sender, RoutedEventArgs e)
        {
            testerButton.Content = "edit Info";
            testerButton.Click -= updateDetails;
            testerButton.Click += editInfo;
            privateName.IsEnabled = false;
            try
            {
                bl.updateTester(tester);
            }
            catch (Exception e1)
            {
                MessageBox.Show("tester info couldn't be updated due to:\n" + e1.Message);
            }
        }
    }
}
