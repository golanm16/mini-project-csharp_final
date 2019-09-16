using BE;
using BL;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for RemoveWindow.xaml
    /// </summary>
    public partial class RemoveWindow : Window
    {
        IBL bl = FactoryBL.GetInstance();
        public RemoveWindow(object obj)
        {
            InitializeComponent();
            if (obj.GetType() == new Tester().GetType())
            {
                removeButton.Content = "remove tester";
                removeButton.Click += removeTester_Click;
            }
            else
            if (obj.GetType() == new Trainee().GetType())
            {
                removeButton.Content = "remove trainee";
                removeButton.Click += removeTrainee_Click;
            }
        }
        private void removeTester_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(idbox.Text, out id))
            {
                Tester tester = new Tester();
                tester = bl.getAllTesters().Where(x => x.id == id).FirstOrDefault();
                if (tester == null)
                {
                    MessageBox.Show("tester id does not exist!");
                    return;
                }
                try
                {
                    bl.removeTester(tester);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                MessageBox.Show("must enter a number");
            }
            this.Close();
        }
        private void removeTrainee_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(idbox.Text, out id))
            {
                Trainee trainee = new Trainee();
                trainee = bl.getAllTrainees().Where(x => x.id == id).FirstOrDefault();
                if (trainee == null)
                {
                    MessageBox.Show("trainee id does not exist!");
                    return;
                }
                try
                {
                    bl.removeTrainee(trainee);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                MessageBox.Show("must enter a number");
            }
            this.Close();
        }

        private void idbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (removeButton.Content.ToString() == "remove tester")
                {
                    removeTester_Click(sender, new RoutedEventArgs());
                }
                else if (removeButton.Content.ToString() == "remove trainee")
                {
                    removeTrainee_Click(sender, new RoutedEventArgs());
                }
            }
        }
    }
}
