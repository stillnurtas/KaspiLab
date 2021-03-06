using System;
using System.Collections.Generic;
using System.Text;

namespace KaspiLab_HW
{
    class HomeWork_1
    {
        public static void IterateArray(int[] arr)
        {
            int sum = 0;
            var (even, odd) = (String.Empty, String.Empty);

            foreach(var num in arr)
            {
                sum += num;
                if (num % 2 == 0) even += $" {num.ToString()}";
                else odd += $" {num.ToString()}"; 
            }

            Console.WriteLine($"Even numbers {even.Trim()}");
            Console.WriteLine($"Odd numbers {odd.Trim()}");
            Console.WriteLine($"Sum of array is {sum}");
        }
    }
}
