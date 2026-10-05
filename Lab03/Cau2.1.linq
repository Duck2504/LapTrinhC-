<Query Kind="Statements" />

int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

var cauA = mangSo.Where(n => n % 4 == 0 && n % 3 == 0);
cauA.Dump("a. Các phần tử chia hết cho 4 và 3");

var cauB = mangSo.Where(n => n <= 3);
cauB.Dump("b. Các phần tử nhỏ hơn hoặc bằng 3");

var cauC = mangSo.Select(n => (n % 2 == 0) ? (n / 2) : n);
cauC.Dump("c. Dãy mới (chẵn chia đôi, lẻ giữ nguyên)");