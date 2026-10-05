using System;
using ThuVienBuoi02;

namespace Buoi02proj
{
    public class Bai2_3
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 2.3: KIỂM THỬ LỚP DÃY SỐ (MẢNG 1 CHIỀU) ===");
            DaySo ds = new DaySo();
            ds.Input();
            
            Console.Write("Dãy số vừa nhập: ");
            ds.Output();

            Console.Write("Các số chẵn trong dãy: ");
            DaySo dsChan = ds.TimCacSoChan();
            dsChan.Output();

            if (ds.N > 0)
            {
                Console.WriteLine($"\nĐang sửa phần tử đầu tiên ds[0] thành 999...");
                ds[0] = 999; 
                Console.Write("Dãy số sau khi sửa: ");
                ds.Output();
            }
        }
    }
}