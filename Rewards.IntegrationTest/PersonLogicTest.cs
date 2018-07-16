using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rewards.DAL.Interface;
using Rewards.BLL.Interface;
using Rewards.Container;
using Ninject;
using Rewards.Entities;

namespace Rewards.IntegrationTest
{
    [TestClass]
    public class PersonLogicTest
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            var id = personLogic.Add("Alex", "Pak", new DateTime(1997, 10, 10), 21,
                "Saratov", "Chapaeva", "60");
        }

        [TestMethod]
        public void TestAdding()
        {
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            
            var person = new Person
            {
                Name = "Alex",
                Surname = "Pak",
                DateOfBirth = new DateTime(1997, 10, 10),
                Age = 21,
                City = "Saratov",
                Street = "Chapaeva",
                NumberOfHouse = "60"
            };

            Assert.AreEqual(Person.ToString(personLogic.GetById(id)), Person.ToString(person),
                "Error adding");
        }

    }
}
