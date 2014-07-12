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

        private ICoordinate initialPlayerCoordinates = new Coordinate(6, 6);
        public void Create(ILabyrinth labyrinth)
        {
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
            labyrinth.FillMatrix();

            Console.WriteLine();
            bool isWayOut = this.IsPossibleWayOut(labyrinth, initialPlayerCoordinates);

            while (!isWayOut)
            {
                labyrinth.FillMatrix();
                isWayOut = this.IsPossibleWayOut(labyrinth, initialPlayerCoordinates);
            }

            LabyrinthEngine.Instance.Player.ShowPlayer(labyrinth);
            this.Render(labyrinth);
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

        /// <summary>C:\MyStaff\GitHub\Team-Labyrint-4\HighQualityCodeTeamwork\LabyrinthGame\IUserCommand.cs
        /// The method deep clones the labyrinth matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        private static ILabyrinth DeepClone(ILabyrinth labyrinth)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, labyrinth);
                ms.Position = 0;

                return (ILabyrinth)formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// The method checks if there is sequence of "path" signs to the edges of the matrix
        /// </summary>
        /// <param name="labyrinth">Labyrinth object</param>
        /// <param name="givenCoords">The start point for checking</param>
        /// <returns>Returns boolean type - if there is such "path" it is true, and if there is not - it is false</returns>
        private bool IsPossibleWayOut(ILabyrinth labyrinth, ICoordinate givenCoords)
        {
            ILabyrinth labyrinthDeepCloned = DeepClone(labyrinth);
            if (givenCoords.Row >= labyrinthDeepCloned.Matrix.GetLength(0) || givenCoords.Row < 0 ||
                givenCoords.Col >= labyrinthDeepCloned.Matrix.GetLength(1) || givenCoords.Col < 0)
            {
                // We are out
                return false;
            }

            if (givenCoords.Row == labyrinthDeepCloned.Matrix.GetLength(0) - 1 ||
                givenCoords.Col == labyrinthDeepCloned.Matrix.GetLength(1) - 1)
            {
                // Corner
                return true;
            }

            if (labyrinthDeepCloned.Matrix[givenCoords.Row, givenCoords.Col] == (char)Symbol.Obstacle)
            {
                return false;
            }

            // Mark visited
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
    }
}