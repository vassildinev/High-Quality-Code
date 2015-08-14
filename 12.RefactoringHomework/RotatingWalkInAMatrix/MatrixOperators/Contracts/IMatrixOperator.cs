
namespace WalkInAMatrix.MatrixOperators.Contracts
{
    public interface IMatrixOperator
    {
        void Fill(int[,] matrix);

        int[,] GetNewEmptySquareMatrix(int lengthOfMatrix);
    }
}
