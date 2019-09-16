using BE;
using BL;
using System;
using System.Windows;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for addTrainee.xaml
    /// </summary>
    public partial class addTrainee : Window
    {
        IBL bl = FactoryBL.GetInstance();
        Trainee trainee = new Trainee();
        public addTrainee()
        {
            InitializeComponent();
            addtraineegrid.DataContext = trainee;
            traineeGender.ItemsSource = Enum.GetValues(typeof(Gender));
            traineeGearbox.ItemsSource = Enum.GetValues(typeof(GearBox));
            traineeVehicle.ItemsSource = Enum.GetValues(typeof(VehicleType));
            birthDate.SelectedDate = DateTime.Now.AddYears(-18);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bl.addTrainee(trainee);
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "ERROR");
            }
        }
    }
}
