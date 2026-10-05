using System;
namespace Buoi01Prj
{

    public class Bai03
    {

        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 3: NHẬP SỐ NGUYÊN ---");
            try{
            Console.WriteLine("Nhập số nguyên x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhập số nguyên y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kết quả " +x+" mũ "+y+" là: "+Math.Pow(x,y));
            }
            catch(FormatException)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập số nguyên hợp lệ!");
            }
        }
    }
}