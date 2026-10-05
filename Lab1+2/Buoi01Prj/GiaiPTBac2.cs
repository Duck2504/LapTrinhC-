using MyLib;

namespace Buoi01Prj
{
    class GiaiPTBac2
    {
        public static void Chay()
        {
            Console.WriteLine("=== Chương trình giải phương trình bật 2 ===");

            try
            {
                Console.Write("Nhap hệ số a: ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhap hệ số b: ");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhap hệ số c: ");
                double c = Convert.ToDouble(Console.ReadLine());

                double x1 = 0;
                double x2 = 0;

                int soNghiem = LibBaiTap.GiaiPTBac2(a, b, c, ref x1, ref x2);

                switch (soNghiem)
                {
                    case -1:
                        Console.WriteLine("Kết quả: Phương trình có vô số nghiệm.");
                        break;
                    case 0:
                        Console.WriteLine("Kết quả: Phương trình vô nghiệm."); 
                        break;
                    case 1:
                        Console.WriteLine($"Kết quả: Phương trình có 1 nghiệm: x = {x1}");
                        break;
                    case 2:
                        Console.WriteLine("Kết quả: Phương trình có 2 nghiệm phân biệt:");
                        Console.WriteLine($"x1 = {x1}");
                        Console.WriteLine($"x2 = {x2}");
                        break;
                    default:
                        Console.WriteLine("Lỗi không xác định.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Lỗi: Nhập số ko hợp lệ");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
