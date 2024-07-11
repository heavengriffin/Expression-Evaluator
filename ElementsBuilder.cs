using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression_Evaluator
{
    internal class ElementsBuilder
    {
        public static List<object> getElements(char[] expressionArray)
        {
            char[] operators = (char[])ElementFinder.findOperators(expressionArray, "operators");
            int[] operatorPositions = (int[])ElementFinder.findOperators(expressionArray, "positions");

            string[] variablesArray = (string[])ElementFinder.findVariables(expressionArray, "variables");
            int[] variablePositions = (int[])ElementFinder.findVariables(expressionArray, "positions");

            double[] constants = (double[])ElementFinder.findConstants(expressionArray, "constants");
            int[] constantPositions = (int[])ElementFinder.findConstants(expressionArray, "positions");

            char[] openedBrackets = (char[])ElementFinder.findBrackets(expressionArray, "opened brackets");
            char[] closedBrackets = (char[])ElementFinder.findBrackets(expressionArray, "closed brackets");
            int[] openedBracketsPositions = (int[])ElementFinder.findBrackets(expressionArray, "opened brackets positions");
            int[] closedBracketsPositions = (int[])ElementFinder.findBrackets(expressionArray, "closed brackets positions");

            List<object> elements = new List<object>();

            int variablesCounter = 0;
            int constantsCounter = 0;
            int openedBracketCount = 0;
            int closedBracketCount = 0;
            int operatorsCounter = 0;

            for (int i = 0; i < expressionArray.Length; i++)
            {
                if (variablesArray.Length > 0 && variablePositions[variablesCounter] == i)
                {
                    if (variablesCounter < variablesArray.Length)
                    {
                        elements.Add(variablesArray[variablesCounter]);
                        variablesCounter++;
                        if (variablesCounter == variablesArray.Length)
                            variablesCounter = variablesArray.Length - 1;
                    }
                }
                if (operatorPositions[operatorsCounter] == i)
                {
                    if (operatorsCounter < operators.Length)
                    {
                        elements.Add(operators[operatorsCounter]);
                        operatorsCounter++;
                        if (operatorsCounter == operators.Length)
                            operatorsCounter = operators.Length - 1;
                    }
                }
                if (constants.Length > 0 && constantPositions[constantsCounter] == i)
                {
                    if (constantsCounter < constants.Length)
                    {
                        elements.Add(constants[constantsCounter]);
                        constantsCounter++;
                        if (constantsCounter == constants.Length)
                            constantsCounter = constants.Length - 1;
                    }
                }
                if (openedBrackets.Length > 0 && openedBracketsPositions[openedBracketCount] == i)
                {
                    if (openedBracketCount < openedBrackets.Length)
                    {
                        elements.Add(openedBrackets[openedBracketCount]);
                        openedBracketCount++;
                        if (openedBracketCount == openedBrackets.Length)
                            openedBracketCount = openedBrackets.Length - 1;
                    }
                }
                if (closedBrackets.Length > 0 && closedBracketsPositions[closedBracketCount] == i)
                {
                    if (closedBracketCount < closedBrackets.Length)
                    {
                        elements.Add(closedBrackets[closedBracketCount]);
                        closedBracketCount++;
                        if (closedBracketCount == closedBrackets.Length)
                            closedBracketCount = closedBrackets.Length - 1;
                    }
                }
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == null)
                    elements.RemoveAt(i);
            }

            return elements;
        }

        public static void SolveMinuses(ref List<object> elements, ref double x, ref double y)
        {
            for (int i = 1; i < elements.Count; i++)
            {
                if (elements[i - 1].ToString() == "(" && elements[i].ToString() == "-" && elements[i + 1].GetType() == typeof(double) && elements[i + 2].ToString() == ")")
                {
                    double temp = (double)elements[i + 1];
                    temp *= -1;
                    elements[i + 1] = temp;

                    elements.RemoveAt(i + 2);
                    elements.RemoveAt(i);
                    elements.RemoveAt(i - 1);
                }
            }

            for (int i = 1; i < elements.Count; i++)
            {
                if (elements[i - 1].ToString() == "(" && elements[i].ToString() == "-" && elements[i + 1].ToString() == "x" && elements[i + 2].ToString() == ")")
                {
                    x *= -1;

                    elements.RemoveAt(i + 2);
                    elements.RemoveAt(i);
                    elements.RemoveAt(i - 1);
                }
            }

            for (int i = 1; i < elements.Count; i++)
            {
                if (elements[i - 1].ToString() == "(" && elements[i].ToString() == "-" && elements[i + 1].ToString() == "y" && elements[i + 2].ToString() == ")")
                {
                    y *= -1;

                    elements.RemoveAt(i + 2);
                    elements.RemoveAt(i);
                    elements.RemoveAt(i - 1);
                }
            }
        }
    }
}
