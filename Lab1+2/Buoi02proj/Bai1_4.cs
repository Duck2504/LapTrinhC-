using System;
using ThuVienBuoi02;

namespace Buoi02proj
{
    public class Bai1_4
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 1.4: THIẾT KẾ VÀ KIỂM THỬ LỚP PHÂN SỐ ===");

            try
            {
                PhanSo ps1 = new PhanSo(4, 6);      
                PhanSo ps2 = new PhanSo(1, -2);     
                PhanSo ps3 = new PhanSo(ps1);      

                Console.WriteLine($"Phân số 1 (4/6): {ps1}");
                Console.WriteLine($"Phân số 2 (1/-2): {ps2}");
                Console.WriteLine($"Phân số 3 (Copy ps1): {ps3}");

                Console.WriteLine("\n--- TOÁN TỬ 1 NGÔI ---");
                Console.WriteLine($"+ps1 = {+ps1}");
                Console.WriteLine($"-ps1 = {-ps1}");

                Console.WriteLine("\n--- TOÁN TỬ 2 NGÔI ---");
                Console.WriteLine($"{ps1} + {ps2} = {ps1 + ps2}");
                Console.WriteLine($"{ps1} - {ps2} = {ps1 - ps2}");
                Console.WriteLine($"{ps1} * {ps2} = {ps1 * ps2}");
                Console.WriteLine($"{ps1} / {ps2} = {ps1 / ps2}");

                Console.WriteLine("\n--- TOÁN TỬ SO SÁNH ---");
                Console.WriteLine($"{ps1} == {ps3} : {ps1 == ps3}");
                Console.WriteLine($"{ps1} != {ps2} : {ps1 != ps2}");
                Console.WriteLine($"{ps1} > {ps2}  : {ps1 > ps2}");
                Console.WriteLine($"{ps1} <= {ps2} : {ps1 <= ps2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
}