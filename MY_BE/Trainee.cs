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
        public Trainee(Trainee trainee)
        {
            id = trainee.id;
            FamilyName=trainee.FamilyName;
            PrivateName=trainee.PrivateName;
            BirthDate = trainee.BirthDate;
            TraineeGender = trainee.TraineeGender;
            PhoneNumber = trainee.PhoneNumber;
            TraineeAdress = trainee.TraineeAdress;
            TraineeVehicle = trainee.TraineeVehicle;
            TraineeGearbox = trainee.TraineeGearbox;
            DrivingSchool = trainee.DrivingSchool;
            TeacherName = trainee.TeacherName;
            DrivingLessonsNumber = trainee.DrivingLessonsNumber;
            TestDay = trainee.TestDay;
            passedTheTest = trainee.passedTheTest;
        }//copy constructor
        public int id;
        public string FamilyName;
        public string PrivateName;
        public DateTime BirthDate;
        public Gender TraineeGender;
        public string PhoneNumber;
        public Adress TraineeAdress;
        public VehicleType TraineeVehicle;
        public GearBox TraineeGearbox;
        public string DrivingSchool;
        public string TeacherName;
        public int DrivingLessonsNumber;
        public DateTime TestDay;
        public bool passedTheTest;
        public string ToString()
        {
            return "";
        }
    }
}
