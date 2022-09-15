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
        private readonly Resources Resources; // Dependency

        public Calc(Resources resources)
        {
            Resources = resources;
        }

        public void Run()
        {
            RomanNumber? numA, numB, res;
            char symbol;
            while (true)
            {
                try
                {
                    Console.Write(Resources.GetEnterNumberMessage());
                    numA = new RomanNumber(RomanNumber.Parse(Console.ReadLine()!));
                    Console.Write(Resources.GetEnterOperationMessage());
                    symbol = char.Parse(Console.ReadLine()!);
                    Console.Write(Resources.GetEnterNumberMessage());
                    numB = new RomanNumber(RomanNumber.Parse(Console.ReadLine()!));

                    switch (symbol)
                    {
                        case '+':
                            res = RomanNumber.Add(numA, numB); 
                            break;
                        default: throw new Exception();
                    }

                    Console.WriteLine(Resources.GetResultMessage(numA, symbol, numB, res));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
