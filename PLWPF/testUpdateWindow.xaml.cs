using BE;
using BL;
using System;
using System.Windows;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for testUpdateWindow.xaml
    /// </summary>
    public partial class testUpdateWindow : Window
    {
        IBL bl = FactoryBL.GetInstance();
        BE.Test testcontrol = new BE.Test();
        public testUpdateWindow(Test test)
        {
            testcontrol = test;
            InitializeComponent();
            testUpdateGrid.DataContext = testcontrol;
            par1.ItemsSource = Enum.GetValues(typeof(Rating));
            par2.ItemsSource = Enum.GetValues(typeof(Rating));
            par3.ItemsSource = Enum.GetValues(typeof(Rating));
            par4.ItemsSource = Enum.GetValues(typeof(Rating));
            par5.ItemsSource = Enum.GetValues(typeof(Rating));
            par6.ItemsSource = Enum.GetValues(typeof(Rating));
            par7.ItemsSource = Enum.GetValues(typeof(Rating));
            par8.ItemsSource = Enum.GetValues(typeof(Rating));
            par9.ItemsSource = Enum.GetValues(typeof(Rating));
        }

        private void Submit_test(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateTestOnFinish(testcontrol);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "ERROR!");
                return;
            }
            this.Close();
        }
    }
}
