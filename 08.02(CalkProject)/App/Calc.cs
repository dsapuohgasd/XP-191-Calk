using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08._02_CalkProject_.App
{
    // Головний клас - запуск програми
    public class Calc
    {
        private readonly Resources Resources; // Пакет ресурсов

        public Calc(Resources resources)
        {
            Resources = resources;
        }
        public RomanNumber EvalExpression(String expression)
        {
            var Operations = new String[] { "+", "-" };          // Массив операций

            String[] parts = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3) throw new ArgumentException(Resources.GetInvalidLength());                             // Проверка на длину вводимой строки
            if (Array.IndexOf(Operations, parts[1]) == -1) throw new ArgumentException(Resources.GetInvalidOperation());  // Проверка на ввод доступной операции

            RomanNumber rn1 = new(RomanNumber.Parse(parts[0]));  // Получение первого элемента
            RomanNumber rn2 = new(RomanNumber.Parse(parts[2]));  // Получение второго элемента
            RomanNumber res =                                    // Вычисление результата
                parts[1] == Operations[0]
                ? rn1.Add(rn2)
                : rn1.Sub(rn2);
            return res;                                          // Возврат результата
        }

        public void Run()
        {
            int choise = -1;  
            String lang = null;
            do
            {
                Console.Write("Select language: \n1. Українська\n2. English\n> ");     // Выбор локализации
                try
                {
                    choise = int.Parse(Console.ReadLine()!);
                    if (choise == 1)
                    {
                        lang = "uk-UA";
                    }
                    if (choise == 2)
                    {
                        lang = "en-US";
                    }
                }
                catch
                {
                    throw new ArgumentException(Resources.GetInvalidSymbolMessage());  // Недопустимый символ

                }
            } while (lang==null);
            String? userInput;
            RomanNumber res = null!;
            do
            {
                Console.Clear();
                Console.Write(Resources.GetEnterNumberMessage(lang));  // Строка ввода выражения

                userInput = Console.ReadLine() ?? "";
                try
                {
                    res = EvalExpression(userInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (res is null);
            Console.WriteLine(Resources.GetResultMessage(userInput,res,lang));  // Вывод результата
        }
    }
}
