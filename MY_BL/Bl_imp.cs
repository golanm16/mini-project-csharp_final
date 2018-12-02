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

            bool canDoTest=true;
            foreach(var item in getAllTrainees())
            {
                if (item.id == test.TraineeId)
                {
                    if ((test.TestDateTime-item.TestDay).TotalDays<=7)
                    {
                        canDoTest = false;
                    }
                    if(item.DrivingLessonsNumber<20)
                    {
                        canDoTest = false;
                    }
                    break;
                }
            }
            foreach(var item in getAllTesters())
            {
                if (item.MaxWeeklyTests <= item.weekdays.currentWeeklyTests)
                {
                    canDoTest = false;
                }
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
