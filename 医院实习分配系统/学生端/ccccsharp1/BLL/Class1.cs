using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Class1
    {
        public bool select(Model.Users user)
        {
            DAL.Class1 d_user = new DAL.Class1();
            bool result = d_user.select(user);
            return result;
        }

        public bool select1(Model.Users user)
        {
            DAL.Class1 d_user1 = new DAL.Class1();
            bool result1 = d_user1.select1(user);
            return result1;
        }


    }
}
