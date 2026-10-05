using System;
using MyLib;

namespace Buoi01Prj
{
    public class Bai13
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 13: QUẢN LÝ SINH VIÊN ===");

            LibBaiTap.SinhVien sv = new LibBaiTap.SinhVien();
            sv.Nhap();
            sv.Xuat();
        }
    }
}