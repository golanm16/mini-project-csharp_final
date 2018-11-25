using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    class Test
    {
        int _TestNumber=0;
        public string TestNumber
        {
            get { 
                _TestNumber++;
                _TestNumber.ToString("D8");
                }
        }
        string TesterId;
        string TraineeId;
        DateTime TestDate;
        DateTime TestDateTime;
        Adress TestAdress;
        bool TestParams;//make a lot of those!
        //params for careful driving, stopping at stop sign,etc...

        string TesterNote;
        public string ToString()
        {
            return "";
        }
    }
}
