using System;

namespace Buoi01Prj
{
    public class Bai04
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 4: TÍNH LŨY THỪA (CÓ KIỂM TRA LỖI) ---");
            int x, y;

            Console.Write("Nhập số nguyên x: ");
            string inputX = Console.ReadLine();
            if (!int.TryParse(inputX, out x))
            {
                Console.WriteLine("Lỗi: Đầu vào của x không phải là số nguyên!");
                return;
            }

            Console.Write("Nhập số nguyên y: ");
            string inputY = Console.ReadLine();
            if (!int.TryParse(inputY, out y))
            {
                Console.WriteLine("Lỗi: Đầu vào của y không phải là số nguyên!");
                return;
            }
            double ketQua = Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
        }
    }
}