using System.Collections.Generic;
namespace DAL
{
    public class Dal_imp : Idal
    {
        public Dal_imp()
        {
            DS.DataSource.testersList = new List<BE.Tester>();
            DS.DataSource.testsList = new List<BE.Test>();
            DS.DataSource.traineesList = new List<BE.Trainee>();
        }
        public int testid;
        public void addTester(BE.Tester tester)
        {
            DS.DataSource.testersList.Add(tester);
        }
        public void removeTester(BE.Tester tester)
        {
            DS.DataSource.testersList.Remove(tester);
        }
        public void updateTester(BE.Tester tester)
        {
            BE.Tester t = new BE.Tester();
            foreach (BE.Tester item in DS.DataSource.testersList)
            {
                if (item.id == tester.id)
                {
                    t = item;

                    break;
                }
            }
            DS.DataSource.testersList.Remove(t);
            DS.DataSource.testersList.Add(tester);
        }
        public void addTrainee(BE.Trainee trainee)
        {
            DS.DataSource.traineesList.Add(trainee);
        }
        public void removeTrainee(BE.Trainee trainee)
        {
            DS.DataSource.traineesList.Remove(trainee);
        }
        public void updateTrainee(BE.Trainee trainee)
        {
            BE.Trainee t = new BE.Trainee();
            foreach (BE.Trainee item in DS.DataSource.traineesList)
            {
                if (item.id == trainee.id)
                {
                    t = item;
                    break;
                }
            }
            DS.DataSource.traineesList.Remove(t);
            DS.DataSource.traineesList.Add(trainee);
        }

        public void addTest(BE.Test test)
        {

            DS.DataSource.testsList.Add(test);
        }
        public void updateTestOnFinish(BE.Test test)
        {
            BE.Test t = new BE.Test();
            foreach (BE.Test item in DS.DataSource.testsList)
            {
                if (item.TestNumber == test.TestNumber)
                {
                    t = item;
                    break;
                }
            }
            DS.DataSource.testsList.Remove(t);
            DS.DataSource.testsList.Add(test);
        }
        public List<BE.Tester> getAllTesters()
        {
            return DS.DataSource.testersList;
        }    //**need to return a copy. not areference that can change the source
        public List<BE.Trainee> getAllTrainees()
        {
            return DS.DataSource.traineesList;
        }  //**need to return a copy. not areference that can change the source
        public List<BE.Test> getAllTests()
        {
            return DS.DataSource.testsList;
        }        //**need to return a copy. not areference that can change the source
    }
}
