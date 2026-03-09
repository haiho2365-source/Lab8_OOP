using System;
using System.Runtime.Serialization;

namespace LAB08
{
    [Serializable]
    public class Human : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Human() { }

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Human(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Age = info.GetInt32("Age");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}

