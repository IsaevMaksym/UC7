using BL;
using BL.Entities;

namespace Tests
{
    public class StudentConverterTests
    {
        private StudentConverter _studentConverter;
        public StudentConverterTests()
        {
            _studentConverter = new StudentConverter();
        }

        [Fact]
        public void StudentAgeOver21AndGradeAbove90_HonorRoleIsTrueReturned()
        {
            var studentsList = GetStudent(21, 95);
            var expected = GetStudent(21, 95, false, true);

            var actual = _studentConverter.ConvertStudents(studentsList);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal(expected, actual);
            Assert.True(actual.Single().HonorRoll);
        }

        [Fact]
        public void StudentAgeUnder21AndGradeAbove90_ExceptionalIsTrueReturned()
        {
            var studentsList = GetStudent(15, 95);
            var expected = GetStudent(15, 95, true);

            var actual = _studentConverter.ConvertStudents(studentsList);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal(expected, actual);
            Assert.True(actual.Single().Exceptional);
        }

        [Theory]
        [InlineData(71)]
        [InlineData(90)]
        public void StudentGradeIs71And90_PassedIsTrueReturned(int number)
        {
            var studentsList = GetStudent(20, number);
            var expected = GetStudent(20, number, default, default, true);

            var actual = _studentConverter.ConvertStudents(studentsList);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal(expected, actual);
            Assert.True(actual.Single().Passed);
        }

        [Fact]
        public void StudentGradeIsMoreThat71AndLess90_PassedIsTrueReturned()
        {
            var randomGrade = GenerateRandomNumber(71, 90);
            var studentsList = GetStudent(15, randomGrade);
            var expected = GetStudent(15, randomGrade, default, default, true);

            var actual = _studentConverter.ConvertStudents(studentsList);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal(expected, actual);
            Assert.True(actual.Single().Passed);
        }

        [Fact]
        public void StudentGradeIsLessThen70_PassedIsFalseReturned()
        {
            var randomGrade = GenerateRandomNumber(int.MinValue, 70);
            var studentsList = GetStudent(15, randomGrade);
            var expected = GetStudent(15, randomGrade, default, default, false);

            var actual = _studentConverter.ConvertStudents(studentsList);

            Assert.NotEmpty(actual);
            Assert.Equal(expected.Count, actual.Count);
            Assert.Equal(expected, actual);
            Assert.False(actual.Single().Passed);
        }

        [Fact]
        public void EmptyArrayIsPassed_EmptyArrayReturned()
        {
            var studentsList = new List<Student>();
            var expected = new List<Student>();

            var actual = _studentConverter.ConvertStudents(studentsList);

            Assert.NotNull(actual);
            Assert.Empty(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullIsPassed_ArgumentNullExceptionIsThrown()
        {
            List<Student> students = null;

            Assert.Throws<ArgumentNullException>(() => _studentConverter.ConvertStudents(students));
        }

        [Fact]
        public void NullStudentPassedInTheList_NullReferenceExceptionIsThrown()
        {
            Student student = null;
            List<Student> students = new List<Student> { student };

            Assert.Throws<NullReferenceException>(() => _studentConverter.ConvertStudents(students));
        }

        private List<Student> GetStudent(int age, int grade,
            bool exceptional = default, bool honorRoll = default, bool passed = default)
        {
            return new List<Student>
            {
                new Student
                {
                    Name = "SomeRandomName",
                    Age = age,
                    Grade = grade,
                    Exceptional = exceptional,
                    HonorRoll = honorRoll,
                    Passed = passed
                }
            };
        }

        private static int GenerateRandomNumber(int minValue, int maxValue)
        {
            var random = new Random();

            return random.Next(minValue, maxValue + 1);
        }
    }
}
