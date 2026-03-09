using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LAB08
{
    [Serializable]
    public class Company : ISerializable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Company() { }

        public Company(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
        }

        public Company(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Address = info.GetString("Address");
            Employees = (List<Employee>)info.GetValue("Employees", typeof(List<Employee>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Address", Address);
            info.AddValue("Employees", Employees);
        }

        public void PrintPayroll()
        {
            double totalSalaryPaid = 0;
            Console.WriteLine($"\n=== BẢNG LƯƠNG CÔNG TY: {Name.ToUpper()} ===");
            Console.WriteLine($"Địa chỉ: {Address}");
            Console.WriteLine(new string('-', 60));

            foreach (var emp in Employees)
            {
                double salary = emp.CalculateSalary();
                totalSalaryPaid += salary;
                Console.WriteLine($"Nhân viên: {emp.Name,-15} | ID: {emp.Id,-5} | Lương: {salary:N0} VND");
            }

            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"TỔNG LƯƠNG ĐÃ CHI TRONG THÁNG: {totalSalaryPaid:N0} VND\n");
        }
    }
}

