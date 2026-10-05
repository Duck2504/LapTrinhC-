namespace MyLib;

public class LibBaiTap
{
    public static int GiaiPTBac2(double a, double b, double c, ref double x1, ref double x2)
    {
        int sn;
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0) sn = -1;
                else sn = 0;
            }
            else
            {
                sn = 1;
                x1 = -c / b;
            }
        }
        else
        {
            double delta = b * b - 4 * a * c;

            if (delta < 0) sn = 0;
            else if (delta == 0)
            {
                sn = 1;
                x1 = -b / (2 * a);
            }
            else
            {
                sn = 2;
                x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                x2 = (-b + Math.Sqrt(delta)) / (2 * a);

                if (x1 > x2)
                {
                    double temp = x1;
                    x1 = x2;
                    x2 = temp;
                }
            }
        }
        return sn;
    }

    public static int TimMax(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;

        return max;
    }

    public static bool KiemTraNguyenTo(int n)
    {
        if (n < 2) return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static void HoanVi(ref double a, ref double b)
    {
        double temp = a;
        a = b;
        b = temp;
    }
    public static void TimMaxMin(double a, double b, double c, out double max, out double min)
    {
        // Tìm Max
        max = a;
        if (b > max) max = b;
        if (c > max) max = c;

        // Tìm Min
        min = a;
        if (b < min) min = b;
        if (c < min) min = c;

    }

    public static bool KiemTraDoiXung(string str)
    {
        if (string.IsNullOrEmpty(str)) return false;

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right]) return false;
            left++;
            right--;
        }
        return true;
    }

    public static string DaoChuoi(string str)
    {
        if (string.IsNullOrEmpty(str)) return str;

        char[] charArray = str.ToCharArray();

        Array.Reverse(charArray);

        return new string(charArray);
    }

    public class SinhVien
    {
        // Các thuộc tính (Properties) sử dụng get/set
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int NamHoc { get; set; }

        // Phương thức nhập thông tin
        public void Nhap()
        {
            Console.Write("Nhập mã sinh viên: ");
            MaSV = Console.ReadLine();

            Console.Write("Nhập họ tên sinh viên: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            DiaChi = Console.ReadLine();

            Console.Write("Sinh viên năm thứ mấy: ");

            int nam;
            while (!int.TryParse(Console.ReadLine(), out nam) || nam <= 0)
            {
                Console.Write("Lỗi! Vui lòng nhập lại năm học (số nguyên > 0): ");
            }

            NamHoc = nam;
        }

        public void Xuat()
        {
            Console.WriteLine("\n--- THÔNG TIN SINH VIÊN ---");
            Console.WriteLine($"- Mã SV: {MaSV}");
            Console.WriteLine($"- Họ tên: {HoTen}");
            Console.WriteLine($"- Địa chỉ: {DiaChi}");
            Console.WriteLine($"- Năm học: Năm thứ {NamHoc}");
        }
    }
}
