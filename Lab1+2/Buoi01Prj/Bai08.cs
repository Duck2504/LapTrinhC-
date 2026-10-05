using System;
using MyLib;

namespace Buoi01Prj
{
    public class Bai08
    { 
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 8: HOÁN VỊ HAI SỐ THỰC (DÙNG REF) ---");
            
            Console.Write("Nhập số thực a: ");
            double.TryParse(Console.ReadLine(), out double a);

            Console.Write("Nhập số thực b: ");
            double.TryParse(Console.ReadLine(), out double b);

            Console.WriteLine($"\n[Trước khi hoán vị]: a = {a}, b = {b}");
            
            LibBaiTap.HoanVi(ref a, ref b);
            
            Console.WriteLine($"[Sau khi hoán vị] : a = {a}, b = {b}");
        }
    }
}