using System;

namespace lesson7_8
{
    public class index7_8
    {
        public static void my_exeption(int number)
        {
            if (number % 2 == 0){
                Console.WriteLine("The number is even");
                throw new ArithmeticException("The number is even");
            }
            else{
                Console.WriteLine("The number is odd");
                throw new ArithmeticException("The number is odd");
            }
                
        }
        
        public static void Main(string[] args)
        {
            String name = null;
            int a = 15;
            int b = 0;
            try
            {
                Console.Write(a / b);
                Console.Write(name.Length);
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("division by zero" + e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("null reference" + e.Message);
            }

            finally
            {
                Console.WriteLine("press any key to continue...");
            }
            
            my_exeption(10);
            
        }
    }
}
