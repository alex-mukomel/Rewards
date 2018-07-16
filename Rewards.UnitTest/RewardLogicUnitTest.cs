using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rewards.BLL;
using Rewards.DAL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Rewards.UnitTests
{
    [TestClass]
    public class RewardsLogicUnitTests
    {

        [TestMethod]
        public void TryGetAll()
        {
            var mock = new Mock<IRewardDao>();
            mock.Setup(item => item.GetAll()).Returns(new List<string>()
            {
                "Alex Pak - Gold: For success...",
                "Alex Mukomel - Silver For ...",
                "Pavel Turchenkov - Bronze: For brain...",
                "Alex Mukomel - Gold For ...",
                "Pavel Turchenkov - Gold: For brain..."
            });

            var logic = new RewardsLogic(mock.Object);
            var list = logic.GetAll().ToList();
            Assert.AreEqual(list.Count, 5);
        }
    }
}
