using System;

namespace lab5
{
    class Program
    {

        public static double ConvertTriangleSide(String sideValue)
        {
            double result = Convert.ToDouble(sideValue);
            if (result <= 0) throw new NegativeSideException("Side cannot be negative"); 
            return result;
        }

        public static void validateTriangleLengths(double a, double b, double c)
        {
            if (a > (b + c) || b > (a + c) || c > (a + b))
                throw new SidesLengthException("One side length cannot be grater than sum of others");
        }

        static void Main(string[] args)
        {
            string sideA, sideB, sideC;

            try
            {
                Console.Write("Input side A= ");
                sideA = Console.ReadLine();
                double a = ConvertTriangleSide(sideA);
                Console.Write("Input side B= ");
                sideB = Console.ReadLine();
                double b = ConvertTriangleSide(sideB);
                Console.Write("Input side C= ");
                sideC = Console.ReadLine();
                double c = ConvertTriangleSide(sideC);
                validateTriangleLengths(a, b, c);

                double p = (a + b + c) / 2.0;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("S=" + s);

            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Wrong format of input. Example (212.34)");
            }
            catch (SidesLengthException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NegativeSideException exc)
            {
                Console.WriteLine("Side length cannot be negative or zero");
            }

            Console.ReadLine();
        }
    }
}
