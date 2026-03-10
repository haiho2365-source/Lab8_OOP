using System;
using System.IO;
using System.Runtime.Serialization; // Thư viện dùng cho DataContractSerializer

class Program
{
    static void Main()
    {
        // 1. Khởi tạo dữ liệu
        Company myCompany = new Company("TechCorp C#", "Quận 1, TP.HCM");

        // Thêm 5 nhân viên (lương cơ bản 5,000,000; hệ số khởi điểm 2.34)
        myCompany.AddEmployee(new Employee("Nguyen Van A", 30, "EMP01", 5000000, 2.34, new DateTime(2020, 1, 1), "Đại học"));
        myCompany.AddEmployee(new Employee("Tran Thi B", 28, "EMP02", 5000000, 2.34, new DateTime(2021, 5, 10), "Đại học"));
        myCompany.AddEmployee(new Employee("Le Van C", 25, "EMP03", 5000000, 2.34, new DateTime(2024, 2, 15), "Cao đẳng"));
        myCompany.AddEmployee(new Employee("Pham Thi D", 24, "EMP04", 5000000, 2.34, new DateTime(2025, 8, 20), "Đại học"));
        myCompany.AddEmployee(new Employee("Hoang Van E", 35, "EMP05", 5000000, 3.00, new DateTime(2015, 3, 1), "Thạc sĩ"));

        // 2. In bảng lương ban đầu
        Console.WriteLine("--- DỮ LIỆU TRƯỚC KHI LƯU ---");
        myCompany.PrintPayroll();

        // Tên file lưu trữ (DataContractSerializer thường xuất ra định dạng xml)
        string filePath = "company_data.xml"; 

        // 3. Thực hiện Serialization (Ghi ra file sử dụng DataContractSerializer và FileStream)
        DataContractSerializer serializer = new DataContractSerializer(typeof(Company));
        
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.WriteObject(fs, myCompany);
            Console.WriteLine($"[System] Đã lưu dữ liệu ra file: {filePath}");
        }

        // 4. Thực hiện Deserialization (Đọc lại dữ liệu từ file)
        Console.WriteLine("\n--- DỮ LIỆU ĐỌC LÊN TỪ FILE ---");
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
