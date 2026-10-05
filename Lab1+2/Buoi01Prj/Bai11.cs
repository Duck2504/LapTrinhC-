using System;
using MyLib;

namespace Buoi01Prj
{
    public class Bai11
    { 
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 11: ĐẢO NGƯỢC CHUỖI ---");
            Console.Write("Nhập chuỗi cần đảo: ");
            string s = Console.ReadLine();

            string chuoiDao = LibBaiTap.DaoChuoi(s);
            Console.WriteLine($"=> Chuỗi sau khi đảo: {chuoiDao}");
        }
    }
}