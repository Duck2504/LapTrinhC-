using System;
using MyLib;

namespace Buoi01Prj
{
    public class Bai10
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 10: KIỂM TRA CHUỖI ĐỐI XỨNG ---");
            Console.Write("Nhập chuỗi cần kiểm tra: ");
            string s = Console.ReadLine();

            if (LibBaiTap.KiemTraDoiXung(s))
                Console.WriteLine($"=> '{s}' LÀ chuỗi đối xứng.");
            else
                Console.WriteLine($"=> '{s}' KHÔNG PHẢI là chuỗi đối xứng.");
        }
    }
}