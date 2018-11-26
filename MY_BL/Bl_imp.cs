using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BL
{
    class Bl_imp
    {
        void addTester(MY_BE.Tester tester)
        {
            int testerBirthYear=int.Parse(tester.BirthDate.Year.ToString());
            int currentYear = int.Parse(DateTime.Now.Year.ToString());
            if (currentYear - testerBirthYear > 40)
            {
                MY_DAL.Dal_imp.addTester(tester);
            }
        }
        void removeTester(MY_BE.Tester tester)
        {

        }
        void updateTester(MY_BE.Tester tester)
        {

        }
        void addTrainee(MY_BE.Trainee trainee)
        {

        }
        void removeTrainee(MY_BE.Trainee trainee)
        {

        }
        void updateTrainee(MY_BE.Trainee trainee)
        {

        }
        void addTest(MY_BE.Test test)
        {

        }
        void updateTestOnFinish(MY_BE.Test test)
        {

        }
        List<MY_BE.Tester> getAllTesters()
        {

        }
        List<MY_BE.Trainee> getAllTrainees()
        {

        }
        List<MY_BE.Test> getAllTests()
        {

        }
    }
}
