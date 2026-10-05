using System;

namespace Buoi01Prj
{
    public class Bai14
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 14: TÍNH LƯƠNG NHÂN VIÊN ===");
            
            Console.Write("Nhập họ tên nhân viên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhập mức lương (VNĐ): ");
            double mucLuong;
            while (!double.TryParse(Console.ReadLine(), out mucLuong) || mucLuong < 0)
            {
                Console.Write("Lỗi! Vui lòng nhập lại mức lương hợp lệ: ");
            }

            Console.Write("Nhập số ngày vắng: ");
            int soNgayVang;
            while (!int.TryParse(Console.ReadLine(), out soNgayVang) || soNgayVang < 0)
            {
                Console.Write("Lỗi! Vui lòng nhập lại số ngày vắng hợp lệ: ");
            }

            double tienPhat = soNgayVang * 100000;
            double luongThucLanh = mucLuong - tienPhat;

            if (luongThucLanh < 0) 
            {
                luongThucLanh = 0;
            }

            Console.WriteLine("\n--- BẢNG LƯƠNG ---");
            Console.WriteLine($"- Nhân viên: {hoTen}");
            Console.WriteLine($"- Lương gốc: {mucLuong:N0} VNĐ");
            Console.WriteLine($"- Ngày vắng: {soNgayVang} ngày (Trừ {tienPhat:N0} VNĐ)");
            Console.WriteLine($"- LƯƠNG THỰC LÃNH: {luongThucLanh:N0} VNĐ");
        }
    }
}