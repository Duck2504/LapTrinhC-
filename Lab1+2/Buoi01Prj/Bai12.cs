using System;

namespace Buoi01Prj
{
    public class Bai12
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 12: XỬ LÝ CHUỖI ---");
            Console.Write("Nhập một chuỗi gồm nhiều từ: ");
            string s = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("Chuỗi rỗng!");
                return;
            }
            Console.WriteLine($"=> Viết thường: {s.ToLower()}");
            Console.WriteLine($"=> Viết hoa: {s.ToUpper()}");
            string[] cacTu = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            Console.WriteLine($"=> Số từ trong chuỗi là: {cacTu.Length}");
        }
    }
}