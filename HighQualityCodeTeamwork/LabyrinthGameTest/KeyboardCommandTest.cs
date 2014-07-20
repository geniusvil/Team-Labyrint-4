

namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KeyboardCommandTest
    {
        static IUserCommand userCommand;
        [ClassInitialize]
        public static void UserCommandClassInicialize(TestContext testContext)
        { 
            userCommand = new KeyboardCommand();    
        }

          [TestMethod]
        public void MoveLeftTest_True()
        {
           
            ICoordinate coordinate = userCommand.MoveLeft();
            Assert.IsTrue(coordinate.Row ==0,"Row is not 0");
            Assert.IsTrue(coordinate.Col == -1, "Col is not -1");

        }



             [TestMethod]
          public void MoveLeftTest_False()
          {
              ICoordinate coordinate = userCommand.MoveLeft();
              Assert.IsFalse(coordinate.Row != 0, "Row is not 0");
              Assert.IsFalse(coordinate.Col != -1, "Col is not -1");

          }
    }
}
