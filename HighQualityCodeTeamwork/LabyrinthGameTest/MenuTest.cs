using System;
using System.IO;
using LabyrinthGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthGameTest
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void TestMenuGetChoiceTypeHex()
        {
            using (StringReader sw = new StringReader("H"))
            {
                Console.SetIn(sw);

                var testMenu = new Menu();
                var result = testMenu.GetLabyrinthTypeFromUser();
                Assert.AreEqual("h", result);

            }
        }

        [TestMethod]
        public void TestMenuGetChoiceTypeDiamond()
        {
            using (StringReader sw = new StringReader("D"))
            {
                Console.SetIn(sw);

                var testMenu = new Menu();
                var result = testMenu.GetLabyrinthTypeFromUser();
                Assert.AreEqual("d", result);

            }
        }

        [TestMethod]
        public void TestMenuGetUserChoice()
        {
            using (StringReader sw = new StringReader("1"))
            {
                Console.SetIn(sw);

                var testMenu = new Menu();
                var result = testMenu.GetUserChoice();
                Assert.AreEqual("1", result);

            }
        }

        [TestMethod]
        public void TestMenuGetUserChoiceNonValid()
        {
            using (StringReader sw = new StringReader("9"))
            {
                Console.SetIn(sw);

                var testMenu = new Menu();
                var result = testMenu.GetUserChoice();
                Assert.Fail();

            }
        }
    }
}