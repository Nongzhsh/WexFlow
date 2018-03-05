using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cancelation.Core
{
    public static class TimeHolder
    {
        static DateTime StartTime;

        public static void SetStartTime()
        {
            StartTime = DateTime.Now;
        }

        public static DateTime GetStartTime(DateTime definedDate)
        {
            return StartTime;
        }
    }
}
