namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestStudent_ConstructorMustSetProperties()
        {
            var firstName = "Pesho";
            var lastName = "Markov";
            var number = 25000;

            var pesho = new Student(firstName, lastName, number);

            Assert.AreEqual(firstName, pesho.FirstName);
            Assert.AreEqual(lastName, pesho.LastName);
            Assert.AreEqual(number, pesho.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudent_ConstructorMustThrowIfFirstNameIsInvalid()
        {
            var firstName = string.Empty;
            var lastName = "Markov";
            var number = 25000;

            var pesho = new Student(firstName, lastName, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudent_ConstructorMustThrowIfLastNameIsInvalid()
        {
            var firstName = "Pesho";
            var lastName = string.Empty;
            var number = 25000;

            var pesho = new Student(firstName, lastName, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudent_ConstructorMustThrowIfNumberIsLessThan10000()
        {
            var firstName = "Pesho";
            var lastName = "Markov";
            var number = 10;

            var pesho = new Student(firstName, lastName, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudent_ConstructorMustThrowIfNumberIsGreaterThan99999()
        {
            var firstName = "Pesho";
            var lastName = "Markov";
            var number = 102000;

            var pesho = new Student(firstName, lastName, number);
        }
    }
}
