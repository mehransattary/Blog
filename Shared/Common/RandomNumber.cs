using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public static class RandomNumber
    {
        public static int Random(int min=0,int max=0)
        {
            Random random = new Random();
            int mycode = random.Next((min!=0? min:10000),(max!=0?max: 9000000));
            return mycode;
        }
    }
}