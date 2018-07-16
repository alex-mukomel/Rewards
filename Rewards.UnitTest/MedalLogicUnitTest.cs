using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rewards.Entities;
using Rewards.BLL;
using Rewards.DAL.Interface;
using System.Linq;
using System.Collections.Generic;

namespace Rewards.UnitTests
{
    [TestClass]
    public class MedalsLogicUnitTests
    {
        int id;

        [TestMethod]
        public void AddCorrect()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(5);
            var logic = new MedalsLogic(mock.Object);

            id = logic.Add("GG", "Ice");

            Assert.AreEqual(id, 5, "Error adding.");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void AddNullName()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(7);
            var logic = new MedalsLogic(mock.Object);

            logic.Add(null, "Gold");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void AddNullMaterial()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(7);
            var logic = new MedalsLogic(mock.Object);

            logic.Add("For success...", null);
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void UpdateNullName()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Medal
                {
                    Name = "For success...",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));

            logic.Update(0, null, "Silver");
        }

        [ExpectedException(typeof(ArgumentNullException), "Value not null.")]
        [TestMethod]
        public void UpdateNullMaterial()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.GetById(It.IsAny<int>())).Returns(
                new Medal
                {
                    Name = "For success...",
                    Material = "Gold"
                });
            var logic = new MedalsLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));

            logic.Update(0, "...", null);
        }

        [TestMethod]
        public void TryGetAll()
        {
            var mock = new Mock<IMedalDao>();
            mock.Setup(item => item.GetAll()).Returns(new List<Medal>()
            {
                new Medal
                 {
                     Name = "For success...",
                     Material = "Bronze"
                 }
            });
            var logic = new MedalsLogic(mock.Object);
            var list = logic.GetAll().ToList();
            Assert.AreEqual(list.Count, 1, "Error GetAll.");
        }
    }
}
