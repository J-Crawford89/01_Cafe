using System;
using System.Collections.Generic;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class RepoTests
    {
        MenuItem newItem = new MenuItem(1, "burger");
        MenuItem itemTwo = new MenuItem(2, "taco");
        MenuRepository newRepo = new MenuRepository();
        [TestMethod]
        public void AddToDirectory_ShouldReturnCorrectBool()
        {
            bool wasAdded = newRepo.AddToDirectory(newItem);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void RemoveFromDirectory_ShouldReturnCorrectBool()
        {
            newRepo.AddToDirectory(newItem);
            bool wasRemoved = newRepo.RemoveFromDirectory(newItem);

            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void GetCount_ShouldReturnCorrectCout()
        {
            newRepo.AddToDirectory(newItem);
            newRepo.AddToDirectory(itemTwo);
            int actual = newRepo.GetDirectoryCount();
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetItemByIndex_ShouldReturnCorrectItem()
        {
            newRepo.AddToDirectory(newItem);
            newRepo.AddToDirectory(itemTwo);

            MenuItem actual = newRepo.GetItemByIndex(0);

            Assert.AreEqual(newItem, actual);
        }
    }
}
