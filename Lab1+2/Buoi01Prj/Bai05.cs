using System;

namespace Buoi01Prj
{
    public class Bai05
    {
        public static void Chay()
        {
            bool isRunning = true;
            double x = 0;
            double y = 0;
            bool daNhapDuLieu = false;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        Console.Write("Nhap so thuc x: ");
                        // Dùng double.TryParse để tránh lỗi sập chương trình như đã học ở Bài 4
                        while (!double.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write("Loi! Vui long nhap lai so thuc x: ");
                        }

                        Console.Write("Nhap so thuc y: ");
                        while (!double.TryParse(Console.ReadLine(), out y))
                        {
                            Console.Write("Loi! Vui long nhap lai so thuc y: ");
                        }

                        daNhapDuLieu = true;
                        Console.WriteLine($"\n=> Da ghi nhan x = {x}, y = {y}");
                        break;

                    case "2":
                        if (!daNhapDuLieu)
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap x va y truoc!");
                        }
                        else
                        {
                            double luyThua = Math.Pow(x, y);
                            Console.WriteLine($"\n=> Ket qua {x}^{y} la: {luyThua}");
                        }
                        break;

                    case "3":
                        if (!daNhapDuLieu)
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap x va y truoc!");
                        }
                        else
                        {
                            Console.WriteLine();
                            // Kiểm tra số âm trước khi tính căn bậc 2
                            if (x >= 0)
                                Console.WriteLine($"=> Can bac 2 cua x ({x}) la: {Math.Sqrt(x)}");
                            else
                                Console.WriteLine($"=> Khong the tinh can bac 2 cua x ({x}) vi la so am.");

                            if (y >= 0)
                                Console.WriteLine($"=> Can bac 2 cua y ({y}) la: {Math.Sqrt(y)}");
                            else
                                Console.WriteLine($"=> Khong the tinh can bac 2 cua y ({y}) vi la so am.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Thoat bai 5...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon tu 1 den 4.");
                        break;
                }
                if (isRunning)
                {
                    Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                }
            }
        }
    }
}