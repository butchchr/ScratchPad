using System;
using System.Linq;

namespace HackerRankForMW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Notification checker for HackerRank");
            var testCase1 = new int[] { 10, 20, 30, 40, 50 };
            var testD = 3;

            Console.WriteLine(ActivityNotifications(testCase1, testD));
            Console.ReadKey();
        }

        static int ActivityNotifications(int[] expenditure, int d)
        {
            var notifications = 0;
            var trailingDaysToCheck = new int[d];

            //notification logic
            for (var i = 0; i < expenditure.Length - d; i++)
            {
                Array.ConstrainedCopy(expenditure, i, trailingDaysToCheck, 0, d);
                var trailingDaysInOrder = trailingDaysToCheck.OrderBy(num => num).ToArray();
                var dailyMedian = GetMedianValue(trailingDaysInOrder, d);
                if (expenditure[i + d] >= dailyMedian * 2)
                {
                    notifications++;
                }
            }
            return notifications;
        }

        //establishes median value
        static decimal GetMedianValue(int[] trailingDaysInOrder, int d)
        {
            var middleDay = trailingDaysInOrder[d / 2];
            decimal dailyMedian;
            if (d % 2 == 0)
            {
                dailyMedian = (middleDay + (middleDay - 1)) / 2M;
            }
            else
            {
                dailyMedian = middleDay;
            }
            return dailyMedian;
        }
    }
}
