using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListForText.Test
{
    [TestClass]
    public class ListTest1
    {
        [TestMethod]
        public void IsCreateble_IfLengthsareEqual()
        {
            int pointer = 1;
            int length = 5;
            int pointer_ = 2;
            int length_ = 5;
            var expected = false;

            VirtualRAM c = new VirtualRAM();
            var result = c.IsCreateble(pointer, length, pointer_, length_);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsCreatebleReturnFalse()
        {
            int pointer = 5;
            int length = 3;
            int pointer_ = 4;
            int length_ = 5;
            var expected = false;

            VirtualRAM c = new VirtualRAM();
            var result = c.IsCreateble(pointer, length, pointer_, length_);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsCreatebleReturnTrue()
        {
            int pointer = 6;
            int length = 3;
            int pointer_ = 4;
            int length_ = 5;
            var expected = true;

            VirtualRAM c = new VirtualRAM();
            var result = c.IsCreateble(pointer, length, pointer_, length_);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TakeMemoryCorrectWork()
        {
            int pointer = 1;
            int length = 5;
            var expected = true;

            VirtualRAM c = new VirtualRAM();
            var result = c.TakeMemory(pointer, length);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModificationDeleteBlock()
        {
            int index = 0;
            int newPoiner = 0;
            int newLenght = 0;
            var expected = true;

            VirtualRAM c = new VirtualRAM();
            var result = c.Modification(index, newPoiner, newLenght);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModificationIsNotDeleted()
        {
            int index = 1;
            int newPoiner = 0;
            int newLenght = 3;
            var expected = false;

            VirtualRAM c = new VirtualRAM();
            var result = c.Modification(index, newPoiner, newLenght);
            Assert.AreEqual(expected, result);
        }



    }
}
