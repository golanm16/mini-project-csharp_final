using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    public class Tester
    {
        int id;
        string FamilyName;
        string PrivateName;
        DateTime BirthDate;
        Gender TesterGender;
        string PhoneNumber;
        Adress TesterAdress;
        int Seniority;
        int MaxWeeklyTests;     //maybe const?
        VehicleType TesterVehicle;
        //bool mat for work days in the week and hours
        int MaxDistance;
        public string ToString()
        {
            return "";
        }
    }
}
