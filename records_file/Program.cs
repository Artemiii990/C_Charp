using System;

namespace records_file
{
    public record School_subjects(string name_subject, int mark_subject)
    {

        public override string ToString()
        {
            return $"Предмет: {name_subject}, Оценка: {mark_subject}";
        }

    }

    public static class SubjectUtils
    {
        
        public static double MaxMark(IEnumerable<School_subjects> subjects_max)
        {
            if (!subjects_max.Any())
            {
                return 0;
            }

            return subjects_max.Max(subject => subject.mark_subject);
        }
        
        public static double AverageMark(IEnumerable<School_subjects> subjects_average)
        {
            if (!subjects_average.Any())
            {
                return 0; 
            }

            return subjects_average.Average(subject => subject.mark_subject);
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            School_subjects biology = new School_subjects("Биология", 10);
            School_subjects geometry = new School_subjects("Геометрия", 11);
            School_subjects archeology = new School_subjects("Археология", 8);

            Console.WriteLine(biology);
            Console.WriteLine(geometry);
            Console.WriteLine(archeology);

            List<School_subjects> subjects_max = new List<School_subjects> { biology, geometry, archeology };
            double maxMark = SubjectUtils.MaxMark(subjects_max);
            Console.WriteLine($"Максимальный балл ученика ----- {maxMark}");
            
            List<School_subjects> subjects_average = new List<School_subjects> { biology, geometry, archeology };
            double averageMark = SubjectUtils.AverageMark(subjects_average);
            Console.WriteLine($"Средний балл ученика ----- {averageMark}");
         }
    }
}