using System.Collections;
using System.ComponentModel;
using System.Globalization;
using LearningVirtualMethods;

namespace Expression_Evaluator
{
    internal class Program
    {
        static void Main(string[] args)
        {
        incorrect:
            try
            { // in case I missed some possible incorrect input

                Console.WriteLine("Enter a mathematical expression with x and y variables: ");

                string? expression = Console.ReadLine();

                char[] expressionArray;

                if (expression != null)
                    expressionArray = expression.ToCharArray();
                else goto incorrect;

                bool valid = Validator.Validate(expressionArray);

                if (!valid)
                {
                    goto incorrect;
                }

            repeat:
                List<object> elements = ElementsBuilder.getElements(expressionArray);

                string[] variablesArray = (string[])ElementFinder.findVariables(expressionArray, "variables");

                
                double x = 0;
                double y = 0;

                if (variablesArray.Length > 0)
                {
                    Console.WriteLine("Enter the values for the variables: ");

                    Console.Write("x = ");
                    string? xS = Console.ReadLine();

                    Console.Write("y = ");
                    string? yS = Console.ReadLine();

                    x = Convert.ToDouble(xS, CultureInfo.InvariantCulture);
                    y = Convert.ToDouble(yS, CultureInfo.InvariantCulture);
                }

                ElementsBuilder.SolveMinuses(ref elements, ref x, ref y);

                Hashtable variables = new Hashtable();

                variables["x"] = x;
                variables["y"] = y;

                Constant result = new Constant(0);

                int b;
                int c;
                int p;
                int r = 0;

            again:
                for (b = elements.Count - 1; b >= 0; b--)
                {
                    if (elements[b].ToString() == "(")
                    {
                        for (c = b; c < elements.Count; c++)
                        {
                            if (elements[c].ToString() == ")")
                            {
                                Calculator.MultiplyAndDivideInBrackets(ref elements, variables, b, ref result, ref r);
                                Calculator.AddAndSubtractInBrackets(ref elements, variables, b, ref result, ref r);
                                elements.RemoveAt(b);
                                p = c - r;
                                elements.RemoveAt(p - 1);
                                r = 0;
                                goto again;
                            }
                        }
                    }
                }

                if (elements[0].ToString() == "-")
                {
                    double temp = (double)elements[1];
                    temp *= -1;
                    elements[1] = temp;
                    elements.RemoveAt(0);
                }

                int start = 0;

                Calculator.MultiplyAndDivide(ref elements, variables, start, ref result);
                Calculator.AddAndSubtract(ref elements, variables, start, ref result);

                Console.WriteLine(result.value);

                Console.WriteLine();

                string? answer;
                if (variablesArray.Length > 0)
                    do
                {
                    Console.WriteLine("Would you like to enter different variables for the mathematical expression?(y/n)");
                    answer = Console.ReadLine();
                    if (answer != null)
                        answer = answer.ToLower();
                    if (answer == "y")
                        goto repeat;
                } while (answer != "n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Something went wrong. You entered an invalid mathematical expression. Please try again.");
                goto incorrect;
            }
        }
    }
}
