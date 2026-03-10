using System;
using System.Text;

namespace LAB08
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Company myCompany = new Company("TechCorp C#", "Quận 1, TP.HCM");

            myCompany.AddEmployee(new Employee("Nguyen Van A", 30, "EMP01", 5000000, 2.34, new DateTime(2020, 1, 1), "Đại học"));
            myCompany.AddEmployee(new Employee("Tran Thi B", 28, "EMP02", 5000000, 2.34, new DateTime(2021, 5, 10), "Đại học"));
            myCompany.AddEmployee(new Employee("Le Van C", 25, "EMP03", 5000000, 2.34, new DateTime(2024, 2, 15), "Cao đẳng"));
            myCompany.AddEmployee(new Employee("Pham Thi D", 24, "EMP04", 5000000, 2.34, new DateTime(2025, 8, 20), "Đại học"));
            myCompany.AddEmployee(new Employee("Hoang Van E", 35, "EMP05", 5000000, 3.00, new DateTime(2015, 3, 1), "Thạc sĩ"));

            Console.WriteLine("--- DỮ LIỆU BẢNG LƯƠNG NHÂN VIÊN ---");
            myCompany.PrintPayroll();
        }
    }
}
