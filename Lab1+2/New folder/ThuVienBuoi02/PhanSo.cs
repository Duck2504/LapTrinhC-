using System;

namespace ThuVienBuoi02
{
    public class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }
        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }

        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
                throw new ArgumentException("Mẫu số không được bằng 0!");

            TuSo = tuSo;
            MauSo = mauSo;
            RutGon();
        }

          public PhanSo(PhanSo other)
        {
            TuSo = other.TuSo;
            MauSo = other.MauSo;
        }

        private int TimUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void RutGon()
        {
            int ucln = TimUCLN(TuSo, MauSo);
            TuSo /= ucln;
            MauSo /= ucln;

            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
        }
        public override string ToString()
        {
            if (MauSo == 1) return $"{TuSo}";
            if (TuSo == 0) return "0";
            return $"{TuSo}/{MauSo}";
        }


        public static PhanSo operator +(PhanSo a) => new PhanSo(a.TuSo, a.MauSo);
        public static PhanSo operator -(PhanSo a) => new PhanSo(-a.TuSo, a.MauSo);
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.TuSo * b.MauSo + b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.TuSo * b.MauSo - b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.TuSo * b.TuSo, a.MauSo * b.MauSo);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.TuSo == 0) throw new DivideByZeroException("Không thể chia cho phân số 0.");
            return new PhanSo(a.TuSo * b.MauSo, a.MauSo * b.TuSo);
        }

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            // Vì phân số đã luôn được rút gọn, ta chỉ cần so sánh tử và mẫu
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.TuSo == b.TuSo && a.MauSo == b.MauSo;
        }

        public static bool operator !=(PhanSo a, PhanSo b) => !(a == b);

        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.TuSo * b.MauSo > b.TuSo * a.MauSo;
        }

        public static bool operator <(PhanSo a, PhanSo b) => b > a;

        public static bool operator >=(PhanSo a, PhanSo b) => a > b || a == b;

        public static bool operator <=(PhanSo a, PhanSo b) => a < b || a == b;

        // Bổ sung Equals và GetHashCode để tránh cảnh báo (warning) khi dùng == và !=
        public override bool Equals(object obj)
        {
            if (obj is PhanSo p) return this == p;
            return false;
        }

        public override int GetHashCode() => Tuple.Create(TuSo, MauSo).GetHashCode();
    }
}