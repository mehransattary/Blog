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
        public static string RandomChars()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
 
}