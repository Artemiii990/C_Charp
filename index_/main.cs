namespace Person_dir;

public class main
{
    public static void Main(string[] args)
    {
        Person person1 = new Person("Олексей", 25);
        person1.DisplayInfo();
        Console.WriteLine();


        Person person2 = new Person("Мария", 25, "США");
        person2.DisplayInfo();
    }
}