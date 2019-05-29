﻿using System;
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
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            
        }
    }
}
