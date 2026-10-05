using System;
using System.Collections.Generic;
using ThuVienBuoi02;

namespace Buoi02proj
{
    public class Bai2_4
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 2.4: KIỂM THỬ LỚP MẢNG 2 CHIỀU ===");
            Mang2Chieu m2c = new Mang2Chieu();
            m2c.Input();

            Console.WriteLine("\nMa trận vừa nhập:");
            m2c.Output();

            Console.Write("\nCác số nguyên tố trong ma trận: ");
            List<int> listNT = m2c.TimSoNguyenTo();
            if (listNT.Count == 0)
            {
                Console.WriteLine("Không có số nguyên tố nào.");
            }
            else
            {
                Console.WriteLine(string.Join(", ", listNT)); // In danh sách ra cách nhau bởi dấu phẩy
            }
        }
    }
}