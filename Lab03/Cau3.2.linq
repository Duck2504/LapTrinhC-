<Query Kind="Statements" />

string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
"Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
"Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

// a
int minLength = monAn.Min(m => m.Length);
int maxLength = monAn.Max(m => m.Length);

var monNganNhat = monAn.Where(m => m.Length == minLength);
var monDaiNhat = monAn.Where(m => m.Length == maxLength);

Console.WriteLine("a. Món ăn có tên ngắn nhất và dài nhất:");
Console.WriteLine($"- Ngắn nhất ({minLength} ký tự): {string.Join(", ", monNganNhat)}");
Console.WriteLine($"- Dài nhất ({maxLength} ký tự): {string.Join(", ", monDaiNhat)}\n");

// b
var nhomTheoTuDau = monAn.GroupBy(m => m.Split(' ')[0]);

Console.WriteLine("b. Phân nhóm theo từ đầu tiên:");
foreach (var nhom in nhomTheoTuDau)
{
    Console.WriteLine($"- Nhóm '{nhom.Key}': {string.Join(", ", nhom)}");
}
Console.WriteLine();

// c
int soMonBanh = monAn.Count(m => m.Split(' ')[0] == "Bánh");

Console.WriteLine($"c. Số lượng món có từ đầu tiên là 'Bánh': {soMonBanh}");