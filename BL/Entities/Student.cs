using System;
using System.Diagnostics.CodeAnalysis;

namespace BL.Entities
{
    public class Student : IEquatable<Student>, IEqualityComparer<Student>
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

        public bool Equals(Student? x, Student? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.Name == y.Name && x.Age == y.Age &&
                x.Grade == y.Grade &&
                x.Exceptional == y.Exceptional &&
                x.HonorRoll == y.HonorRoll &&
                x.Passed == y.Passed;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            int hash = 1;

            hash = hash + obj.Age.GetHashCode();
            hash = hash + obj.Grade.GetHashCode();
            hash = hash + obj.Passed.GetHashCode();
            hash = hash + obj.HonorRoll.GetHashCode();

            return hash;
        }
    }

}
