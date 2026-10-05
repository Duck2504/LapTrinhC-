using System;

namespace Buoi02proj
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("===== MENU BÀI TẬP BUỔI 2 =====");
                Console.WriteLine("1. Thiết kế lớp cơ bản");
                Console.WriteLine("2. Thiết kế lớp nâng cao");
                Console.WriteLine("3. Kế thừa & đa hình");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("===============================");
                Console.Write("Chọn bài tập: ");

                string luaChon = Console.ReadLine();
                switch (luaChon)
                {
                    case "1":
                        bool isMenu1Running = true;
                        while (isMenu1Running)
                        {
                            Console.Clear();
                            Console.WriteLine("===== MENU BÀI THIẾT KẾ LỚP CƠ BẢN =====");
                            Console.WriteLine("1. Tính tuổi sinh viên");
                            Console.WriteLine("2. Thiết kế lớp Point");
                            Console.WriteLine("3. Thiết kế lớp Person");
                            Console.WriteLine("4. Thiết kế lớp Phân số");
                            Console.WriteLine("0. Quay lại....");
                            Console.WriteLine("========================================");
                            Console.Write("Chọn bài tập: ");

                            string luaChon2 = Console.ReadLine();
                            switch (luaChon2)
                            {
                                case "1":
                                    Bai1_1.Chay();
                                    break;
                                case "2":
                                    Bai1_2.Chay();
                                    break;
                                case "3":
                                    Bai1_3.Chay();
                                    break;
                                case "4":
                                    Bai1_4.Chay();
                                    break;
                                case "0":
                                    Console.WriteLine("\nĐang quay lại Menu chính...");
                                    isMenu1Running = false;
                                    break;
                                default:
                                    Console.WriteLine("\nLựa chọn không hợp lệ.");
                                    break;
                            }

                            if (isMenu1Running)
                            {
                                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "2":
                        bool isMenu2Running = true;
                        while (isMenu2Running)
                        {
                            Console.WriteLine("===== MENU BÀI THIẾT KẾ LỚP NÂNG CAO =====");
                            Console.WriteLine("1. Thiết kế lớp ArrayPoint (Lớp phức)");
                            Console.WriteLine("2. Thiết kế lớp PersonList");
                            Console.WriteLine("3. Thiết kế lớp Lớp chứa mảng 1 chiều");
                            Console.WriteLine("4. Thiết kế lớp Lớp chứa mảng 2 chiều");
                            Console.WriteLine("0. Quay lại....");
                            Console.WriteLine("==========================================");
                            Console.Write("Chọn bài tập: ");

                            string luaChon3 = Console.ReadLine();
                            switch (luaChon3)
                            {
                                case "1":
                                    Bai2_1.Chay();
                                    break;
                                case "2":
                                    Bai2_2.Chay();
                                    break;
                                case "3":
                                    Bai2_3.Chay();
                                    break;
                                case "4":
                                    Bai2_4.Chay();
                                    break;
                                case "0":
                                    Console.WriteLine("\nĐang quay lại Menu chính...");
                                    isMenu2Running = false;
                                    break;
                                default:
                                    Console.WriteLine("\nLựa chọn không hợp lệ.");
                                    break;
                            }
                            if (isMenu2Running)
                            {
                                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "0":
                        Console.WriteLine("\nTạm biệt!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ.");
                        Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}