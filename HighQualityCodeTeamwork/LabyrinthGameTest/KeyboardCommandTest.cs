namespace LabyrinthGameTest
{
    using System;
    using LabyrinthGame;
    using LabyrinthGame.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KeyboardCommandTest
    {

        private static IUserCommand userCommand;

        [ClassInitialize]
        public static void UserCommandClassInicialize(TestContext testContext)
        {
            userCommand = new KeyboardCommand();
        }

        [TestMethod]
        public void MoveLeftTestTrue()

        {
            ICoordinate coordinate = userCommand.MoveLeft();
            Assert.IsTrue(coordinate.Row == 0, "Row is not 0");
            Assert.IsTrue(coordinate.Col == -1, "Col is not -1");
        }

         [TestMethod]
          public void MoveLeftTestFalse()
          {
              ICoordinate coordinate = userCommand.MoveLeft();
              Assert.IsFalse(coordinate.Row != 0, "Row is not 0");
              Assert.IsFalse(coordinate.Col != -1, "Col is not -1");
          }

         [TestMethod]
         public void MoveRightTestTrue()
         {
             ICoordinate coordinate = userCommand.MoveRight();
             Assert.IsTrue(coordinate.Row == 0, "Row is not 0");
             Assert.IsTrue(coordinate.Col == 1, "Col is not 1");
         }

         [TestMethod]
         public void MoveRightTestFalse()
         {
             ICoordinate coordinate = userCommand.MoveRight();
             Assert.IsFalse(coordinate.Row != 0, "Row is not 0");
             Assert.IsFalse(coordinate.Col != 1, "Col is not 1");
         }

         [TestMethod]
         public void MoveUpTestTrue()
         {
             ICoordinate coordinate = userCommand.MoveUp();
             Assert.IsTrue(coordinate.Row == -1, "Row is not -1");
             Assert.IsTrue(coordinate.Col == 0, "Col is not 0");
         }
         [TestMethod]
         public void MoveUpTestFalse()
         {
             ICoordinate coordinate = userCommand.MoveUp();
             Assert.IsFalse(coordinate.Row != -1, "Row is not -1");
             Assert.IsFalse(coordinate.Col != 0, "Col is not 0");
         }
         [TestMethod]
         public void MoveDownTestTrue()
         {
             ICoordinate coordinate = userCommand.MoveDown();
             Assert.IsTrue(coordinate.Row == 1, "Row is not 1");
             Assert.IsTrue(coordinate.Col == 0, "Col is not 0");
         }
         [TestMethod]
         public void MoveDownTestFalse()
         {
             ICoordinate coordinate = userCommand.MoveDown();
             Assert.IsFalse(coordinate.Row != 1, "Row is not 1");
             Assert.IsFalse(coordinate.Col != 0, "Col is not 0");
         }

    }
}
