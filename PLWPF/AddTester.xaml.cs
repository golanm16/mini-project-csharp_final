using BE;
using BL;
using System;
using System.Windows;

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
            testerGender.ItemsSource = Enum.GetValues(typeof(Gender));
            testerVehicle.ItemsSource = Enum.GetValues(typeof(VehicleType));
            birthDate.SelectedDate = DateTime.Now.AddYears(-40);
        }

        public void Add_Tester_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTester(tester);
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "ERROR");
            }

        }

    }
}
