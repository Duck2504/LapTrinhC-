using System;
using System.Data;
namespace Buoi02proj
{
    public class Bai1_1
    {
        public static void Chay()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Bài 1.1: TÍNH TUỔI SINH VIÊN ---");
            Console.WriteLine("Nhập họ tên sinh viên: ");
            string hoTen = Console.ReadLine();
            Console.WriteLine("Nhập năm sinh: ");
            int namSinh;
            int namHientai = DateTime.Now.Year;
            while (!int.TryParse(Console.ReadLine() , out namSinh) || namSinh > namHientai || namSinh < 1900)
            {
                Console.Write("Năm sinh ko hợp lệ vui lòng nhập lại: ");              
            }
            int tuoi = namHientai - namSinh;
            Console.WriteLine($"\nSinh viên {hoTen} sinh nam {namSinh} có tuổi {tuoi}");
        }
    }
}