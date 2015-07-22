namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (!(sideA > 0 && sideB > 0 && sideC > 0))
            {
                throw new ArgumentException("Sides of the triangle must be positive numbers");
            }

            if (!(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA))
            {
                throw new ArgumentException("The sum of every two sides of a triangle must be greater than the third side");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return area;
        }

        public static string DigitToString(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid digit");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Array must not be null");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Array must have at least 1 element");
            }

            var maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintNumberInSpecifiedFormat(double number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;

                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;

                case "r":
                    Console.WriteLine("{0:r}", number);
                    break;

                default: 
                    throw new ArgumentException("Method does not support this format: " + format);
            }
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static bool CheckIfHorizontal(double x1, double y1, double x2, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        public static bool CheckIfVertical(double x1, double y1, double x2, double y2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberInSpecifiedFormat(1.3, "f");
            PrintNumberInSpecifiedFormat(0.75, "%");
            PrintNumberInSpecifiedFormat(2.30, "r");

            bool horizontal = CheckIfHorizontal(3, -1, 3, 2.5),
                 vertical = CheckIfVertical(3, -1, 3, 2.5);

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.AdditionalInformation = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.AdditionalInformation = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
