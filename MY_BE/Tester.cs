using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    /*public class Day
    {
        bool[] hour;
        public Day()
        {
            hour = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                hour[i] = true;
            }
        }
        public bool this[int realHour]
        {
            get=> hour[realHour - 9];
            set=> hour[realHour - 9]=value;
        }
    }*/
    public class Schedule
    {
        /*Dictionary<DayOfWeek, Day> week;
        Schedule()
        {
            for (int i = 1; i <= 7; i++)
            {
                
                week.Add(, d);
            }
        }
        public Day this[DayOfWeek d]
        {
            get
            {
                return week[d];
            }
        }*/
        bool[,] week;
        public int currentWeeklyTests;
        Schedule()
        {
            week = new bool[7, 6];
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    week[i, j] = true;
                }
            }
            currentWeeklyTests = 0;
        }
        public bool this[DayOfWeek dof, int h]
        {
            get
            {
                return week[(int)dof, h - 9];
            }
            set
            {
                week[(int)dof, h - 9]=value;
            }
        }
        
        
    }
        public class Tester
    {
        public int id { get; set; }
        public string FamilyName { get; set; }
        public string PrivateName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender TesterGender { get; set; }
        public string PhoneNumber { get; set; }
        public Adress TesterAdress { get; set; }
        public int Seniority { get; set; }
        public int MaxWeeklyTests { get; set; }   //maybe const?
        public VehicleType TesterVehicle { get; set; }
        public int MaxDistance { get; set; }
        public Schedule weekdays { get; set; }
        public string ToString()
        {
            return "";
        }
    }
}
