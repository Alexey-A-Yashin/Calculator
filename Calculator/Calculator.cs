using System;

namespace CalculatorApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMessege("Вычисление выражений в формате прямой польской записи." + Environment.NewLine +
                        "Вводимые операнды и операторы должны разделяться пробелом." + Environment.NewLine +
                        "Доступные арифметические операторы: '+', '-', '*', '/'." + Environment.NewLine +
                        "Клавиша Esc - выход", ConsoleColor.Yellow);

            while (true)
            {
                var enteredValue = GetEnteredConsoleValue();

                if (enteredValue.lastInputKey == ConsoleKey.Escape)
                    Environment.Exit(0);
                else
                {
                    try
                    {
                        int result = CalculatorLibrary.Calculator.CalculateExpession(enteredValue.inputString);
                        ShowMessege("Результат: " + Convert.ToString(result), ConsoleColor.Green);
                    }
                    catch (Exception ex)
                    {
                        ShowMessege("В ведённом выражении обнаружена ошибка: " + ex.Message, ConsoleColor.Red);                        
                    }
                }
            }                
        }

        static (string inputString, ConsoleKey lastInputKey) GetEnteredConsoleValue()
        {
            ShowMessege("Введите выражение:", ConsoleColor.Yellow);

            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo();
            string inputString = String.Empty;

            while (true)
            {
                consoleKeyInfo = Console.ReadKey();

                if (consoleKeyInfo.Key == ConsoleKey.Enter || consoleKeyInfo.Key == ConsoleKey.Escape)
                    break;

                inputString += consoleKeyInfo.KeyChar;
            }
            ShowMessege(inputString, ConsoleColor.White);
            return (inputString: inputString.Trim(), lastInputKey: consoleKeyInfo.Key);
        }

        static void ShowMessege(string message, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;            
        }
    }
}
