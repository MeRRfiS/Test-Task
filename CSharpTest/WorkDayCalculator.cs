using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            int count = 0;
            int duration = 0;
            bool isWeekend = false;
            DateTime resultTime = startDate;
            while (count < dayCount)
            {
                isWeekend = false;
                resultTime = startDate.AddDays(duration);
                try
                {
                    foreach (var weekEnd in weekEnds)
                    {
                        int days = (weekEnd.EndDate - weekEnd.StartDate).Days;
                        for (int i = 0; i <= days; i++)
                            if (resultTime == weekEnd.StartDate.AddDays(i))
                            {
                                isWeekend = true;
                                break;
                            }
                        if (isWeekend)
                            break;
                    }
                }
                catch (Exception)
                {
                }
                if (!isWeekend)
                    count++;
                duration++;
            }
            return resultTime;
        }
    }
}
