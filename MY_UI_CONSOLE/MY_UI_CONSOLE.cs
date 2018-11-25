using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_UI_CONSOLE
{
    class MY_UI_CONSOLE
    {
        static MY_BL.MyBl bl = new MY_BL.MyBl();
        static void Main(string[] args)
        {
            Console.WriteLine(bl.getResult());
        }
    }
}
