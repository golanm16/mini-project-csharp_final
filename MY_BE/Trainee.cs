using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BE
{
    class Trainee
    {
        int id;
        string FamilyName;
        string PrivateName;
        DateTime BirthDate;
        Gender TraineeGender;
        string PhoneNumber;
        Adress TraineeAdress;
        VehicleType TraineeVahicle;
        GearBox TraineeGearbox;
        string DrivingSchool;
        string TeacherName;
        int DrivingLessonsNumber;
        public string ToString()
        {
            return "hi my name is";
        }
    }
}
