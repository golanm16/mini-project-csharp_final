using BE;
using BL;
using System;
using System.Windows;
using System.Windows.Input;
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
            Closing += On_Closed;
            tests_list.ItemsSource = bl.getAllTests();
        }
        private void On_Closed(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void add_tester(object sender, RoutedEventArgs e)
        {
            AddTester mytester = new AddTester();
            mytester.ShowDialog();
            testers_list.Items.Refresh();
        }//call the add tester window
        private void add_trainee(object sender, RoutedEventArgs e)
        {
            addTrainee addtrainee = new addTrainee();
            addtrainee.ShowDialog();
            trainees_list.Items.Refresh();
        }//call the add trainee window
        private void add_test(object sender, RoutedEventArgs e)
        {
            addTest addtest = new addTest();
            addtest.ShowDialog();
            tests_list.Items.Refresh();
        }//call the add test window
        private void add_tests(object sender, MouseButtonEventArgs e)
        {
            tests_list.ItemsSource = bl.getAllTests();
        }//refreshing the tab
        private void add_trainees(object sender, MouseButtonEventArgs e)
        {
            trainees_list.ItemsSource = bl.getAllTrainees();
        }//refreshing the tab
        private void add_testers(object sender, MouseButtonEventArgs e)
        {
            testers_list.ItemsSource = bl.getAllTesters();
        }//refreshing the tab
        private void Remove_tester(object sender, RoutedEventArgs e)
        {
            RemoveWindow rw = new RemoveWindow(new Tester());
            rw.ShowDialog();
            testers_list.Items.Refresh();
        }
        private void Remove_trainee(object sender, RoutedEventArgs e)
        {
            RemoveWindow rw = new RemoveWindow(new Trainee());
            rw.ShowDialog();
            trainees_list.Items.Refresh();
        }
    }
}
