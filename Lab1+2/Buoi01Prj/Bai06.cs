using System;
using MyLib;
namespace Buoi01Prj
{
    public class Bai06
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 6: TÌM SỐ LỚN NHẤT TRONG 3 SỐ NGUYÊN ---");
            
            int a, b, c;

            Console.Write("Nhập số nguyên thứ nhất: ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Lỗi! Vui lòng nhập lại số nguyên: ");
            }

            Console.Write("Nhập số nguyên thứ hai: ");
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.Write("Lỗi! Vui lòng nhập lại số nguyên: ");
            }

            Console.Write("Nhập số nguyên thứ ba: ");
            while (!int.TryParse(Console.ReadLine(), out c))
            {
                Console.Write("Lỗi! Vui lòng nhập lại số nguyên: ");
            }

            int giaTriLonNhat = LibBaiTap.TimMax(a, b, c);

            Console.WriteLine($"\n=> Giá trị lớn nhất trong 3 số ({a}, {b}, {c}) là: {giaTriLonNhat}");
        }
    }
}