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
            BoolTestParams = new Dictionary<string, bool?>();
            TestParams = new Dictionary<string, Rating>();
            TraineeVehicle = VehicleType.PrivateVehicle;
            TestNumber = "0";
            TesterId = 0;
            TraineeId = 0;
            TestDate = new DateTime(2019,01,23,12,0,0);
            TestDateTime= new DateTime(2019, 01, 23, 12, 0, 0);
            TestAdress = new Adress();
            TesterNote = "tester note here.";
            BoolTestParams.Add("stopped?", null);//add parameters to check if the trainee drove carefuly
            TestParams.Add("distance?", 0);
            TestParams.Add("mirrors?", 0);
            TestParams.Add("turn signals?", 0);
            TestParams.Add("parking?", 0);
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
        public string TestNumber { get; set; }
        public int TesterId { get; set; }
        public int TraineeId { get; set; }
        public DateTime TestDate { get; set; }//לכאורה מיותר רצח!
        public DateTime TestDateTime { get; set; }
        public Adress TestAdress { get; set; }
        public Dictionary<string,Rating> TestParams { get; set; }//make a lot of those!
        public Dictionary<string, bool?> BoolTestParams { get; set; }
        //params for careful driving, stopping at stop sign,etc...

        public string TesterNote { get; set; }
        public string ToString()
        {
            return "";
        }
    }
}
