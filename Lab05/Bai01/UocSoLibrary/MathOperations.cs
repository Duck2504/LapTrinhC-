using System;
using System.Collections.Generic;

namespace UocSoLibrary
{
    public static class MathOperations
    {
        // Lấy danh sách ước số của một số
        public static List<int> GetDivisors(int number)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0) divisors.Add(i);
            }
            return divisors;
        }

        // Kiểm tra số nguyên tố
        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}