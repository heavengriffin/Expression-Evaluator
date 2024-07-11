using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression_Evaluator
{
    internal class Validator
    {
        public static bool Validate(char[] expressionArray)
        {
            bool operatorPresent = false;
            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '+' || expressionArray[i] == '-' || expressionArray[i] == '*' || expressionArray[i] == '/')
                {
                    operatorPresent = true; break;
                }
            }

            if (!operatorPresent)
            {
                Console.WriteLine("There are no operators present. Please try again.");
                return false;
            }

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == ',')
                    expressionArray[i] = '.';
            }

            if (expressionArray[0] == '+' || expressionArray[0] == '*' || expressionArray[0] == '/')
            {
                Console.WriteLine("You cannot start the expression with an operator which is not a minus.");
                return false;
            }

            if (expressionArray[expressionArray.Length - 1] == '+' || expressionArray[expressionArray.Length - 1] == '-' || expressionArray[expressionArray.Length - 1] == '*' || expressionArray[expressionArray.Length - 1] == '/')
            {
                Console.WriteLine("The mathematical expression cannot end in an operator. Please try again.");
                return false;
            }

            if (expressionArray[0] == ')' || expressionArray[expressionArray.Length - 1] == '(')
            {
                Console.WriteLine("A mathematical expression cannot start with a closing bracket, and it cannot end with an opening bracket. Please try again.");
                return false;
            }

            int opened = 0;
            int closed = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '(')
                    opened++;
                else if (expressionArray[i] == ')')
                    closed++;
            }

            if (opened != closed)
            {
                Console.WriteLine("The expression is not well bracketed. Please try again.");
                return false;
            }

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (i < expressionArray.Length - 1 && (expressionArray[i] == '+' || expressionArray[i] == '-' || expressionArray[i] == '*' || expressionArray[i] == '/')
                    &&
                    (expressionArray[i + 1] == '+' || expressionArray[i + 1] == '-' || expressionArray[i + 1] == '*' || expressionArray[i + 1] == '/')
                    )
                {
                    Console.WriteLine("You have entered two or more operators side by side. Please try again.");
                    return false;
                }

                if (i > 0 && expressionArray[i] == ')' && (expressionArray[i - 1] == '+' || expressionArray[i - 1] == '-' || expressionArray[i - 1] == '*' || expressionArray[i - 1] == '/'))
                {
                    Console.WriteLine("An operator cannot be immediately followed by a closing bracket. Please try again.");
                    return false;
                }

                if (i < expressionArray.Length - 1 && expressionArray[i] == ')' && expressionArray[i + 1] == '(')
                {
                    Console.WriteLine("A closing bracket cannot be immediately followed by an opening bracket. You are missing an operator. Please try again.");
                    return false;
                }

                if (i < expressionArray.Length - 1 && expressionArray[i] == '(' && (expressionArray[i + 1] == '+' || expressionArray[i + 1] == '*' || expressionArray[i + 1] == '/'))
                {
                    Console.WriteLine("An opening bracket cannot be immediately followed by an operator other than minus. Please try again.");
                    return false;
                }

                if (i < expressionArray.Length - 1 && expressionArray[i] == '(' && expressionArray[i + 1] == ')')
                {
                    Console.WriteLine("Yoy have a pair of empty brackets. Please try again.");
                    return false;
                }

                if (expressionArray[i] == 'X')
                {
                    expressionArray[i] = 'x';
                }

                if (expressionArray[i] == 'Y')
                {
                    expressionArray[i] = 'y';
                }

                if (!(expressionArray[i] == '+' || expressionArray[i] == '-' || expressionArray[i] == '*' || expressionArray[i] == '/' || expressionArray[i] == 'x' || expressionArray[i] == 'y' || (expressionArray[i] >= 48 && expressionArray[i] <= 57) || expressionArray[i] == '.' || expressionArray[i] == ' ' || expressionArray[i] == '(' || expressionArray[i] == ')'))

                {
                    Console.WriteLine("You have entered an unsupported character. Please try again.");
                    return false;
                }

                if (i < expressionArray.Length - 1 && (expressionArray[i] == 'x' || expressionArray[i] == 'y') && (expressionArray[i + 1] == 'x' || expressionArray[i + 1] == 'y'))
                {
                    Console.WriteLine("You cannot put two or more variables side by side. Maybe you are missing an operator. Please try again.");
                    return false;
                }

                if (i < expressionArray.Length - 1 && (expressionArray[i] == 'x' || expressionArray[i] == 'y') && ((expressionArray[i + 1] >= 48 && expressionArray[i + 1] <= 57) || expressionArray[i + 1] == '.'))
                {
                    Console.WriteLine("A variable cannot be immediately followed by a number or a dot. Maybe you are missing an operator. Please try again.");
                    return false;
                }

                if (i > 0 && (expressionArray[i] == 'x' || expressionArray[i] == 'y') && ((expressionArray[i - 1] >= 48 && expressionArray[i - 1] <= 57) || expressionArray[i - 1] == '.'))
                {
                    Console.WriteLine("A number or a dot cannot be immediately followed by a variable. Maybe you are missing an operator. Please try again.");
                    return false;
                }

                if (i < expressionArray.Length - 1 && expressionArray[i] == '.' && expressionArray[i + 1] == '.')
                {
                    Console.WriteLine("You have entered two or more decimal seperators one after another. Please try again.");
                    return false;
                }

                if (expressionArray[i] == '.' && !(i > 0 && expressionArray[i - 1] >= 48 && expressionArray[i - 1] <= 57 && i < expressionArray.Length - 1 && expressionArray[i + 1] >= 48 && expressionArray[i + 1] <= 57))
                {
                    Console.WriteLine("You have not well entered the decimal number. Please try again.");
                    return false;
                }
            }
            return true;
        }
    }
}
