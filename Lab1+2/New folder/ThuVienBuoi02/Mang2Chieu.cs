using System;
using System.Collections.Generic;

namespace ThuVienBuoi02
{
    public class Mang2Chieu
    {
        private int[,] mang;

        public int SoDong => mang != null ? mang.GetLength(0) : 0;
        public int SoCot => mang != null ? mang.GetLength(1) : 0;
        public Mang2Chieu()
        {
            mang = new int[0, 0];
        }

        public Mang2Chieu(int dong, int cot)
        {
            if (dong < 0 || cot < 0) throw new ArgumentException("Kích thước không hợp lệ.");
            mang = new int[dong, cot];
        }

        public Mang2Chieu(Mang2Chieu other)
        {
            mang = new int[other.SoDong, other.SoCot];
            Array.Copy(other.mang, this.mang, other.mang.Length);
        }
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < SoDong && j >= 0 && j < SoCot) return mang[i, j];
                throw new IndexOutOfRangeException("Chỉ số dòng/cột nằm ngoài phạm vi.");
            }
            set
            {
                if (i >= 0 && i < SoDong && j >= 0 && j < SoCot) mang[i, j] = value;
                else throw new IndexOutOfRangeException("Chỉ số dòng/cột nằm ngoài phạm vi.");
            }
        }

        public void Input()
        {
            Console.Write("Nhập số dòng N = ");
            int dong = int.Parse(Console.ReadLine());
            Console.Write("Nhập số cột M = ");
            int cot = int.Parse(Console.ReadLine());

            mang = new int[dong, cot];
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    Console.Write($"  Phần tử [{i},{j}] = ");
                    mang[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void Output()
        {
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    Console.Write($"{mang[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public List<int> TimSoNguyenTo()
        {
            List<int> danhSachNT = new List<int>();
            for (int i = 0; i < SoDong; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    if (IsPrime(mang[i, j]))
                    {
                        danhSachNT.Add(mang[i, j]);
                    }
                }
            }
            return danhSachNT;
        }
    }
}