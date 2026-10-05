using System;
using ThuVienBuoi02;

namespace Buoi02proj
{
    public class Bai1_3
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 1.3: THIẾT KẾ VÀ KIỂM THỬ LỚP PERSON ===");
            Console.WriteLine("\n--- 1. NHẬP THÔNG TIN NGƯỜI THỨ NHẤT ---");
            Person p1 = new Person(); 
            p1.Input();
            Console.WriteLine("\n--- 2. TẠO NGƯỜI THỨ 2 BẰNG COPY CONSTRUCTOR ---");
            Console.WriteLine("Hệ thống đang sao chép dữ liệu từ Người thứ 1 sang Người thứ 2...");
            Person p2 = new Person(p1); 
            
            p2.Id = p1.Id + "-COPY";
            p2.FullName = p1.FullName + " (Bản sao)";

            Console.WriteLine("\n--- DANH SÁCH PERSON ---");
            Console.Write("Người 1: ");
            p1.Output();
            Console.Write("Người 2: ");
            p2.Output();

            Console.WriteLine("\n--- KIỂM TRA HÀM IsLiving() ---");
            if (p1.IsLiving())
            {
                Console.WriteLine($"=> {p1.FullName} vẫn còn sống (IsLiving = true).");
            }
            else
            {
                Console.WriteLine($"=> {p1.FullName} đã qua đời (IsLiving = false).");
            }
        }
    }
}