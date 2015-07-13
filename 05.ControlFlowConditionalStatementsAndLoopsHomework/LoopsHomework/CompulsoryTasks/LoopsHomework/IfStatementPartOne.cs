namespace LoopsHomework
{
    using System;

    public class IfStatementPartOne
    {
        public static void IfStatementOne()
        {
            Potato potato = null;
            ////... 

            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }
    }
}
