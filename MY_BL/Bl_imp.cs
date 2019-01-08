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
        Idal d = FactoryDal.GetInstance();//my idal to work with
        public void addTester(Tester tester)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - tester.BirthDate.Year;
            if (tester.BirthDate > today.AddYears(-1*age))
            {
                age--;
            }
            if (age >= Configuration.MIN_TESTER_AGE)
            {
                d.addTester(tester);
            }
            else
            {
                throw new Exception("tried to insert tester younger than 40");
            }
        }
        public void removeTester(MY_BE.Tester tester)
        {
            bool tester_exists = false;
            foreach(Tester item in getAllTesters())
            {
                if (item.id == tester.id)
                {
                    tester_exists = true;
                    d.removeTester(tester);
                }
            }
            if (!tester_exists)
            {
                throw new Exception("tried removing a tester not in database");
            }
        }
        public void updateTester(MY_BE.Tester tester)
        {
            bool tester_exists = false;
            foreach (Tester item in getAllTesters())
            {
                if (item.id == tester.id)
                {
                    tester_exists = true;
                    if (item.BirthDate == tester.BirthDate && item.TesterGender == tester.TesterGender)
                    {
                        d.updateTester(tester);
                    }
                    else
                    {
                        throw new Exception("cant change birth date & gender");
                    }
                }
            }
            if (!tester_exists)
            {
                throw new Exception("tried updating a tester not in database");
            }
        }
        public void addTrainee(MY_BE.Trainee trainee)
        {
            int traineeBirthYear = int.Parse(trainee.BirthDate.Year.ToString());
            int currentYear = int.Parse(DateTime.Now.Year.ToString());
            if (currentYear - traineeBirthYear > Configuration.MIN_TRAINEE_AGE)
            {
                d.addTrainee(trainee);
            }
            else throw new Exception("tried to insert trainee younger than 18");
        }
        public void removeTrainee(MY_BE.Trainee trainee)
        {
            bool trainee_exists = false;
            foreach (Trainee item in getAllTrainees())
            {
                if (item.id == trainee.id)
                {
                    trainee_exists = true;
                    d.removeTrainee(trainee);
                }
            }
            if (!trainee_exists)
            {
                throw new Exception("tried removing a trainee not in database");
            }
        }
        public void updateTrainee(MY_BE.Trainee trainee)
        {
            bool trainee_exists = false;
            foreach (Trainee item in getAllTrainees())
            {
                if (item.id == trainee.id)
                {
                    trainee_exists = true;
                    if (item.BirthDate == trainee.BirthDate && item.TraineeGender == trainee.TraineeGender)
                    {
                        d.updateTrainee(trainee);
                    }
                    else
                    {
                        throw new Exception("cant change birth date & gender");
                    }
                }
            }
            if (!trainee_exists)
            {
                throw new Exception("tried updating a trainee not in database");
            }
        }
        public void addTest(MY_BE.Test test)
        {

            bool canDoTest = true;
            string exception = "";
            Trainee newTrainee = new Trainee();
            Tester newTester = new Tester();
            foreach (var item in getAllTrainees())//check if trainee is valid for test
            {
                if (item.id == test.TraineeId)
                {
                    newTrainee = item;
                    if (item.TraineeVehicle!=test.TraineeVehicle)
                    {
                        canDoTest = false;
                        exception+="The Trainee is tested on other vehicles\n";
                    }//trainee vehicle is the same as test vehicle
                    else if (item.TraineeVehicle == test.TraineeVehicle && item.passedTheTest==true)
                    {
                        canDoTest = false;
                        exception += "The Trainee has already passed the test\n";
                    }//if the trainee already passed the test
                    if ((test.TestDateTime - item.TestDay).TotalDays <= Configuration.TEST_TO_TEST_TIME_RANGE)
                    {
                        canDoTest = false;
                        exception+="you need to wait 7 days between tests\n";
                    }//a week between the last test and current test
                    if (item.DrivingLessonsNumber < Configuration.MIN_CLASS_NUM)
                    {
                        canDoTest = false;
                        exception+="atleast 20 lessons required to make a test\n";
                    }//check if the trainee did less than 20 lessons
                    break;//only one student with matching id in the list
                }
            }
            //var arr = getAllTesters().Where(x => x.weekdays[test.TestDateTime.DayOfWeek, test.TestDateTime.Hour]);
            
            foreach (var item in getAllTesters())
            {
                canDoTest = true;
                if (!item.weekdays[test.TestDateTime.DayOfWeek, test.TestDateTime.Hour])
                {
                    canDoTest = false;
                    /*try
                    {
                        //item.nextAvailableTest();
                    }
                    catch(Exception e)
                    {
                        exception += "the selected hour is already taken.\n" + e.Message;
                    }*/
                }//check if the test hour is not taken
                if (item.MaxWeeklyTests <= item.weekdays.currentWeeklyTests)
                {
                    canDoTest = false;
                    exception += "passed the max number of tests this week\n";
                }//check if the tester passed the max weekly tests 
                if (newTrainee.TraineeVehicle!=item.TesterVehicle)
                {
                    canDoTest = false;
                    exception += "The tester can test on another type of vehicle";
                }//check if the tester test on the trainee vehicle
                if (canDoTest)
                {
                    newTester = item;
                    test.TesterId = item.id;
                    break;
                }//if the tester is available for testing assign the tester for the test
            }//look for available tester

            if (canDoTest)
            {
                d.addTest(test);
                newTrainee.TestDay = test.TestDate;
                newTester.weekdays[test.TestDate.DayOfWeek, test.TestDateTime.Hour] = false;
                newTester.weekdays.currentWeeklyTests++;
            }
        }
        public void updateTestOnFinish(MY_BE.Test test)
        {
            bool canupdatetest = true;
            bool testpassed = true;
            foreach(var item in test.TestParams)//check if all testparams was entered false\true
            {
                if (item.Value == null)
                {
                    canupdatetest = false;
                }
            }
            if (canupdatetest)
            {
                d.updateTestOnFinish(test);
            }
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
        public List<Tester> getNearbyTesters(Adress ad,double x)
        {
            List<Tester> tlist=new List<Tester>();
            double distance = 4;
            foreach(Tester t in getAllTesters())
            {
                //enter gmaps distance to distance
                if (distance <= x)
                {
                    tlist.Add(t);
                }
            }
            return tlist;
        }
        public List<Tester> getTestersAtHour(DateTime dt)
        {
            List<Tester> tlist = new List<Tester>();
            foreach (var item in getAllTesters())
            {
                if (item.weekdays[dt.DayOfWeek, dt.Hour])
                {
                    tlist.Add(item);
                }
            }
            return tlist;
        }
        public List<Test> testsCheck(Func<Test,bool> func)
        {
            List<Test> tlist = new List<Test>();
            var testWithCondition = from item in getAllTests()
                                    where func(item)
                                    select item;
            return testWithCondition.ToList();
        }//return all the tests that return true for the delegates checks
        public int numOfTests(Trainee trainee)
        {
            int sum = 0;
            foreach(Test item in getAllTests())
            {
                if (item.TraineeId == trainee.id)
                {
                    sum++;
                }
            }
            return sum;
        }
        public bool passedTheTest(Trainee trainee)
        {
            return trainee.passedTheTest;
        }
        public List<Test> testsOnDate(DateTime dt)
        {
            List < Test > tlist= new List<Test>();

            var results = from item in getAllTests()
                          where (dt.Month == item.TestDate.Month && dt.Day == item.TestDate.Day)
                          select item;
            foreach (Test item in results)
            {
                tlist.Add(item);
            }
            return tlist;
        }
        public List<Tester> groupByVehicleType()
        {
            List<Tester> tlist = new List<Tester>();
            var results = getAllTesters().GroupBy(item => item.TesterVehicle);
            /*var results2 = from item in getAllTests()
                          group item by item.TraineeVehicle;
            */
            foreach (IGrouping<VehicleType,Tester> group in results)
            {
                //tlist.AddRange(group);
                foreach(Tester item in group)
                {
                    tlist.Add(item);
                }
            }
            return tlist;
        }
        public List<Trainee> groupByDrivingSchool()
        {
            List<Trainee> tlist = new List<Trainee>();
            var results = getAllTrainees().GroupBy(item => item.DrivingSchool);
            foreach(IGrouping<string,Trainee> group in results)
            {
                foreach(Trainee item in group)
                {
                    tlist.Add(item);
                }
            }
            return tlist;
        }
        public List<Trainee> groupByTester()
        {
            List<Trainee> tlist = new List<Trainee>();
            var results = getAllTrainees().GroupBy(item => item.TeacherName);
            foreach (IGrouping<string, Trainee> group in results)
            {
                foreach (Trainee item in group)
                {
                    tlist.Add(item);
                }
            }
            return tlist;
        }
        public List<Trainee> groupByTestsNumber()
        {
            List<Trainee> tlist = new List<Trainee>();
            var results = getAllTrainees().GroupBy(item => item);//**need to make tests number field in trainee
            foreach (IGrouping<string, Trainee> group in results)
            {
                foreach (Trainee item in group)
                {
                    tlist.Add(item);
                }
            }
            return tlist;
        }
        public void addmyTrainees()
        {

            int i, y = -19, num = 25, phone = 0500000000, hnum = 18;
            string name = "n", school = "s";
            DateTime dt = DateTime.Now.AddYears(y);
            for (i = 0; i < 10; i++)
            {
                Trainee trainee = new Trainee();
                trainee.PrivateName = name += "a";
                trainee.FamilyName = name += "b";
                trainee.BirthDate = dt.AddYears(y--);
                trainee.DrivingLessonsNumber = num += 2;
                trainee.DrivingSchool = school += "a";
                trainee.id = i;
                trainee.PhoneNumber = (phone += 465).ToString("0000000000");
                trainee.TraineeAdress.City = "jerusalem";
                trainee.TraineeAdress.Street = "havaad hleumi";
                trainee.TraineeAdress.HouseNumber = hnum++;
                trainee.TraineeGearbox = GearBox.Automatic;
                trainee.TraineeGender = Gender.Male;
                trainee.TraineeVehicle = VehicleType.PrivateVehicle;
                try
                {
                    addTrainee(trainee);
                }
                catch (Exception e) { }
            }
        }
        public void addmyTesters()
        {

            int i, y = -41, num = 15, phone = 0520000000, hnum = 18 ,s=10;
            string name = "t";
            DateTime dt = DateTime.Now.AddYears(y);
            for (i = 0; i < 10; i++)
            {
                Tester tester = new Tester();
                tester.PrivateName = name += "a";
                tester.FamilyName = name += "b";
                tester.BirthDate = dt.AddYears(y--);
                tester.MaxDistance = num += 2;
                tester.id = i;
                tester.PhoneNumber = (phone += 236).ToString("0000000000");
                tester.TesterAdress.City = "jerusalem";
                tester.TesterAdress.Street = "bait vagan";
                tester.TesterAdress.HouseNumber = hnum++;
                tester.TesterGender = Gender.Male;
                tester.TesterVehicle = VehicleType.PrivateVehicle;
                tester.MaxWeeklyTests = hnum += 3;
                tester.Seniority = s++;
                try
                {
                    addTester(tester);
                }
                catch (Exception e) { }
            }
        }
        public void addmytests()
        {
            int i,hn=40,teid=10,trid=0;
            for (i = 0; i < 5; i++)
            {
                Test test = new Test();
                test.TestAdress.City = "j-city";
                test.TestAdress.Street = "yafo";
                test.TestAdress.HouseNumber = hn += 4;
                test.TestDate = new DateTime(2019,01,15,12,30,0);
                test.TestDateTime = test.TestDate;
                test.TesterId = teid--;
                test.TraineeId = trid++;
                test.TraineeVehicle = VehicleType.PrivateVehicle;
                try
                {
                    addTest(test);
                }
                catch (Exception e) { }
            }
        }
    }

}
