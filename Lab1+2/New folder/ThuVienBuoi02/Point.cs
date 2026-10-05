using System;

namespace ThuVienBuoi02
{
    public class Point
    {
        private double x;
        private double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Input()
        {
            Console.Write("  Nhập hoành độ x: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("  Lỗi! Nhập lại hoành độ x: ");
            }

            Console.Write("  Nhập tung độ y: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.Write("  Lỗi! Nhập lại tung độ y: ");
            }
        }

        public void Output()
        {
            Console.WriteLine($"({x}, {y})");
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        // 6. Phép toán (Operator Overloading)
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        public static Point operator -(Point a)
        {
            return new Point(-a.x, -a.y);
        }

        public double KhoangCachDen(Point b)
        {
            return Math.Sqrt(Math.Pow(this.x - b.x, 2) + Math.Pow(this.y - b.y, 2));
        }

        public static double KhoangCach(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }

        public Point TimTrungDiemVoi(Point b)
        {
            return new Point((this.x + b.x) / 2.0, (this.y + b.y) / 2.0);
        }

        public static Point TimTrungDiem(Point a, Point b)
        {
            return new Point((a.x + b.x) / 2.0, (a.y + b.y) / 2.0);
        }
    }
}