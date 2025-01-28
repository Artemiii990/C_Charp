using System;
using System.Collections.Generic;

namespace main_interface_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Imath minProg = new Min_programm();
            minProg.min();

            Imath maxProg = new Max_programm();
            maxProg.max(); 

            Imath avgProg = new Average_programm();
            avgProg.average();

            Imath searchProg = new Search_programm();
            searchProg.Search(5);


        }
    }

    interface Imath
    {
        void min();
        void max();
        void average();
        void Search(int valueToSearch);
    }

    class Min_programm : Imath
    {
        public void min()
        {
            int minVal = 1;
            for (int i = 2; i < 10; i++)
            {
                if (i < minVal)
                {
                    minVal = i;
                }
            }
            Console.WriteLine($"Minimum value: {minVal}");

        }

        public void max()
        {
             throw new NotImplementedException();
        }

        public void average()
        {
             throw new NotImplementedException();
        }

        public void Search(int valueToSearch)
        {
             throw new NotImplementedException();
        }
    }

    class Max_programm : Imath
    {
        public void max()
        {
            int maxVal = 1;
            for (int i = 2; i < 10; i++)
            {
                if (i > maxVal)
                {
                    maxVal = i;
                }
            }
            Console.WriteLine($"Maximum value: {maxVal}");
        }

        public void min()
        {
            throw new NotImplementedException();
        }

        public void average()
        {
            throw new NotImplementedException();
        }

        public void Search(int valueToSearch)
        {
            throw new NotImplementedException();
        }
    }

    class Average_programm : Imath
    {
        public void average()
        {
            int sum = 0;
            for (int i = 1; i < 10; i++)
            {
                sum += i;
            }
            Console.WriteLine($"Average value: {(double)sum / 9}");

        }

        public void min()
        {
             throw new NotImplementedException();
        }

        public void max()
        {
             throw new NotImplementedException();
        }

        public void Search(int valueToSearch)
        {
             throw new NotImplementedException();
        }
    }

    class Search_programm : Imath
    {
        private int entervalueToSearch;

        public void Search(int valueToSearch)
        {
            Console.WriteLine("Enter the value to search: ");
            entervalueToSearch = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Values equal (Equals)? {entervalueToSearch.Equals(valueToSearch)}");
        }

        public void min()
        {
             throw new NotImplementedException();
        }

        public void max()
        {
             throw new NotImplementedException();
        }

        public void average()
        {
             throw new NotImplementedException();
        }
    }
}
