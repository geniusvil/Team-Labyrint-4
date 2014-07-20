namespace LabyrinthGame.Interfaces
{
    /// <summary>
    /// Interface which is inherited by the Labyrinth class
    /// </summary>
    public interface ILabyrinth
    {
        char[,] Matrix { get; }

        void FillMatrix(IRandomCharProvider randomCharProvider);

        void ChangeSymbol(ICoordinate coordinates, char newSymbol);
    }
}