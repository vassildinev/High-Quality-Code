namespace WalkInAMatrix.Common
{
    public static class Constants
    {
        public const int NumberOfAxes = 2;
        public const int NumberOfDirections = 8;
        public static int[][] Directions = new int[NumberOfDirections][]
        {
            new int[NumberOfAxes] {1, 1},
            new int[NumberOfAxes] {1 ,0},
            new int[NumberOfAxes] {1, -1},
            new int[NumberOfAxes] {0, -1},
            new int[NumberOfAxes] {-1, -1},
            new int[NumberOfAxes] {-1, 0},
            new int[NumberOfAxes] {-1, 1},
            new int[NumberOfAxes] {0, 1}
        };
    }
}
