using System;
using System.Collections; // Bắt buộc phải có thư viện này để dùng ArrayList

namespace ThuVienBuoi02
{
    public class ArrayPoint
    {
        // 1. Field: Một ArrayList dùng để lưu trữ các Point
        private ArrayList danhSachPoint;

        // Constructor khởi tạo mảng
        public ArrayPoint()
        {
            danhSachPoint = new ArrayList();
        }

        // Phương thức hỗ trợ thêm Point vào danh sách
        public void AddPoint(Point p)
        {
            danhSachPoint.Add(p);
        }

        // Thuộc tính phụ trợ đếm số lượng phần tử (để dễ vòng lặp)
        public int Count
        {
            get { return danhSachPoint.Count; }
        }

        // 2. Indexer: Cho phép truy cập Point thứ i của ArrayList thông qua dấu ngoặc vuông []
        public Point this[int index]
        {
            get
            {
                // Ký thuật kiểm tra phạm vi (Bound checking) tránh lỗi sập chương trình
                if (index >= 0 && index < danhSachPoint.Count)
                {
                    return (Point)danhSachPoint[index]; // Ép kiểu object về Point
                }
                throw new IndexOutOfRangeException("Chỉ số vượt ra ngoài phạm vi của mảng.");
            }
            set
            {
                if (index >= 0 && index < danhSachPoint.Count)
                {
                    danhSachPoint[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chỉ số vượt ra ngoài phạm vi của mảng.");
                }
            }
        }
    }
}