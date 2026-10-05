using System;
using System.Collections.Generic;
using System.Linq;
using MyLibrary;

namespace BaiThucHanhLINQ_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dsMon = DuLieu.DS_Mon();
            Console.WriteLine("=== BÀI 5.2. THỐNG KÊ TRÊN LIST<MONHOC> ===\n");
            // a & b & c.
            Console.WriteLine($"a. Tổng số môn hiện có: {dsMon.Count()}");
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {dsMon.Count(m => m.TenMon.StartsWith("Lập trình"))}");
            Console.WriteLine($"c. Tổng số tiết hệ KTV: {dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet)}\n");
            // d
            var cauD = dsMon.GroupBy(m => m.He).Select(g => new { He = g.Key, TongSoMon = g.Count() });
            Console.WriteLine("d. Tổng số môn theo từng hệ:");
            foreach (var item in cauD) Console.WriteLine($" - Hệ '{item.He}': {item.TongSoMon} môn");
            // e
            var cauE = dsMon.GroupBy(m => m.SoTiet)
                            .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
                            .OrderByDescending(x => x.SoTiet);
            Console.WriteLine("\ne. Thống kê theo số tiết:");
            foreach (var item in cauE) Console.WriteLine($" - {item.SoTiet} tiết: {item.TongSoMon} môn");
            // f
            int maxTiet = dsMon.Max(m => m.SoTiet);
            var cauF = dsMon.Where(m => m.SoTiet == maxTiet);
            Console.WriteLine($"\nf. Các môn có số tiết cao nhất ({maxTiet} tiết):");
            foreach (var m in cauF) Console.WriteLine($" - {m.TenMon}");
            // g
            var cauG = dsMon.GroupBy(m => m.He)
                            .Select(g => new {
                                He = string.IsNullOrEmpty(g.Key) ? "Chưa rõ" : g.Key,
                                TongSoMon = g.Count(),
                                TongSoTiet = g.Sum(m => m.SoTiet),
                                MaxTiet = g.Max(m => m.SoTiet),
                                MinTiet = g.Min(m => m.SoTiet)
                            });
            Console.WriteLine("\ng. Thống kê chi tiết theo từng hệ:");
            foreach (var item in cauG)
            {
                Console.WriteLine($" - Hệ {item.He}: {item.TongSoMon} môn, Tổng {item.TongSoTiet} tiết, Max: {item.MaxTiet}, Min: {item.MinTiet}");
            }

            // k
            var cauK = dsMon.Where(m => m.SoTiet > 40)
                            .GroupBy(m => m.He)
                            .Select(g => new {
                                He = string.IsNullOrEmpty(g.Key) ? "Khác" : g.Key,
                                CacMonHoc = g.OrderBy(m => m.MaMon).ToList()
                            });
            
            Console.WriteLine("\nk. Phân nhóm môn > 40 tiết theo Hệ:");
            foreach (var nhom in cauK)
            {
                Console.WriteLine($" [*] Hệ: {nhom.He}");
                foreach (var mon in nhom.CacMonHoc)
                {
                    Console.WriteLine($"     - {mon.MaMon}: {mon.TenMon} ({mon.SoTiet} tiết)");
                }
            }
            Console.ReadLine();
        }
    }
}