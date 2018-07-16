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
        private static int id;
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();
            id = personLogic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
                "Samara", "Chapaeva", "22/24");
        }

        [TestMethod]
        public void TestAdding()
        {
            //NinjectCommon.Registration();
            var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();


            id = personLogic.Add("Vyacheslav", "Soloviev", new DateTime(1995, 12, 27), 23,
                "Samara", "Chapaeva", "22/24");
            var person = new Person
            {
                Name = "Vyacheslav",
                Surname = "Soloviev",
                DateOfBirth = new DateTime(1995, 12, 27),
                Age = 23,
                City = "Samara",
                Street = "Chapaeva",
                NumberOfHouse = "22/24"
            };

            Assert.AreEqual(Person.ToString(personLogic.GetById(id)), Person.ToString(person),
                "Adding data about person incorrect");
        }

        //[TestMethod]
        //public void TestUpdating()
        //{
        //    //NinjectCommon.Registration();
        //    var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();

        //    Person person = personLogic.GetById(id);
        //    person.Name = "Igor";

        //    personLogic.Update(id, "Igor", "Soloviev", new DateTime(1995, 12, 27), 23,
        //        "Samara", "Chapaeva", "22/24");

        //    Assert.AreEqual(personLogic.ToString(personLogic.GetById(id)), personLogic.ToString(person),
        //        "Adding data about person incorrect");
        //}

        //[ExpectedException(typeof(NullReferenceException), "This item must be null")]
        //[TestMethod]
        //public void TestDeleting()
        //{
        //    //NinjectCommon.Registration();
        //    var personLogic = NinjectCommon.Kernel.Get<IPeopleLogic>();

        //    Person person = personLogic.GetById(id);

        //    personLogic.Delete(id);

        //    Assert.AreEqual(personLogic.ToString(personLogic.GetById(id)), personLogic.ToString(person),
        //        "Adding data about person incorrect");
        //}

    }
}
