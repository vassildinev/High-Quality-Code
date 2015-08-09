namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoursesTests
    {
        [TestMethod]
        public void TestCourse_ConstructorMustSetProperties()
        {
            var name = "Stamat";
            var course = new Course(name);

            Assert.AreEqual(name, course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourse_ConstructorMustThrowIfNameIsInvalid()
        {
            var name = string.Empty;
            var course = new Course(name);
        }

        [TestMethod]
        public void TestCourse_AddMethodMustAddTheStudentToTheCourseListOfStudents()
        {
            var name = "Gosho";
            var student = new Student("Pesho", "Markov", 19000);

            var course = new Course(name);
            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count);
            Assert.AreEqual(student, course.Students[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourse_AddMethodMustAddThrowWhenAddingOver30Student()
        {
            var name = "Gosho";
            
            var course = new Course(name);
            for(var i = 0; i < 30; i++)
            {
                var student = new Student("Pesho" + i, "Markov", 19000 + 100 * i);
                course.AddStudent(student);
            }

            course.AddStudent(new Student("Stamat", "Stamatov", 50000));
        }

        [TestMethod]
        public void TestCourse_RemoveMethodMustRemoveTheStudentFromTheCourseListOfStudents()
        {
            var name = "Gosho";
            var student = new Student("Pesho", "Markov", 19000);

            var course = new Course(name);
            course.AddStudent(student);
            course.RemoveStudent(student);

            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourse_RemoveMethodMustThrowIfStudentsListIsEmpty()
        {
            var name = "Gosho";
            var student = new Student("Pesho", "Markov", 19000);
            var course = new Course(name);

            course.RemoveStudent(student);
        }
    }
}
