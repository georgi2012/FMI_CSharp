using System;
using System.Collections.Generic;
using System.Text;

namespace week9
{//event source
    public class StudentCardReport
    {
        public event EventHandler Passing;
        private List<Subject> list;
        public StudentCardReport(List<Subject> subjects)
        {
            list =new List<Subject> (subjects);
        }

        public List<Subject> ListOfSubjects
        {
            get => list;
            set
            {
            }
        }

        public void ProcessReport()
        {
            foreach (var item in ListOfSubjects)
            {
                foreach (var subj in item.Grades)
                {
                    if(subj > 75)
                    {
                        Passing?.Invoke(this, item);
                    }
                    else
                    {
                        Console.WriteLine($"Not passing: {item.Title}");
                    }
                }

            }
        }
    }
}