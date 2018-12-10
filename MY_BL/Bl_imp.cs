using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY_BE;
using MY_DAL;
namespace MY_BL
{
    public class Bl_imp:IBL
    {
        Idal d = new Dal_imp();
        public void addTester(MY_BE.Tester tester)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - tester.BirthDate.Year;
            if (tester.BirthDate > today.AddYears(-1*age))
            {
                age--;
            }
            if (age>=40)
            {
                d.addTester(tester);
            }
            else throw new Exception("tried to insert tester younger than 40");
        }
        public void removeTester(MY_BE.Tester tester)
        {

        }
        public void updateTester(MY_BE.Tester tester)
        {

        }
        public void addTrainee(MY_BE.Trainee trainee)
        {
            int traineeBirthYear = int.Parse(trainee.BirthDate.Year.ToString());
            int currentYear = int.Parse(DateTime.Now.Year.ToString());
            if (currentYear - traineeBirthYear > 18)
            {
                d.addTrainee(trainee);
            }
            else throw new Exception("tried to insert trainee younger than 18");
        }
        public void removeTrainee(MY_BE.Trainee trainee)
        {

        }
        public void updateTrainee(MY_BE.Trainee trainee)
        {

        }
        public void addTest(MY_BE.Test test)
        {

            bool canDoTest = true;
            // Trainee newTrainee = new Trainee(); // בשביל הבדיקה השנייה שהייתי צריך לעשות
            foreach (var item in getAllTrainees())
            {

                if (item.id == test.TraineeId)
                {
                    /*newTrainee = item;// בשביל הבדיקה הראשונה שהייתי צריך לעשות
                    if (item.TraineeVahicle!=test.TraineeVahicle)
                    {
                        canDoTest = false;
                        throw new Exception("The Trainee is tested on other vehicles");
                    }
                    else if (item.TraineeVahicle == test.TraineeVahicle&& item.pastTheTest==true)
                    {
                        canDoTest = false;
                        throw new Exception("The Trainee has already passed the test");
                    }*/
                    if ((test.TestDateTime - item.TestDay).TotalDays <= 7)
                    {
                        canDoTest = false;
                    }
                    if (item.DrivingLessonsNumber < 20)
                    {
                        canDoTest = false;
                    }
                    break;
                }

            }
            foreach (var item in getAllTesters())
            {
                if (!item.weekdays[test.TestDateTime.DayOfWeek, (int)test.TestDateTime.Hour])
                {
                    canDoTest = false;
                }
                if (item.MaxWeeklyTests <= item.weekdays.currentWeeklyTests)
                {
                    canDoTest = false;
                }
                /*  if (newTrainee.TraineeVahicle!=item.TesterVehicle)// בשביל הבדיקה השנייה שהייתי צריך לעשות
                  {
                      canDoTest = false;
                      throw new Exception("The tester can test on another type of vehicle");
                  }*/
            }

            if (canDoTest)
            {
                d.addTest(test);
            }
        }
        public void updateTestOnFinish(MY_BE.Test test)
        {

        }
        public List<MY_BE.Tester> getAllTesters()
        {
            return d.getAllTesters();
        }
        public List<MY_BE.Trainee> getAllTrainees()
        {
            return d.getAllTrainees();
        }
        public List<MY_BE.Test> getAllTests()
        {
            return d.getAllTests();
        }
    
    }
}
