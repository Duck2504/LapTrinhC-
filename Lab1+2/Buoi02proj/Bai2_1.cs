using System;
using ThuVienBuoi02;

namespace Buoi02proj
{
    public class Bai2_1
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 2.1: THIẾT KẾ LỚP ARRAYPOINT (LỚP PHỨC) ===");

            ArrayPoint arrP = new ArrayPoint();
            arrP.AddPoint(new Point(1, 2));
            arrP.AddPoint(new Point(5, -7));
            arrP.AddPoint(new Point(0, 0));

            Console.WriteLine("\n--- DANH SÁCH POINT BAN ĐẦU ---");
            for (int i = 0; i < arrP.Count; i++)
            {
                Console.WriteLine($"Điểm ở vị trí thứ {i}: {arrP[i]}");
            }

            Console.WriteLine("\n--- KIỂM THỬ INDEXER (ĐỔI GIÁ TRỊ) ---");
            Console.WriteLine($"Đang thay đổi điểm ở vị trí số 1 từ {arrP[1]} thành (99, 99)...");

            arrP[1] = new Point(99, 99); 
            
            Console.WriteLine($"=> Kết quả sau khi đổi: Điểm vị trí số 1 là {arrP[1]}");

            Console.WriteLine("\n--- KIỂM THỬ NGOẠI LỆ (NẰM NGOÀI MẢNG) ---");
            try
            {
                Console.WriteLine("Cố tình truy xuất Point thứ 10 (không tồn tại)...");
                Point loi = arrP[10]; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã chặn được lỗi: {ex.Message}");
            }
        }
    }
}