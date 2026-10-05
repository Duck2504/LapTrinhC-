using System;
using System.Collections.Generic;

namespace ThuVienBuoi02
{
    public class PersonList
    {
        private List<Person> danhSach;
        public PersonList()
        {
            danhSach = new List<Person>();
        }
        public PersonList(PersonList otherList)
        {
            danhSach = new List<Person>();
            foreach (Person p in otherList.danhSach)
            {
                this.danhSach.Add(new Person(p));
            }
        }

        public void Input()
        {
            Console.Write("Nhập số lượng nhân khẩu cần quản lý: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.Write("Lỗi! Vui lòng nhập lại số lượng (>= 0): ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin người thứ {i + 1} ---");
                Person p = new Person();
                p.Input();
                this.Add(p);
            }
        }

        public void Output()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("  (Danh sách trống)");
                return;
            }

            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.Write($"  {i + 1}. ");
                danhSach[i].Output();
            }
        }

        public void Add(Person x)
        {
            danhSach.Add(x);
        }
        public PersonList LivingPeople()
        {
            PersonList resultList = new PersonList();
            foreach (Person p in this.danhSach)
            {
                if (p.IsLiving()) 
                {
                    resultList.Add(p);
                }
            }
            return resultList;
        }
    }
}