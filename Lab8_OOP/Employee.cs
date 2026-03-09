using System;
using System.Runtime.Serialization;

namespace LAB08
{
    [Serializable]
    public class Employee : Human, ISerializable
    {
        public string Id { get; set; }
        public double BaseSalary { get; set; }
        public double CoefSalary { get; set; }
        public DateTime ParticipateDate { get; set; }
        public string EducationLevel { get; set; }

        public Employee() { }

        public Employee(string name, int age, string id, double baseSalary, double coefSalary, DateTime participateDate, string educationLevel)
            : base(name, age)
        {
            Id = id;
            BaseSalary = baseSalary;
            CoefSalary = coefSalary;
            ParticipateDate = participateDate;
            EducationLevel = educationLevel;
        }

        public Employee(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Id = info.GetString("Id");
            BaseSalary = info.GetDouble("BaseSalary");
            CoefSalary = info.GetDouble("CoefSalary");
            ParticipateDate = (DateTime)info.GetValue("ParticipateDate", typeof(DateTime));
            EducationLevel = info.GetString("EducationLevel");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Id", Id);
            info.AddValue("BaseSalary", BaseSalary);
            info.AddValue("CoefSalary", CoefSalary);
            info.AddValue("ParticipateDate", ParticipateDate);
            info.AddValue("EducationLevel", EducationLevel);
        }


        public double CalculateSalary()
        {
            int yearsWorked = DateTime.Now.Year - ParticipateDate.Year;

            if (DateTime.Now < ParticipateDate.AddYears(yearsWorked))
            {
                yearsWorked--;
            }

            int increases = yearsWorked / 3;
            double currentCoef = CoefSalary + (increases * 0.3);

            return currentCoef * BaseSalary;
        }

        public override string ToString()
        {
            return base.ToString() + $", ID: {Id}, Lương thực nhận: {CalculateSalary():N0} VND";
        }
    }
}

