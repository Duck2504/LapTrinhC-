using System;
using ThuVienBuoi02;
namespace Buoi02proj
{
    public class Bai1_2
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 1.2: THIẾT KẾ VÀ KIỂM THỬ LỚP POINT ===");

            Console.WriteLine("Nhập tọa độ điểm A:");
            Point A = new Point();
            A.Input();

            Console.WriteLine("Nhập tọa độ điểm B:");
            Point B = new Point();
            B.Input();

            Console.WriteLine("\n--- THÔNG TIN ĐIỂM ---");
            Console.Write("Điểm A (gọi hàm Output): ");
            A.Output();
            Console.WriteLine($"Điểm B (dùng ToString): {B}");

            Console.WriteLine("\n--- KẾT QUẢ CÁC PHÉP TOÁN TỌA ĐỘ ---");
            Point tong = A + B;
            Point hieu = A - B;
            Point doiA = -A;

            Console.WriteLine($"A + B = {tong}");
            Console.WriteLine($"A - B = {hieu}");
            Console.WriteLine($"-A (tọa độ đối của A) = {doiA}");

            Console.WriteLine("\n--- TÍNH KHOẢNG CÁCH AB ---");
            double kcThanhVien = A.KhoangCachDen(B);
            double kcStatic = Point.KhoangCach(A, B);
            Console.WriteLine($"- Theo phương thức thành viên (A.KhoangCachDen(B)): {kcThanhVien:F2}");
            Console.WriteLine($"- Theo phương thức tĩnh (Point.KhoangCach(A, B))     : {kcStatic:F2}");

            Console.WriteLine("\n--- TÌM TRUNG ĐIỂM I CỦA ĐOẠN THẲNG AB ---");
            Point iThanhVien = A.TimTrungDiemVoi(B);
            Point iStatic = Point.TimTrungDiem(A, B);
            Console.WriteLine($"- Theo phương thức thành viên (A.TimTrungDiemVoi(B)): {iThanhVien}");
            Console.WriteLine($"- Theo phương thức tĩnh (Point.TimTrungDiem(A, B))    : {iStatic}");
        }
    }
}