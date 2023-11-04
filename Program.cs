
using System;
using System.Text;

namespace pr4
{
    public interface IComparable
    {
        int CompareTo(object obj);
    }

    class Date: IComparable<Date>
    {
        private int day;
        public int Day
        {
            get { return day; }
            set
            {
                if (value >= 1 && value <= 31)
                {
                    day = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("День должен быть в диапазоне от 1 до 31.");
                }
            }
        }

        private int month;
        public int Month
        {
            get { return month; }
            set
            {
                if (value >= 1 && value <= 12)
                {
                    month = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Месяц должен быть в диапазоне от 1 до 12.");
                }
            }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
            }
        }

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int CompareTo(Date other)
        {
            if (other == null)
            {
                return 1;
            }

            if (Year != other.Year)
            {
                return Year.CompareTo(other.Year);
            }

            if (Month != other.Month)
            {
                return Month.CompareTo(other.Month);
            }

            return Day.CompareTo(other.Day);
        }
    }


    internal class Program
    {

        static void Part1()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 4;


            var nMonths = from m in months
                           where m.Length == n
                          select m;

            Console.WriteLine($"Месяцы длинной {n}:");
            foreach(var mounth in nMonths)
                Console.WriteLine(mounth);

            var sumWintMon = from m in months
                             where m == "June" || m == "July" || m == "December" || m == "January" || m == "February" || m == "August"
                             select m;
            
            Console.WriteLine("\nЛетнии и зимнии месяцы:");
            foreach (var mounth in sumWintMon)
                Console.WriteLine(mounth);

            var monthsInAlphabeticalOrder = from m in months
                                            orderby m
                                            select m;

            Console.WriteLine("\nМесяцы в алфавитном порядке:");
            foreach (var month in monthsInAlphabeticalOrder)
                Console.WriteLine(month);

            Console.WriteLine("\nКол-во месяцев, содержащие букву «u» и длиной имени не менее 4-х:");
            var monthsWithUAndLength4Plus = from m in months
                                            where m.Contains("u") && m.Length >= 4
                                            select m;
            Console.WriteLine(monthsWithUAndLength4Plus.Count());

        }

        static void Part2_4()
        {
            List<Date> date = new List<Date>()
            {
                new Date(31,4,2001),
                new Date(11,12,2001),
                new Date(14,3,1967),
                new Date(1,8,2022),
                new Date(11,12,1567),
            };

            int searchYear = 2001;
            int searchMonth = 12;
            int searchDay = 11;

            var startDate = new Date(1, 1, 1);
            var endDate = new Date(31, 12, 1990);


            var sYear = from d in date
                        where d.Year == searchYear
                        select d;
            Console.WriteLine($"\nСписок дат для {searchYear} года");
            foreach (var dates in sYear)
                Console.WriteLine($"{dates.Day}:{dates.Month}:{dates.Year}");


            var sMonth = from d in date
                        where d.Month == searchMonth
                        select d;
            Console.WriteLine($"\nСписок дат для {searchMonth} месяца");
            foreach (var dates in sMonth)   
                Console.WriteLine($"{dates.Day}:{dates.Month}:{dates.Year}");


            var countInRange = from d in date
                               where ((d.Year+d.Month+d.Day) > (startDate.Year + startDate.Month + startDate.Day)) && ((d.Year + d.Month + d.Day) < (endDate.Year + endDate.Month + endDate.Day))
                               select d;

            Console.WriteLine($"\nКоличество дат в определенном диапазоне: {countInRange.Count()}");


            var maxDate = (from d in date
                          where d.Day == searchDay
                          select d).Max();
            Console.WriteLine($"\nМаксимальная дата для {searchDay}: {maxDate.Day}:{maxDate.Month}:{maxDate.Year}");


            var orderedDates = from d in date
                               orderby d
                               select d;
            Console.WriteLine("\nУпорядоченные даты:");
            foreach(var dates in orderedDates)
            {
                Console.WriteLine($"{dates.Day}:{dates.Month}:{dates.Year}");
            }

        }

        static void Main(string[] args)
        {
            //Part1();
            Part2_4();
        }
    }
}