using System;
using MyLib;

namespace Buoi01Prj
{
    public class Bai07
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 7: KIỂM TRA SỐ NGUYÊN TỐ ---");
            Console.Write("Nhập số nguyên n: ");
            
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                bool ketQua = LibBaiTap.KiemTraNguyenTo(n);
                if (ketQua)
                    Console.WriteLine($"=> {n} là số nguyên tố.");
                else
                    Console.WriteLine($"=> {n} KHÔNG phải là số nguyên tố.");
            }
            else
            {
                Console.WriteLine("Lỗi: Dữ liệu nhập không hợp lệ.");
            }
        }
    }
}