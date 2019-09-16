using BE;
using BL;
using System;
using System.Windows;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for addTest.xaml
    /// </summary>
    public partial class addTest : Window
    {
        IBL bl = FactoryBL.GetInstance();
        Test test = new Test();
        public addTest()
        {
            InitializeComponent();
            addtestgrid.DataContext = test;
            traineeVehicle.ItemsSource = Enum.GetValues(typeof(VehicleType));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(THourCB.SelectedIndex + 9, 01, 0);
            test.TestDate -= test.TestDate.TimeOfDay;
            test.TestDate += ts;
            try
            {
                bl.addTest(test);
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
    }
}
