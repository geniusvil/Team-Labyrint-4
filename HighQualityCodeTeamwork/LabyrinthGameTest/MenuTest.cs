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
            using (StringReader sr = new StringReader("D"))
            {
                Console.SetIn(sr);

                var testMenu = new Menu();
                var result = testMenu.GetLabyrinthTypeFromUser();
                Assert.AreEqual("d", result);

            }
        }

        [TestMethod]
        public void TestMenuGetUserChoice()
        {
            using (StringReader sr = new StringReader("1"))
            {
                Console.SetIn(sr);

                var testMenu = new Menu();
                var result = testMenu.GetUserChoice();
                Assert.AreEqual("1", result);

            }
        }

        [TestMethod]
        public void TestMainMenu()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var testMenu = new Menu();
                testMenu.MainMenu();
                var stringResult = "Welcome to “LABYRINTH” game.\r\n\nPlease choose between 1, 2, 3 and 4\n\r\n  1 : START\r\n  2 : RESTART\r\n  3 : SCOREBOARD\r\n  4 : EXIT\n\r\n";
                Assert.AreEqual(stringResult, sw.ToString());

            }
        }

        [TestMethod]
        public void TestMenuDuringPlay()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var testMenu = new Menu();
                testMenu.MenuDuringPlay();
                var stringResult = "Welcome to “LABYRINTH” game.\r\n\r\n  RightArrow - Move Right\r\n  LeftArrow  - Move Left\r\n  UpArrow    - Move Up\r\n  DownArrow  - Move Down\r\n\r\n";
                Assert.AreEqual(stringResult, sw.ToString());

            }
        }


    }
}