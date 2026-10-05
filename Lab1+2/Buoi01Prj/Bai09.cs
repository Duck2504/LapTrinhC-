using System;
using MyLib;

namespace Buoi01Prj
{
    public class Bai09
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 9: TÌM MAX, MIN BẰNG OUT ---");

            Console.Write("Nhập số thứ 1: ");
            double.TryParse(Console.ReadLine(), out double x);

            Console.Write("Nhập số thứ 2: ");
            double.TryParse(Console.ReadLine(), out double y);

            Console.Write("Nhập số thứ 3: ");
            double.TryParse(Console.ReadLine(), out double z);

            // Khai báo 2 biến rỗng để hứng kết quả từ hàm
            double giaTriMax, giaTriMin;

            LibBaiTap.TimMaxMin(x, y, z, out giaTriMax, out giaTriMin);

            Console.WriteLine($"\n=> Giá trị lớn nhất (Max): {giaTriMax}");
            Console.WriteLine($"=> Giá trị nhỏ nhất (Min): {giaTriMin}");
        }
    }
}