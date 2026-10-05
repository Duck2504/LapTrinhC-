<Query Kind="Statements" />

string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", 
"Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

var CauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s=> s[0]);
CauA.Dump("a. Các phần tử có 4 kí tự");

var CauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
CauB.Dump("b. Biến đổi chữ thường thành chữ hoa");

var CauC = mangChuoi.Where(s => s.Contains("u"));
CauC.Dump("c.Các phần tử có kí tự u");

var CauD = mangChuoi.Where(s => char.IsUpper(s[0]));
CauD.Dump("d. các phần tử bắt đầu bằng chữ in hoa");