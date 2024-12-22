using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LinqCode.Util;
using Microsoft.EntityFrameworkCore;

namespace LinqCode
{
    internal static class Extentions
    {
        public static IEnumerable<T> Diff<T>(this IEnumerable<T> list1, IEnumerable<T> list2, Func<T,T,bool> func)
        {
            var diff = list1.Where(x => !list2.Any(y => func(x, y))).ToList();
            return diff;
        }

        public static List<List<T>> ChunkList<T>(this IEnumerable<T> data, int chunkSize)
        {
            return data
              .Select((x, i) => new { Index = i, Value = x })
              .GroupBy(x => x.Index / chunkSize)
              .Select(x => x.Select(v => v.Value).ToList())
              .ToList();
        }

        public static DateTime PersianDateTime(this DateTime date)
        {
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            return persianDate;
        }

        public static string PersianDateTimeStr(this DateTime date)
        {
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            var result = persianDate.ToString("yyyy MMM ddd", CultureInfo.GetCultureInfo("fa-Ir"));
            return result;
        }

        public static long ToPersianDateTimeLongNumeric(this DateTime date)
        {
            date = GetPersianDate(date);
            if (Singleton<PersianCalendar>.Instance == null)
            {
                Singleton<PersianCalendar>.Instance = new PersianCalendar();
            }

            PersianCalendar instance = Singleton<PersianCalendar>.Instance;
            return long.Parse($"{instance.GetYear(date):0000}{instance.GetMonth(date):00}{instance.GetDayOfMonth(date):00}{instance.GetHour(date):00}{instance.GetMinute(date):00}{instance.GetSecond(date):00}{instance.GetMilliseconds(date):000}");
        }

        private static DateTime GetPersianDate(DateTime date)
        {
            date = date.ToUniversalTime();
            return TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time"));
        }
    }
}
