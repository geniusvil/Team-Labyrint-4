namespace LabyrinthGame
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Labyrinth creator class. Builder pattern used and this class acts as a Director
    /// </summary>
    public class LabyrinthCreator : ILabyrinthCreator
    {
        private const string Pentagram = "p";
        private const string Diamond = "d";
        private const string Hexagon = "h";

        private readonly ICoordinate initialPlayerCoordinates = new Coordinate(6, 6);

        /// <summary>
        /// Creates labyrinth of type asked by the user
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Type of labyrinth asked by user</param>
        /// <returns>Returns a labyrinth of type as given in param with name "userChoiceOfLabyrinth"</returns>
        public ILabyrinth Create(string userChoiceOfLabyrinth)
        {
            TypeLabyrinth typeOfLabyrinth = this.GetLabyrinthType(userChoiceOfLabyrinth);
            ILabyrinth labyrinth = this.CreateRequiredLabyrinth(typeOfLabyrinth);

            labyrinth.FillMatrix();

            Console.WriteLine();
            //  Console.WriteLine("lab\n" + labyrinth.ToString());
         //   ILabyrinth labyrinthDeepCloned = DeepClone(labyrinth);
            //  Console.WriteLine("dee\n" + labyrinthDeepCloned.ToString());

            //АКО ИЗПОЛЗВАМЕ ICLONABLE
         ILabyrinth labyrinthDeepCloned = labyrinth.Clone() as ILabyrinth;

            bool isWayOut = this.IsPossibleWayOut(labyrinthDeepCloned, this.initialPlayerCoordinates);

            while (!isWayOut)
            {
                labyrinth.FillMatrix();
                // Console.WriteLine("lab\n"+labyrinth.ToString());
              //  labyrinthDeepCloned = DeepClone(labyrinth);
                labyrinthDeepCloned = labyrinth.Clone() as ILabyrinth;
                /// Console.WriteLine("dee\n"+labyrinthDeepCloned.ToString());
                isWayOut = this.IsPossibleWayOut(labyrinthDeepCloned, this.initialPlayerCoordinates);
            }

            return labyrinth;
        }

        /// <summary>
        /// The method prints the labyrinth matrix to the console
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        public void Render(ILabyrinth labyrinth)
        {
            Console.WriteLine();
            (labyrinth as IRenderable).Render();
        }

        /// <summary>
        /// The method deep clones the labyrinth matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        /// 
        //ОТПАДА АКО ПОЛЗВАМЕ ICLONABLE
        //private static ILabyrinth DeepClone(ILabyrinth labyrinth)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, labyrinth);
        //        ms.Position = 0;

        //        return (ILabyrinth)formatter.Deserialize(ms);
        //    }
        //}

        /// <summary>
        /// The method checks if there is sequence of "path" signs to the edges of the matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        /// <param name="givenCoords">The start point for checking</param>
        /// <returns>Returns boolean type - if there is such "path" it is true, and if there is not - it is false</returns>
        private bool IsPossibleWayOut(ILabyrinth labyrinthDeepCloned, ICoordinate givenCoords)
        {
            if (givenCoords.Row >= labyrinthDeepCloned.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col >= labyrinthDeepCloned.Matrix.GetLength(1) || givenCoords.Col < 0)
            {
                // We are out
                return false;
            }

            if (givenCoords.Row == labyrinthDeepCloned.Matrix.GetLength(0) - 1 ||
                givenCoords.Col == labyrinthDeepCloned.Matrix.GetLength(1) - 1)
            {
                // reached Corner
                return true;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.Obstacle)// && (givenCoords.Row != 6 && givenCoords.Col!=6))
            {
                return false;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.BlankSpace)
            {
                return true;
            }

            // Marked as visited
            labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] = (char)Symbol.Obstacle;

            givenCoords.Update(new Coordinate(0, -1));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords); // left

            givenCoords.Update(new Coordinate(-1, 0));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords);  // up

            givenCoords.Update(new Coordinate(0, 1));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords);  // right

            givenCoords.Update(new Coordinate(1, 0));
            this.IsPossibleWayOut(labyrinthDeepCloned, givenCoords); // down

            return true;
        }

        /// <summary>
        /// The method converts sting type of labyrinth into enum type ot TypeLabyrinth
        /// </summary>
        /// <param name="userChoiceOfLabyrinth">Input choise of labyrinth type as string</param>
        /// <returns>Return enum TypeLabyrinth</returns>
        private TypeLabyrinth GetLabyrinthType(string userChoiceOfLabyrinth)
        {
            TypeLabyrinth userChoiseOfTypeLabytint = TypeLabyrinth.Square;

            if (userChoiceOfLabyrinth == Pentagram)
            {
                userChoiseOfTypeLabytint = TypeLabyrinth.Pentagram;
            }
            else if (userChoiceOfLabyrinth == Diamond)
            {
                userChoiseOfTypeLabytint = TypeLabyrinth.Diamond;
            }
            else if (userChoiceOfLabyrinth == Hexagon)
            {
                userChoiseOfTypeLabytint = TypeLabyrinth.Hexagon;
            }

            return userChoiseOfTypeLabytint;
        }

        /// <summary>
        /// Creates user required labyrinth
        /// </summary>
        /// <param name="typeLabyrinth">string representation of concrete labyrinth</param>
        /// <returns>Instance of the selected labyrinth</returns>
        private ILabyrinth CreateRequiredLabyrinth(TypeLabyrinth typeLabyrinth)
        {
            switch (typeLabyrinth)
            {
                case TypeLabyrinth.Diamond:
                    return new DiamondLabyrinth();
                case TypeLabyrinth.Pentagram:
                    return new PentagonLabyrinth();
                case TypeLabyrinth.Hexagon:
                    return new HexagonalLabyrinth();
                    //case TypeLabyrinth.Square:
                    //    return new SquareLabyrinth();
                default:
                    return new SquareLabyrinth();
            }
        }
    }
}

/* Идеята на този метод е да скрие това,че трябва изришно да се кастне към IRendarable. Понеже ние си 
* пишем кода и знаем,че това е възможно го скриваме тук. Така навсякъде където някой иска да създава лабиринт 
* ще изивиква този метод, който знае,че тр да се кастне и знае какви методи да извика на лабирнта. Така клиента (този,
* който ще ползва кода) не трябва да знае какви точни методи тр да вика на самите лабиринти и как да ги подреди, ами 
* просто ще работи с инстанция на Creator-a и с метода Create, който приема инстанция на Interface-a. Това е като примера
* с пиците - ти искаш да направят някаква пица и не се  интересуваш от логиката по направянето й. Тук е същото - клиента
* иска да направи лабиринт и казва на Creator-a да му направи такъв и не го интересува дали трябва да го кастне, да 
* запълни матрицата, в какъв ред и прочие. 
             
             
Тези инстанции на LabyrinthEngine е изключително грешно да бъдат тук, но чак сега ги видях. 
             
За да стане още по-ясно... онзи switch-case от engine-a, който връща еди какъв си лабиринт ще дойде тук и така ще стане 
супер. Този метод ще работи така: приема инстанция на ILabyrinth и някакъв символ, който мисля да дойда от енумерация, 
* съответно за D,P,H... и вече в този метод Create ще имаш If-ове,за това какъв лабиринт да се създаде. Така при добавяне
на нов тип лабиринт ще се добавят 2 реда код тук, където е логично,човек да потърси вместо в Engine-a. A в самия engine 
ще се вика метода Create(labyrinth, typeSymbol).*/