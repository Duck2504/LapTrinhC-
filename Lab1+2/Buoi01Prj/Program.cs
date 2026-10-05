using System;

namespace Buoi01Prj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("====== MENU BÀI TẬP BUỔI 1 ======");
                Console.WriteLine("1. Giải phương trình bậc 2 (Bai01.cs)");
                Console.WriteLine("2. Nhập xuất họ tên (Bai01.cs)");
                Console.WriteLine("3. Nhập xuất họ tên (Bai02.cs)");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("=================================");
                Console.Write("Mời bạn chọn bài tập: ");

                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        GiaiPTBac2.Chay(); // Gọi hàm Chay() trong file Bai01.cs
                        break;
                    case "2":
                        Bai01.Chay(); // Gọi hàm Chay() trong file Bai02.cs
                        break;
                    case "3":
                        Bai02.Chay(); // Gọi hàm Chay() trong file Bai02.cs
                        break;
                    case "0":
                        Console.WriteLine("\nTạm biệt!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại Menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}