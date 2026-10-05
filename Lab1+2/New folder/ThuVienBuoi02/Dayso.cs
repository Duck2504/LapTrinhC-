using System;
using System.Collections.Generic;

namespace ThuVienBuoi02
{
    public class DaySo
    {
        private int[] mang;
        public int N 
        { 
            get { return mang != null ? mang.Length : 0; } 
        }
        public DaySo()
        {
            mang = new int[0];
        }

        public DaySo(int n)
        {
            if (n < 0) throw new ArgumentException("Kích thước mảng không được âm.");
            mang = new int[n];
        }

        public DaySo(DaySo other)
        {
            mang = new int[other.N];
            Array.Copy(other.mang, this.mang, other.N);
        }
        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < N) return mang[i];
                throw new IndexOutOfRangeException("Chỉ số nằm ngoài phạm vi mảng.");
            }
            set
            {
                if (i >= 0 && i < N) mang[i] = value;
                else throw new IndexOutOfRangeException("Chỉ số nằm ngoài phạm vi mảng.");
            }
        }

        public void Input()
        {
            Console.Write("Nhập số lượng phần tử N = ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Vui lòng nhập N > 0: ");
            }

            mang = new int[n];
            for (int i = 0; i < N; i++)
            {
                Console.Write($"  Phần tử [{i}] = ");
                while (!int.TryParse(Console.ReadLine(), out mang[i]))
                {
                    Console.Write($"  Lỗi! Nhập lại phần tử [{i}] = ");
                }
            }
        }

        public void Output()
        {
            if (N == 0)
            {
                Console.WriteLine("[Mảng rỗng]");
                return;
            }
            for (int i = 0; i < N; i++)
            {
                Console.Write($"{mang[i]}  ");
            }
            Console.WriteLine();
        }

        public DaySo TimCacSoChan()
        {
            List<int> listChan = new List<int>();
            for (int i = 0; i < N; i++)
            {
                if (mang[i] % 2 == 0)
                {
                    listChan.Add(mang[i]);
                }
            }
            DaySo ketQua = new DaySo(listChan.Count);
            for (int i = 0; i < listChan.Count; i++)
            {
                ketQua[i] = listChan[i];
            }
            return ketQua;
        }
    }
}