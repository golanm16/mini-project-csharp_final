using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    public class Tester
    {
        public int id { get; set; }
        public string FamilyName;
        public string PrivateName;
        public DateTime BirthDate;
        public Gender TesterGender;
        public string PhoneNumber;
        public Adress TesterAdress;
        public int Seniority;
        public int MaxWeeklyTests;     //maybe const?
        public VehicleType TesterVehicle;
        //bool mat for work days in the week and hours
        int MaxDistance;
        public string ToString()
        {
            return "";
        }
    }
}
