namespace LoopsHomework
{
    using System;

    public class IfStatementPartTwo
    {
        public void IfStetementTwo()
        {
            long x = 0;
            const long MAX_X = 0;
            const long MIN_X = 0;

            long y = 0;
            const long MAX_Y = 0;
            const long MIN_Y = 0;

            bool shouldNotVisitCell = false;

            if (x >= MIN_X && (x <= MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
            {
               VisitCell();
            }
        }

        private static void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}
