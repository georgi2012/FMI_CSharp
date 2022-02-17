using System;
using System.Collections.Generic;

namespace week9
{
    public class Program
    {//subscriber
        enum Subjects
        {
            CS,
            ENG,
            MAT
        }

        static void Main(string[] args)
        {
            List<Subject> list = new List<Subject>();
            string[] titles = { "CS", "Eng", "Math" };
            Random r = new Random();
            for (int i = 0; i < titles.Length; i++)
            {
                int[] grades = new int[Subject.MAX_GRADES];
                for (int j = 0; j < grades.Length; j++)
                {
                    grades[j] = r.Next(0, 150);
                }
                Subject sub = new Subject(grades, titles[i]);
                list.Add(sub);
            }
            StudentCardReport report = new StudentCardReport(list);
            report.Passing += OnPassing;//subscribe
            report.ProcessReport();//fire event
        }

        public static void OnPassing(object souce, EventArgs args)
        {
            Subject sub = (Subject)args;
            Console.WriteLine($"Passing :{sub.Title}");
        }
    }
}
