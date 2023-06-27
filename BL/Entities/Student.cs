using System;

namespace BL.Entities
{
    public class Student : IEquatable<Student>
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public bool Exceptional { get; set; }
        public bool HonorRoll { get; set; }
        public bool Passed { get; set; }

        public bool Equals(Student? other)
        {
            if (other == null)
                return false;

            return
                (
                    object.ReferenceEquals(this.Name, other.Name) ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) &&
                this.Age == other.Age &&
                this.Grade == other.Grade &&
                this.Exceptional == other.Exceptional &&
                this.HonorRoll == other.HonorRoll &&
                this.Passed == other.Passed;
        }     
    }

}
