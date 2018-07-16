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
            id = medalLogic.Add("...", "Gold");
        }


        [TestMethod]
        public void TestUpdating()
        {
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();

            Medal medal = medalLogic.GetById(id);
            medal.Name = "update";
            medalLogic.Update(id, "update", "Gold");

            Assert.AreEqual(Medal.ToString(medalLogic.GetById(id)), Medal.ToString(medal),
                "Error updating");
        }

        [ExpectedException(typeof(NullReferenceException), "...")]
        [TestMethod]
        public void TestDeleting()
        {
            var medalLogic = NinjectCommon.Kernel.Get<IMedalsLogic>();

            Medal medal = medalLogic.GetById(id);
            medalLogic.Delete(id);

            Assert.AreEqual(Medal.ToString(medalLogic.GetById(id)), Medal.ToString(medal),
                "Error updating");
        }
    }
}
