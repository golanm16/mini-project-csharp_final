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
        public int id { get; set; }
        public string FamilyName { get; set; }
        public string PrivateName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender TraineeGender { get; set; }
        public string PhoneNumber { get; set; }
        public Adress TraineeAdress { get; set; }
        public VehicleType TraineeVehicle { get; set; }
        public GearBox TraineeGearbox { get; set; }
        public string DrivingSchool { get; set; }
        public string TeacherName { get; set; }
        public int DrivingLessonsNumber { get; set; }
        public DateTime TestDay { get; set; }
        public bool passedTheTest { get; set; }
        public string ToString()
        {
            return "";
        }
    }
}
