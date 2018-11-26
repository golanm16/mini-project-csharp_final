using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_DAL
{
    public interface Idal
    {//פונקציות בוליאניות בשביל לבדוק שההכנסה עבדה
        bool addTester(MY_BE.Tester tester);
    } 
}
