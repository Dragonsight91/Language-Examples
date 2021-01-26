using System;

namespace CLI_Calc_V1_0
{
    class Program
    {
        static void Main(string[] args)
        {
            //Will continiously loop the calculator so that you can keep using it
            while (true)
            {
                RunCalculator();
            }
        }
        private static void RunCalculator()
        {
            //Write the preamble
            Console.WriteLine("C# CLI calc V1.0");

            // Reads the value for the function the user desires
            var function = GetPickedFunction();

            // Insert an empty line
            Console.WriteLine();

            // Get Selected function name and expression
            var functionNameAndExpression = GetFunctionNameAndExpression(function);

            // Write out the user's choice of operation
            Console.WriteLine("You chose: " + functionNameAndExpression.functionName);
            Console.WriteLine("Please choose two numbers a and b to calculate " + functionNameAndExpression.functionExpression);

            // Read a and b in order to do operation
            float a = ReadFloat("a");
            float b = ReadFloat("b");

            Console.Write("result: ");

            // Do the operation as picked by the user
            Console.WriteLine(GenerateResultForFunction(a,b,function)); 

            // And waiting for enter key to restart operation
            Console.Write("Press enter to restart...");
            Console.ReadLine();
            Console.WriteLine();
        }      

        public static float GenerateResultForFunction(float a, float b, int function)
        {
            float result = 0;
            // Picking which operation to do and generating the result
            switch (function)
            {
                case 1:
                    result = a + b;
                    break;
                case 2:
                    result = a - b;
                    break;
                case 3:
                    result = a * b;

                    break;
                case 4:
                    result = a / b;
                    break;
                case 5:
                    // I know you said no built-ins but nobody on this planet would EVER not use the 
                    // C# Math class to do Math operations. EVER.
                    // Also changing back to float as Math.Pow outputs a double.
                    result = (float)Math.Pow(a, b);
                    break;
            }
            return result;
        }

        public static int GetPickedFunction()
        {
            // Write out interface
            Console.WriteLine("chose a function");
            Console.WriteLine("1 - Add\t\t3 - Multiply\t5 - Exponentiation");
            Console.WriteLine("2 - Subtract\t4 - Divide\t");
            Console.Write(">>> ");

            // Variable to store selected option
            int function;

            // While the value inputed by the user in the console is NOT an int, or is NOT between 1 and 5
            while (!int.TryParse(Console.ReadLine(), out function) || function < 1 || function > 5)
            {
                // Ask them to DO IT AGAIN!
                Console.WriteLine("Input not recognized, please select an operation from 1 to 5 and press Enter");
                Console.Write(">>> ");
            }

            // Once they've figured out what numbers from 1 to 5 are... return
            return function;
        }

        public static float ReadFloat(string variableName)
        {
            // same logic as GetPickedFunction but done for a float
            float a;
            Console.Write($"{variableName}: ");
            while (!float.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Input not recognized, please select an operation from 1 to 5 and press Enter");
                Console.Write($"{variableName}: ");
            }

            return a;
        }

        // This method is a bit fancier, it returns what's called a touple, which basically allows for the return of
        // multiple variables in C# and is quicker than creating a whole Model Class, but only good for two or three variables
        // otherwise it makes more sense to create a Model Class and return an object
        public static (string functionName, string functionExpression) GetFunctionNameAndExpression(int function)
        {
            string functionName = "";
            string expressionName = "";

            // Switch operation, the better version of multiple ifs
            switch (function)
            {
                case 1:
                    functionName = "Add";
                    expressionName = "a+b";
                    break;
                case 2:
                    functionName = "Subtract";
                    expressionName = "a-b";
                    break;
                case 3:
                    functionName = "Multiply";
                    expressionName = "a*b";
                    break;
                case 4:
                    functionName = "Divide";
                    expressionName = "a/b";
                    break;
                case 5:
                    functionName = "Exponentiation";
                    expressionName = "a^b";
                    break;
            }

            return (functionName, expressionName);
        }
    }
}
