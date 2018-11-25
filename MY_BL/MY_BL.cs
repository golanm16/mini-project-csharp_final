using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_BL
{
    public class MyBl
    {
        MY_DAL.MyDal dal;

        public MyBl()
        {
            dal = new MY_DAL.MyDal();
        }

        public string getResult()
        {
            return "result is:" + dal.getValue();
        }
    }
}
