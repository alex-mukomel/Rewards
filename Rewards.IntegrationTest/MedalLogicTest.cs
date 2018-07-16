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
    public class MedalLogicTest
    {
        private static int id;
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            NinjectCommon.Registration();
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();
            id = medalLogic.Add("For test", "Bronze");
        }


        [TestMethod]
        public void TestUpdating()
        {
            //NinjectCommon.Registration();
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();

            Medal medal = medalLogic.GetById(id);
            medal.Name = "For update";

            medalLogic.Update(id, "For update", "Bronze");

            Assert.AreEqual(Medal.ToString(medalLogic.GetById(id)), Medal.ToString(medal),
                "Adding data about person incorrect");
        }

        [ExpectedException(typeof(NullReferenceException), "This item must be null")]
        [TestMethod]
        public void TestDeleting()
        {
            //NinjectCommon.Registration();
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();

            Medal medal = medalLogic.GetById(id);

            medalLogic.Delete(id);

            Assert.AreEqual(Medal.ToString(medalLogic.GetById(id)), Medal.ToString(medal),
                "Adding data about person incorrect");
        }
    }
}
