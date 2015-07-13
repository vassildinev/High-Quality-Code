namespace BooleanOperator
{
    using System;

    public class BoolToStringConverter
    {
        public void Convert(bool boolVariableToConvert)
        {
            string boolAsString = boolVariableToConvert.ToString();
            Console.WriteLine(boolAsString);
        }
    }
}
