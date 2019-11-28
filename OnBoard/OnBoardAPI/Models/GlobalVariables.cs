using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class GlobalVariables
    {
        public static int loggedInCounter = 1;
        public static void IncrementLoggedCount()
        {
            loggedInCounter++;
        }
    }
}
