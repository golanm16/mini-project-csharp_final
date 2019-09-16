using System.Collections.Generic;

namespace DAL
{
    public interface Idal
    {//פונקציות בוליאניות בשביל לבדוק שההכנסה עבדה??
        void addTester(BE.Tester tester);
        void removeTester(BE.Tester tester);
        void updateTester(BE.Tester tester);
        void addTrainee(BE.Trainee trainee);
        void removeTrainee(BE.Trainee trainee);
        void updateTrainee(BE.Trainee trainee);
        void addTest(BE.Test test);
        void updateTestOnFinish(BE.Test test);
        List<BE.Tester> getAllTesters();
        List<BE.Trainee> getAllTrainees();
        List<BE.Test> getAllTests();
    }
}
