using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression_Evaluator
{
    internal class ElementFinder
    {
        public static object findOperators(char[] expressionArray, string array)
        {
            int operatorsCount = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '+' || expressionArray[i] == '-' || expressionArray[i] == '*' || expressionArray[i] == '/')
                {
                    operatorsCount++;
                }
            }

            char[] operators = new char[operatorsCount];

            int j = 0;

            int[] operatorPositins = new int[operatorsCount];

            int operatorsCounter = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '+')
                {
                    operators[j] = '+';
                    j++;
                    operatorPositins[operatorsCounter] = i;
                    operatorsCounter++;
                }
                else
            if (expressionArray[i] == '-')
                {
                    operators[j] = '-';
                    j++;
                    operatorPositins[operatorsCounter] = i;
                    operatorsCounter++;
                }
                else
            if (expressionArray[i] == '*')
                {
                    operators[j] = '*';
                    j++;
                    operatorPositins[operatorsCounter] = i;
                    operatorsCounter++;
                }
                else
            if (expressionArray[i] == '/')
                {
                    operators[j] = '/';
                    j++;
                    operatorPositins[operatorsCounter] = i;
                    operatorsCounter++;
                }
            }

            if (array == "operators")
                return operators;
            else if (array == "positions")
                return operatorPositins;
            else throw new ArgumentException();
        }

        public static object findVariables(char[] expressionArray, string array)
        {
            int variablesCount = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == 'x' || expressionArray[i] == 'y')
                {
                    variablesCount++;
                }
            }

            string[] variablesArray = new string[variablesCount];

            int va = 0;

            int variablesCounter = 0;

            int[] variablePositions = new int[variablesCount];

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == 'x')
                {
                    variablesArray[va] = "x";
                    va++;
                    variablePositions[variablesCounter] = i;
                    variablesCounter++;
                }
                else if (expressionArray[i] == 'y')
                {
                    variablesArray[va] = "y";
                    va++;
                    variablePositions[variablesCounter] = i;
                    variablesCounter++;
                }
            }

            if (array == "variables")
                return variablesArray;
            else if (array == "positions")
                return variablePositions;
            else throw new ArgumentException();
        }

        public static object findConstants(char[] expressionArray, string array)
        {
            int n = 0;

            int m = 0;

            int maxNumber = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] >= 48 && expressionArray[i] <= 57)
                {
                    m++;

                    for (int j = i; j < expressionArray.Length; j++)
                    {
                        if (expressionArray[j] >= 48 && expressionArray[j] <= 57 || expressionArray[j] == 46)
                        {
                            n++;
                            i++;
                        }
                        else if (expressionArray[j] < 48 || expressionArray[j] > 57 || expressionArray[j] == '\0')
                        {
                            goto jump;
                        }
                    }
                jump:
                    if (n > maxNumber)
                        maxNumber = n;
                    n = 0;
                }
            }

            int size = m;

            char[,] constants = new char[size, maxNumber];

            int[] constantPositions = new int[size];

            m = 0;
            n = 0;

            int constantsCounter = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] >= 48 && expressionArray[i] <= 57)
                {
                    constantPositions[constantsCounter] = i;
                    constantsCounter++;

                    for (int j = i; j < expressionArray.Length; j++)
                    {
                        if (expressionArray[j] >= 48 && expressionArray[j] <= 57 || expressionArray[j] == 46)
                        {
                            constants[m, n] = expressionArray[j];
                            n++;
                            i++;
                        }
                        else if (expressionArray[j] < 48 || expressionArray[j] > 57 || expressionArray[j] == '\0')
                        {
                            goto jump;
                        }
                    }
                jump:
                    n = 0;
                    m++;
                }
            }

            string[] constantsStrings = new string[size];

            for (int i = 0; i < size; i++)
            {
                constantsStrings[i] = "";
            }

            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < maxNumber; k++)
                {
                    constantsStrings[i] += constants[i, k].ToString();
                }
            }

            double[] constantsDoubles = new double[size];

            for (int i = 0; i < size; i++)
            {
                constantsDoubles[i] = double.Parse(constantsStrings[i], CultureInfo.InvariantCulture);
            }

            if (array == "constants")
                return constantsDoubles;
            else if (array == "positions")
                return constantPositions;
            else throw new ArgumentException();
        }

        public static object findBrackets(char[] expressionArray, string array)
        {
            int openedBracketCount = 0;
            int closedBracketCount = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '(')
                    openedBracketCount++;
                else if (expressionArray[i] == ')')
                    closedBracketCount++;
            }

            char[] openedBrackets = new char[openedBracketCount];

            char[] closedBrackets = new char[closedBracketCount];

            int[] openedBracketsPositions = new int[openedBracketCount];

            int[] closedBracketsPositions = new int[closedBracketCount];

            openedBracketCount = 0;
            closedBracketCount = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '(')
                {
                    openedBrackets[openedBracketCount] = '(';
                    openedBracketCount++;
                }
                else if (expressionArray[i] == ')')
                {
                    closedBrackets[closedBracketCount] = ')';
                    closedBracketCount++;
                }
            }

            openedBracketCount = 0;
            closedBracketCount = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (expressionArray[i] == '(')
                {
                    openedBracketsPositions[openedBracketCount] = i;
                    openedBracketCount++;
                }
                else if (expressionArray[i] == ')')
                {
                    closedBracketsPositions[closedBracketCount] = i;
                    closedBracketCount++;
                }
            }

            if (array == "opened brackets")
                return openedBrackets;
            else if (array == "closed brackets")
                return closedBrackets;
            else if (array == "opened brackets positions")
                return openedBracketsPositions;
            else if (array == "closed brackets positions")
                return closedBracketsPositions;
            else throw new ArgumentException();
        }
    }
}
