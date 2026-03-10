using System;
using System.IO;
using System.Runtime.Serialization;
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


            Console.WriteLine(" DỮ LIỆU TRƯỚC KHI LƯU ");



            string filePath = "company_data.xml";


            Type[] knownTypes = new Type[] { typeof(Employee), typeof(List<Employee>), typeof(Human) };

            DataContractSerializer serializer = new DataContractSerializer(typeof(Company), knownTypes);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.WriteObject(fs, myCompany);
                Console.WriteLine($"[System] Đã lưu dữ liệu ra file: {filePath}");
            }


            Console.WriteLine(" DỮ LIỆU ĐỌC LÊN TỪ FILE ");
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Company loadedCompany = (Company)serializer.ReadObject(fs);

                if (loadedCompany != null)
                {
                    loadedCompany.PrintPayroll();
                }
            }
        }
    }
}
