using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    
    public class Test
    {
        public Test()
        {
            TraineeVehicle = VehicleType.PrivateVehicle;
            TestNumber = Configuration.TEST_ID++;
            TesterId = 0;
            TraineeId = 0;
            TestDate = DateTime.Now.AddYears(-1);
            TestDateTime= DateTime.Now.AddYears(-1);
            TestAdress.City = "Jerusalem";
            TestAdress.Street = "Ha-Va'ad ha-Le'umi";
            TestAdress.HouseNumber = 21;
            TesterNote = "tester note here.";
            TestParams.Add("stopped on red light", null);//add parameters to check if the trainee drove carefuly
            //TestParams.Add("", null);
            //TestParams.Add("", null);
            //TestParams.Add("", null);
            //TestParams.Add("", null);
            //TestParams.Add("", null);
            //TestParams.Add("", null);
            //TestParams.Add("", null);
            //TestParams.Add("", null);
        }
        public Test(Test copyTest)
        {
            TestNumber = copyTest.TestNumber;
            TesterId = copyTest.TesterId;
            TraineeId = copyTest.TraineeId;
            TestDate = copyTest.TestDate;
            TestDateTime = copyTest.TestDateTime;
            TraineeVehicle = copyTest.TraineeVehicle;
            TestAdress = copyTest.TestAdress;
            TesterNote = copyTest.TesterNote;
            TestParams = copyTest.TestParams;
        }
        public VehicleType TraineeVehicle { get; set; }// בשביל הבדיקה הראשונה שהייתי צריך לעשות
        public int TestNumber { get; set; }
        public int TesterId { get; set; }
        public int TraineeId { get; set; }
        public DateTime TestDate { get; set; }//לכאורה מיותר רצח!
        public DateTime TestDateTime { get; set; }
        public Adress TestAdress { get; set; }
        public Dictionary<string,bool?> TestParams { get; set; }//make a lot of those!
        //params for careful driving, stopping at stop sign,etc...

        public string TesterNote { get; set; }
        public string ToString()
        {
            return "";
        }
    }
}
