using System;
using System.Collections.Generic;
using System.Text;

namespace week9
{ 
    public class Subject : EventArgs
    {//event object
        private int[] grades;
        public const int MAX_GRADES = 5;

        public Subject(int[] grades, string title)
        {
            this.grades = grades;
           // Grades = grades; //not required by event obj
            Title = title;
        }

        public int[] Grades
        {//единична отговорност
            get
            {
                int[] copy = new int[grades.Length];
                for (int i = 0; i < grades.Length; i++)
                {
                    copy[i] = grades[i];
                }
                return copy;
            }
            set
            {
                if (value != null && value.Length == MAX_GRADES)
                {
                    grades = new int[MAX_GRADES];
                    for(int i = 0; i < grades.Length; i++)
                    {
                        grades[i] = value[i];
                    }
                }
                else
                {
                    grades = new int[MAX_GRADES];
                }
            }

        }

        public string Title
        {
            get => default;
            set
            {
            }
        }

        public override string ToString()
          => $"{Title}: {string.Join(",", grades)}";
    }
}