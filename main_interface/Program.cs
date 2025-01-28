using System;
using System.Collections.Generic;

namespace main_interface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICalc lessCalc = new LessCalc();
            lessCalc.Less(15); 


            ICalc greaterCalc = new GreaterCalc();
            greaterCalc.Greater(5); 

        }
    }


    interface ICalc
    {
        void Less(int valueToCompare);
        void Greater(int valueToCompare);
    }

    class LessCalc : ICalc
    {
        public void Less(int valueToCompare)
        {
            for (int i = 0; i < valueToCompare; i++)
            {
                Console.WriteLine("{0} is less than {1}", i, valueToCompare); 
            }
        }


        public void Greater(int valueToCompare)
        {
            throw new NotImplementedException();
        }
    }


    class GreaterCalc : ICalc
    {
        public void Greater(int valueToCompare)
        {
            for (int i = valueToCompare + 1; i <= valueToCompare + 10; i++) 
            {
                Console.WriteLine("{0} is greater than {1}", i, valueToCompare); 
            }
        }
        public void Less(int valueToCompare)
        {
            throw new NotImplementedException();
        }
        
    }


}