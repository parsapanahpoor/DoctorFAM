using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Extensions
{
    public static class JobTimer
    {
        public static TimeSpan getScheduledParsedTime(this string jobStartTime)
        {
            string[] formats = { @"hh\:mm\:ss", "hh\\:mm" };
            TimeSpan.TryParseExact(jobStartTime, formats, CultureInfo.InvariantCulture, out TimeSpan ScheduledTimespan);
            return ScheduledTimespan;
        }

        public static TimeSpan getJobRunDelay(this string jobStartTime)
        {
            //job Start Time Must Be In This Correct Format ------- >>>>> "10::30"
            TimeSpan scheduledParsedTime = getScheduledParsedTime(jobStartTime);
            TimeSpan curentTimeOftheDay = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString("hh\\:mm"));
            TimeSpan delayTime = scheduledParsedTime >= curentTimeOftheDay
                ? scheduledParsedTime - curentTimeOftheDay
                : new TimeSpan(24, 0, 0) - curentTimeOftheDay + scheduledParsedTime;
            return delayTime;
        }
    }
}
