<Query Kind="Statements" />

int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

//a
int tongSoPhanTu = mangSo.Count();
int soPhanTuChan = mangSo.Count(n => n % 2 == 0);
int soPhanTuLe = mangSo.Count(n => n % 2 != 0);

Console.WriteLine("a. Thống kê phần tử:");
Console.WriteLine($"Tổng số phần tử: {tongSoPhanTu}");
Console.WriteLine($"Số phần tử chẵn: {soPhanTuChan}");
Console.WriteLine($"Số phần tử lẻ: {soPhanTuLe}");

//b
int tongGiaTri = mangSo.Sum();
int maxGiaTri = mangSo.Max();
int minGiaTri = mangSo.Min();

Console.WriteLine("b. Tính toán giá trị:");
Console.WriteLine($"- Tổng các giá trị: {tongGiaTri}");
Console.WriteLine($"- Giá trị lớn nhất: {maxGiaTri}");
Console.WriteLine($"- Giá trị nhỏ nhất: {minGiaTri}\n");

//c
int soGiaTriKhacNhau = mangSo.Distinct().Count();
Console.WriteLine($"c. Số lượng các giá trị khác nhau: {soGiaTriKhacNhau}\n");

//d
var nhomTheoSoDu = mangSo.GroupBy(n => n % 5);

Console.WriteLine("d. Phân nhóm theo số dư khi chia cho 5:");
foreach (var i in nhomTheoSoDu)
{
    Console.WriteLine($"- Nhóm số dư {i.Key}: {string.Join(", ", i)}");
}