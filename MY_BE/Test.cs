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
        public VehicleType TraineeVahicle { get; set; }// בשביל הבדיקה הראשונה שהייתי צריך לעשות
        public int TestNumber { get; set; }
        public int TesterId { get; set; }
        public int TraineeId { get; set; }
        public DateTime TestDate { get; set; }
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
