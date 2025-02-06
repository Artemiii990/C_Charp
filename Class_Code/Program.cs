namespace P32.Lesson35_36;

public class Lesson35_36
{
    public static void Main(string[] args)
    {
        int [] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        IEnumerable<int> enumerable = from num in arr 
            where num % 2 == 0 
            select num;

        foreach (var num in enumerable)
        {
            Console.WriteLine(num);
        }
        
        Console.WriteLine("\n========================");

        List<int> list = arr.Where(num => num % 2 == 0)
            .ToList();
        //.ForEach(num => Console.Write(num + " "));

        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        
        Console.WriteLine("\n========================");
        var orderedEnumerable = from num in arr 
            orderby num descending 
            select num;

        arr.OrderByDescending(num => num)
            .ToList()
            .ForEach(num => Console.Write(num + " "));
        
        
        Console.WriteLine("\n========================");

        string[]colors = { "red", "blue", "green", "yellow", "orange", "purple" };

        var enumerable1 = from color in colors 
            group color by color.Length;


        foreach (var group in enumerable1)
        {
            Console.Write(group.Key+" ");
        }
        
        colors.GroupBy(color => color.Length)
            .ToList()
            .ForEach(group => Console.Write(group.Key + " "));
        
        Console.WriteLine("\n========================");
        
        int sum = arr.Sum();
        double avg = arr.Average();
        int max = arr.Max();
        
        Console.WriteLine("sum:"+sum+", avg:"+avg+", max:"+max);
        Console.WriteLine("\n========================");

        List<string> list1 = new List<string>() {"Toyota", "Mercedes", "Nissan", "Morris"};
        
        list1.Where(list1 => list1.StartsWith("M")).ToList()
            .ToList()
            .ForEach(list1 => Console.Write(list1 + " "));


    }
}