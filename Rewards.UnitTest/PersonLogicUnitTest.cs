using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rewards.Entities;
using Rewards.BLL;
using Rewards.DAL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Rewards.UnitTest
{
    [TestClass]
    public class PersonLogicUnitTest
    {
        int id;

        [TestMethod]
        public void AddingCorrect()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "60");

            Assert.AreEqual(id, 4, "Error adding");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void AddNullName()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add(null, "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void AddNullSurname()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", null, new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "Correct date.")]
        [TestMethod]
        public void AddWrongDate()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), 
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(2020, 11, 05), 21,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "Correct age.")]
        [TestMethod]
        public void AddWrongAge()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 19,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "City name is correct.")]
        [TestMethod]
        public void AddIncorrectCity()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), 
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov53535", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "City not null.")]
        [TestMethod]
        public void AddNullCity()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), 
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 21,
                null, "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentNullException), "Street not null.")]
        [TestMethod]
        public void AddNullStreet()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), 
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", null, "60");
        }

        [ExpectedException(typeof(ArgumentException), "Name not null.")]
        [TestMethod]
        public void AddIncorrectNumberOfHouse()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), 
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "bb");
        }

        [ExpectedException(typeof(ArgumentException), "Name not null.")]
        [TestMethod]
        public void AddNullNumberOfHouse()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), 
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            var logic = new PeopleLogic(mock.Object);
            id = logic.Add("Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", null);
        }

        [TestMethod]
        public void TryGetAll()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetAll()).Returns(new List<Person>()
            {
                new Person
                 {
                     Name = "Alex",
                     Surname = "Pak",
                     DateOfBirth = new DateTime(1997, 11, 05),
                     Age = 21,
                     City = "Saratov",
                     Street = "Chapaeva",
                     NumberOfHouse = "60"
                 }
            });
       
            var logic = new PeopleLogic(mock.Object);
            var list = logic.GetAll().ToList();
            Assert.AreEqual(list.Count, 1, "...");
        }


        [TestMethod]
        public void CorrectDataUpdating()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            Person person = new Person
            {
                Name = "Alex",
                Surname = "Pak",
                DateOfBirth = new DateTime(1997, 11, 05),
                Age = 21,
                City = "Saratov",
                Street = "Chapaeva",
                NumberOfHouse = "60"
            };

            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Volskaya", "73");

            Assert.AreEqual(Person.ToString(logic.GetById(0)), Person.ToString(person), "Error updating.");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void UpdateNullName()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, null, "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void UpdateNullSurname()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", null, new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "Correct date.")]
        [TestMethod]
        public void UpdateWrongDate()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(2020, 11, 05), 21,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "Correct age.")]
        [TestMethod]
        public void UpdateWrongAge()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 15,
                "Saratov", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "City name is correct.")]
        [TestMethod]
        public void UpdateIncorrectCity()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov346436", "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentException), "City not null.")]
        [TestMethod]
        public void UpdateNullCity()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 21,
                null, "Chapaeva", "60");
        }

        [ExpectedException(typeof(ArgumentNullException), "Street not null.")]
        [TestMethod]
        public void UpdateNullStreet()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", null, "60");
        }

        [ExpectedException(typeof(ArgumentException), "Name not null.")]
        [TestMethod]
        public void UpdateIncorrectHouseNumber()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov", "Chapaeva", "rr");
        }

        [ExpectedException(typeof(ArgumentException), "Name not null.")]
        [TestMethod]
        public void UpdateNullHouseNumber()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Person
                {
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });
            var logic = new PeopleLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            logic.Update(0, "Alex", "Pak", new DateTime(1997, 11, 05), 21,
                "Saratov346436", "Chapaeva", null);
        }

        [TestMethod]
        public void GetByIdPerson()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.Is<int>(v => v == 4))).Returns(
                new Person
                {
                    Id = 4,
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });

            var logic = new PeopleLogic(mock.Object);

            Person person = new Person
            {
                Id = 4,
                Name = "Alex",
                Surname = "Pak",
                DateOfBirth = new DateTime(1997, 11, 05),
                Age = 21,
                City = "Saratov",
                Street = "Chapaeva",
                NumberOfHouse = "60"
            };

            Assert.AreEqual(Person.ToString(logic.GetById(4)), Person.ToString(person), "Error GetById.");
        }

        [ExpectedException(typeof(Exception), "Person is exist.")]
        [TestMethod]
        public void DeletePerson()
        {
            var mock = new Mock<IPersonDao>();
            mock.Setup(item => item.GetById(It.Is<int>(v => v == 7))).Returns(
                new Person
                {
                    Id = 4,
                    Name = "Alex",
                    Surname = "Pak",
                    DateOfBirth = new DateTime(1997, 11, 05),
                    Age = 21,
                    City = "Saratov",
                    Street = "Chapaeva",
                    NumberOfHouse = "60"
                });

            mock.Setup(item => item.GetById(It.Is<int>(v => v == 12))).Returns(
                new Person
                {
                    Id = 12,
                    Name = "Alex",
                    Surname = "Mukomel",
                    DateOfBirth = new DateTime(1996, 10, 04),
                    Age = 21,
                    City = "Saratov",
                    Street = "Volskaya",
                    NumberOfHouse = "73"
                });

            mock.Setup(item => item.Delete(It.IsAny<int>()));

            var logic = new PeopleLogic(mock.Object);
            logic.Delete(10);
        }
    }
}
