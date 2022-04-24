using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Business.SchedulecJobs
{
    public static class DateTimeExtensions
    {
        public static TimeSpan CalculateDifference(this DateTime endDate, DateTime startDate) =>
            new DateTime(endDate.Year, endDate.Month, endDate.Day) -
            new DateTime(startDate.Year, startDate.Month, startDate.Day);

        public static DateTime ConvertToYearMonthDayFormat(this DateTime @this) => new(@this.Year, @this.Month, @this.Day);
    }
}