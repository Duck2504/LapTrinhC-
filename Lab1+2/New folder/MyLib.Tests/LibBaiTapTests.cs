using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace MyLib.Tests
{
    [TestClass]
    public class LibBaiTapTests
    {
        // 1. Trường hợp a=0, b=0, c=0 -> Vô số nghiệm (Trả về -1)
        [TestMethod]
        public void GiaiPTBac2_VoSoNghiem_TraVeAm1()
        {
            double x1 = 0, x2 = 0;
            int ketQua = LibBaiTap.GiaiPTBac2(0, 0, 0, ref x1, ref x2);
            
            Assert.AreEqual(-1, ketQua);
        }

        // 2. Trường hợp a=0, b=0, c!=0 -> Vô nghiệm (Trả về 0)
        [TestMethod]
        public void GiaiPTBac2_a0_b0_cKhac0_VoNghiem_TraVe0()
        {
            double x1 = 0, x2 = 0;
            int ketQua = LibBaiTap.GiaiPTBac2(0, 0, 5, ref x1, ref x2);
            
            Assert.AreEqual(0, ketQua);
        }

        // 3. Trường hợp a=0, b!=0 -> Phương trình bậc 1 có 1 nghiệm (Trả về 1)
        [TestMethod]
        public void GiaiPTBac2_PhuongTrinhBac1_TraVe1()
        {
            double x1 = 0, x2 = 0;
            // 2x - 4 = 0 => x = 2
            int ketQua = LibBaiTap.GiaiPTBac2(0, 2, -4, ref x1, ref x2);
            
            Assert.AreEqual(1, ketQua);
            Assert.AreEqual(2.0, x1, 0.0001); // 0.0001 là sai số cho phép khi so sánh số thực
        }

        // 4. Trường hợp a!=0, Delta < 0 -> Vô nghiệm (Trả về 0)
        [TestMethod]
        public void GiaiPTBac2_DeltaNhoHon0_VoNghiem_TraVe0()
        {
            double x1 = 0, x2 = 0;
            // x² + x + 1 = 0 => Delta = -3 < 0
            int ketQua = LibBaiTap.GiaiPTBac2(1, 1, 1, ref x1, ref x2);
            
            Assert.AreEqual(0, ketQua);
        }

        // 5. Trường hợp a!=0, Delta = 0 -> Nghiệm kép (Trả về 1)
        [TestMethod]
        public void GiaiPTBac2_DeltaBang0_NghiemKep_TraVe1()
        {
            double x1 = 0, x2 = 0;
            // x² - 2x + 1 = 0 => x = 1
            int ketQua = LibBaiTap.GiaiPTBac2(1, -2, 1, ref x1, ref x2);
            
            Assert.AreEqual(1, ketQua);
            Assert.AreEqual(1.0, x1, 0.0001);
        }

        // 6. Trường hợp a!=0, Delta > 0 -> 2 nghiệm phân biệt (Trả về 2)
        [TestMethod]
        public void GiaiPTBac2_DeltaLonHon0_2Nghiem_TraVe2_VaSapXep()
        {
            double x1 = 0, x2 = 0;
            // x² - 3x + 2 = 0 => x1 = 1, x2 = 2
            int ketQua = LibBaiTap.GiaiPTBac2(1, -3, 2, ref x1, ref x2);
            
            Assert.AreEqual(2, ketQua);
            Assert.AreEqual(1.0, x1, 0.0001);
            Assert.AreEqual(2.0, x2, 0.0001);
        }

        // 7. Kiểm tra tính năng tự động sắp xếp x1 <= x2 của hàm
        [TestMethod]
        public void GiaiPTBac2_KiemTraDoiCho_x1NhoHonx2()
        {
            double x1 = 0, x2 = 0;
            // -x² + 3x - 2 = 0 => Nghiệm ban đầu tính ra x1=2, x2=1. Hàm phải tự đổi chỗ thành x1=1, x2=2.
            int ketQua = LibBaiTap.GiaiPTBac2(-1, 3, -2, ref x1, ref x2);
            
            Assert.AreEqual(2, ketQua);
            Assert.AreEqual(1.0, x1, 0.0001); 
            Assert.AreEqual(2.0, x2, 0.0001); 
        }
    }
}