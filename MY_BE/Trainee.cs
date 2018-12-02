using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    public class Trainee
    {
        public Trainee()
        {
            TestDay = DateTime.MinValue;
        }
        public int id;
        public string FamilyName;
        public string PrivateName;
        public DateTime BirthDate;
        public Gender TraineeGender;
        public string PhoneNumber;
        public Adress TraineeAdress;
        public VehicleType TraineeVahicle;
        public GearBox TraineeGearbox;
        public string DrivingSchool;
        public string TeacherName;
        public int DrivingLessonsNumber;
        public DateTime TestDay;
        public string ToString()
        {
            return "";
        }
    }
}
