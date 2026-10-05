using System;

namespace ThuVienBuoi02
{
    public class Person
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int YearOfBirth { get; set; }
        public int YearOfDeath { get; set; }

        public Person()
        {
            Id = "N/A";
            FullName = "Unknown";
            YearOfBirth = 0;
            YearOfDeath = 0;
        }
        public Person(Person otherPerson)
        {
            this.Id = otherPerson.Id;
            this.FullName = otherPerson.FullName;
            this.YearOfBirth = otherPerson.YearOfBirth;
            this.YearOfDeath = otherPerson.YearOfDeath;
        }
        public void Input()
        {
            Console.Write("  Nhập ID: ");
            Id = Console.ReadLine();

            Console.Write("  Nhập Họ và Tên (FullName): ");
            FullName = Console.ReadLine();

            Console.Write("  Nhập năm sinh (Year of Birth): ");
            int inputYearOfBirth;
            while (!int.TryParse(Console.ReadLine(), out inputYearOfBirth) || inputYearOfBirth <= 0)
            {
                Console.Write("  Lỗi! Vui lòng nhập lại năm sinh (>0): ");
            }
            YearOfBirth = inputYearOfBirth;
            Console.Write("  Nhập năm mất (Year of Death - Nhập 0 nếu còn sống): ");
            int inputYearOfDeath;
            while (!int.TryParse(Console.ReadLine(), out inputYearOfDeath) || (inputYearOfDeath != 0 && inputYearOfDeath < YearOfBirth))
            {
                Console.Write($"  Lỗi! Năm mất không hợp lệ (phải >= {YearOfBirth} hoặc bằng 0). Nhập lại: ");
            }
            YearOfDeath = inputYearOfDeath;
        }
        public void Output()
        {
            string lifeStatus = IsLiving() ? "Còn sống" : $"Đã mất năm {YearOfDeath}";
            Console.WriteLine($"[ID: {Id}] Tên: {FullName} | Sinh năm: {YearOfBirth} | Trạng thái: {lifeStatus}");
        }
        public bool IsLiving()
        {
            return YearOfDeath == 0;
        }
    }
}