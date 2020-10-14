namespace _04._Best_Lectures_Schedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int lecturesCount = int.Parse(Console.ReadLine().Split()[1]);
            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                string[] lectureDetails = Console.ReadLine().Split();
                string name = lectureDetails[0].Replace(':', ' ').Trim();
                int start = int.Parse(lectureDetails[1]);
                int end = int.Parse(lectureDetails[3]);

                lectures.Add(new Lecture { Name = name, Start = start, End = end });
            }

            List<Lecture> output = new List<Lecture>();
            int currentEndTime = 0;

            foreach (var lecture in lectures.OrderBy(l => l.End))
            {
                if (lecture.Start < currentEndTime)
                {
                    continue;
                }

                currentEndTime = lecture.End;
                output.Add(lecture);
            }

            Console.WriteLine($"Lectures ({output.Count}):");
            foreach (var lecture in output)
            {
                Console.WriteLine($"{lecture.Start}-{lecture.End} -> {lecture.Name}");
            }
        }
    }
}
