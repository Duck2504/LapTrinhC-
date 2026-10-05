using System;
using System.Collections.Generic;
using System.Linq;
using MyLibrary;

namespace BaiThucHanhLINQ_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dsMon = DuLieu.DS_Mon();
            Console.WriteLine("=== BÀI 5.1. TRUY VẤN CƠ BẢN ===\n");

            // a
            var cauA = dsMon.Where(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine("a. Các môn bắt đầu bằng 'Lập trình':");
            foreach (var m in cauA) Console.WriteLine($" - {m.TenMon}");

            // b
            var cauB = dsMon.Where(m => m.He == "CD")
                            .OrderByDescending(m => m.SoTiet)
                            .ThenBy(m => m.MaMon);
            Console.WriteLine("\nb. Các môn hệ CD (Sắp xếp Tiết giảm dần, Mã tăng dần):");
            foreach (var m in cauB) Console.WriteLine($" - {m.MaMon}: {m.TenMon} ({m.SoTiet} tiết)");

            // c
            var cauC = dsMon.Where(m => m.TenMon.ToLower().Contains("web"))
                            .Select(m => new { m.TenMon, m.He });
            Console.WriteLine("\nc. Các môn chứa từ 'web' (Chỉ lấy Tên và Hệ):");
            foreach (var m in cauC) Console.WriteLine($" - {m.TenMon} (Hệ: {m.He})");

            // d
            var cauD = dsMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon);
            Console.WriteLine("\nd. Các môn hệ KTV (Sắp xếp theo Mã môn):");
            foreach (var m in cauD) Console.WriteLine($" - {m.MaMon}: {m.TenMon}");

            Console.ReadLine();
        }
    }
}