using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLibrary
{
    public static class Calculator
    {
        public static int CalculateExpession(string ExpressionString)
        {
            string expressionString = ExpressionString as string;

            if (expressionString == null || expressionString.Length == 0)
                throw new ArgumentException("Передана пустая строка");
                        
            return GetResult(expressionString);
        }

        private static int GetResult(string ExpressionString)
        {
            Stack<string> stackExpression = new Stack<string>(ExpressionString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Stack<int> stackDigits = new Stack<int>();
            string[] operators = GetOperators();
            string currentString;
            int tempValue, firstValue, secondValue;

            while (stackExpression.Count > 0)
            {
                try
                {
                    currentString = stackExpression.Pop();
                    tempValue = 0;

                    if (!operators.Contains(currentString))
                    {
                        tempValue = Convert.ToInt32(currentString);
                        stackDigits.Push(tempValue);
                        continue;
                    }

                    switch (currentString)
                    {
                        case "+":
                            {
                                firstValue = stackDigits.Pop();
                                secondValue = stackDigits.Pop();
                                tempValue = firstValue + secondValue;
                                break;
                            }
                        case "-":
                            {
                                firstValue = stackDigits.Pop();
                                secondValue = stackDigits.Pop();
                                tempValue = firstValue - secondValue;
                                break;
                            }
                        case "*":
                            {
                                firstValue = stackDigits.Pop();
                                secondValue = stackDigits.Pop();
                                tempValue = firstValue * secondValue;
                                break;
                            }
                        case "/":
                            {
                                firstValue = stackDigits.Pop();
                                secondValue = stackDigits.Pop();
                                tempValue = firstValue / secondValue;
                                break;
                            }                        
                    }
                }
                catch (FormatException)
                {
                    throw new FormatException("Неверный формат выражения");                    
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Использовано недопустимое значение операнда");                    
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidOperationException("Неверный формат выражения");                    
                }
                stackDigits.Push(tempValue);
            }
            return stackDigits.Pop();
        }

        private static string[] GetOperators()
            => new string[] { "+", "-", "*", "/" };
    }
}
