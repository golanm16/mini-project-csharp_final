﻿using BE;
using System;
using System.Collections.Generic;
namespace BL
{
    public interface IBL
    {
        void addTester(Tester tester);
        void removeTester(Tester tester);
        void updateTester(Tester tester);
        void addTrainee(Trainee trainee);
        void removeTrainee(Trainee trainee);
        void updateTrainee(Trainee trainee);
        void addTest(Test test);
        void updateTestOnFinish(Test test);
        List<Tester> getAllTesters();
        List<Trainee> getAllTrainees();
        List<Test> getAllTests();
        List<Tester> getNearbyTesters(Adress ad);
        List<Tester> getTestersAtHour(DateTime dt);
        int numOfTests(Trainee trainee);
        bool passedTheTest(Trainee trtrainee);
        List<Test> testsOnDate(DateTime dt);
        List<Tester> groupByVehicleType();
        List<Trainee> groupByDrivingSchool();
        List<Trainee> groupByTester();
        List<Trainee> groupByTestsNumber();
        /*void addmyTrainees();
        void addmyTesters();
        void addmytests();*/
    }
}
