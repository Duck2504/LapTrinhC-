using System;
using ThuVienBuoi02;

namespace Buoi02proj
{
    public class Bai2_2
    {
        public static void Chay()
        {
            Console.WriteLine("\n=== BÀI 2.2: THIẾT KẾ LỚP QUẢN LÝ NHÂN KHẨU ===");
            PersonList listGoc = new PersonList();
            
            Console.WriteLine("\n--- BƯỚC 1: NHẬP DANH SÁCH NHÂN KHẨU ---");
            listGoc.Input();

            Console.WriteLine("\n--- DANH SÁCH NHÂN KHẨU VỪA NHẬP ---");
            listGoc.Output();
            Console.WriteLine("\n--- BƯỚC 2: LỌC DANH SÁCH NGƯỜI CÒN SỐNG ---");
            PersonList listConSong = listGoc.LivingPeople();
            listConSong.Output();
            Console.WriteLine("\n--- BƯỚC 3: KIỂM THỬ COPY CONSTRUCTOR ---");
            Console.WriteLine("Hệ thống đang sao chép danh sách gốc sang một danh sách mới...");
            PersonList listCopy = new PersonList(listGoc);
            
            Console.WriteLine("Thêm 1 người Ẩn Danh vào danh sách COPY (kiểm tra xem danh sách gốc có bị đổi theo không)...");
            Person anDanh = new Person() { Id = "999", FullName = "Nguyễn Ẩn Danh", YearOfBirth = 2000, YearOfDeath = 0 };
            listCopy.Add(anDanh);

            Console.WriteLine("\n[Danh sách GỐC hiện tại]");
            listGoc.Output();
            
            Console.WriteLine("\n[Danh sách COPY hiện tại]");
            listCopy.Output();
        }
    }
}