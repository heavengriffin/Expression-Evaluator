using LearningVirtualMethods;
using System.Collections;

namespace Expression_Evaluator
{
    internal class Calculator
    {
        public static void MultiplyAndDivide(ref List<object> elements, Hashtable variables, int start, ref Constant result)
        {
            Expression? here = null;
            Expression? there = null;
            Expression somewhere;
            Constant anywhere;           

            for (int i = start; i < elements.Count; i++)
            {                
                if (elements[i].ToString() == "*" || elements[i].ToString() == "/")
                {
                    if (elements[i - 1].GetType() == typeof(string))
                    {
                        here = new VariableReference((string)elements[i - 1]);
                    }
                    else if (elements[i - 1].GetType() == typeof(double))
                    {
                        here = new Constant((double)elements[i - 1]);
                    }

                    if (elements[i + 1].GetType() == typeof(string))
                    {
                        there = new VariableReference((string)elements[i + 1]);
                    }
                    else if (elements[i + 1].GetType() == typeof(double))
                    {
                        there = new Constant((double)elements[i + 1]);
                    }
                    if (here != null && there != null)
                    {
                        somewhere = new Operation(here, (char)elements[i], there);
                        anywhere = new Constant(somewhere.Evaluate(variables));
                        result = anywhere;
                        elements.RemoveAt(i - 1);                       
                        elements.RemoveAt(i - 1);                      
                        elements[i - 1] = result.value;
                        if (anywhere != null)
                            i--;
                    }
                }         
            }
        }

        public static void AddAndSubtract(ref List<object> elements, Hashtable variables, int start, ref Constant result)
        {
            Expression? here = null;
            Expression? there = null;
            Expression somewhere;
            Constant anywhere;

            for (int i = start; i < elements.Count; i++)
            {
                if (elements[i].ToString() == "+" || elements[i].ToString() == "-")
                {
                    if (elements[i - 1].GetType() == typeof(string))
                    {
                        here = new VariableReference((string)elements[i - 1]);
                    }
                    else if (elements[i - 1].GetType() == typeof(double))
                    {
                        here = new Constant((double)elements[i - 1]);
                    }

                    if (elements[i + 1].GetType() == typeof(string))
                    {
                        there = new VariableReference((string)elements[i + 1]);
                    }
                    else if (elements[i + 1].GetType() == typeof(double))
                    {
                        there = new Constant((double)elements[i + 1]);
                    }
                    if (here != null && there != null)
                    {
                        somewhere = new Operation(here, (char)elements[i], there);
                        anywhere = new Constant(somewhere.Evaluate(variables));
                        result = anywhere;
                        elements.RemoveAt(i - 1);
                        elements.RemoveAt(i - 1);                      
                        elements[i - 1] = result.value;
                        if (anywhere != null)
                            i--;
                    }
                }
            }
        }

        public static void MultiplyAndDivideInBrackets(ref List<object> elements, Hashtable variables, int start, ref Constant result, ref int r)
        {
            Expression? here = null;
            Expression? there = null;
            Expression somewhere;
            Constant anywhere;

            int i = start;
            while (elements[i].ToString() != ")")
            {
                if (elements[i].ToString() == "*" || elements[i].ToString() == "/")
                {
                    if (elements[i - 1].GetType() == typeof(string))
                    {
                        here = new VariableReference((string)elements[i - 1]);
                    }
                    else if (elements[i - 1].GetType() == typeof(double))
                    {
                        here = new Constant((double)elements[i - 1]);
                    }

                    if (elements[i + 1].GetType() == typeof(string))
                    {
                        there = new VariableReference((string)elements[i + 1]);
                    }
                    else if (elements[i + 1].GetType() == typeof(double))
                    {
                        there = new Constant((double)elements[i + 1]);
                    }
                    if (here != null && there != null)
                    {
                        somewhere = new Operation(here, (char)elements[i], there);
                        anywhere = new Constant(somewhere.Evaluate(variables));
                        result = anywhere;
                        elements.RemoveAt(i - 1);
                        r++;
                        elements.RemoveAt(i - 1);
                        r++;
                        elements[i - 1] = result.value;
                        if (anywhere != null)
                            i--;
                    }
                    if (elements[i].ToString() == "-" && elements[i - 1].ToString() == "(" && result != null)
                    {
                        result.value *= -1;
                        elements.RemoveAt(i);
                        elements[i] = result.value;
                        r++;
                    }
                }
                i++;
            }
        }

        public static void AddAndSubtractInBrackets(ref List<object> elements, Hashtable variables, int start, ref Constant result, ref int r)
        {
            Expression? here = null;
            Expression? there = null;
            Expression somewhere;
            Constant anywhere;

            int i = start;
            while (elements[i].ToString() != ")")
            {
                if (elements[i].ToString() == "+" || elements[i].ToString() == "-")
                {
                    if (elements[i - 1].GetType() == typeof(string))
                    {
                        here = new VariableReference((string)elements[i - 1]);
                    }
                    else if (elements[i - 1].GetType() == typeof(double))
                    {
                        here = new Constant((double)elements[i - 1]);
                    }

                    if (elements[i + 1].GetType() == typeof(string))
                    {
                        there = new VariableReference((string)elements[i + 1]);
                    }
                    else if (elements[i + 1].GetType() == typeof(double))
                    {
                        there = new Constant((double)elements[i + 1]);
                    }
                    if (here != null && there != null)
                    {
                        somewhere = new Operation(here, (char)elements[i], there);
                        anywhere = new Constant(somewhere.Evaluate(variables));
                        result = anywhere;
                        elements.RemoveAt(i - 1);
                        r++;
                        elements.RemoveAt(i - 1);
                        r++;
                        elements[i - 1] = result.value;
                        if (anywhere != null)
                            i--;
                    }
                    if (elements[i].ToString() == "-" && elements[i - 1].ToString() == "(" && result != null)
                    {
                        result.value *= -1;
                        elements.RemoveAt(i);
                        elements[i] = result.value;
                        r++;
                    }
                }
                i++;
            }
        }
    }
}
