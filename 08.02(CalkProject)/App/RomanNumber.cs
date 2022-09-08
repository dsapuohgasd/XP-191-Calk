using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _08._02_CalkProject_.App
{
    //робота з римськими числами
    public record RomanNumber
    {
        private int num;
        public int Value
        {
            set
            {
               num = value;
            }
            get
            {
                return num;
            }
        }
        public RomanNumber()
        {
            num = 0;
        }
        public RomanNumber(int n)
        {
            num = n;
        }

        public override string ToString()
        {
            if (this.num == 0)
            {
                return "N";
            }
            int n = this.num;
            String res = "";
            String[] parts = { "M", "CM", "D", "CD", "C", "XC", "L","XL", "X","IX","V","IV","I"};
            int[] values = { 1000,900,500,400,100, 90,50,40,10,9,5,4,1};
            for (int j = 0; j <= parts.Length - 1; j++)
            {
                while (n >= values[j])
                {
                    n -= values[j];
                    res += parts[j];
                }
            }
            return res;
        }

        // одержання числа з рядкового запису
        public static int Parse(String str)
        {
            if (str == null)
            {
                throw new ArgumentException("Null is not allowed");
            }
            if (str.Length==0)
            {
                throw new ArgumentException("Empty string not allowed");
            }
            char[] digits = {'N', 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = {0, 1, 5, 10, 50, 100, 500, 1000 };
            //якщо наступна цифра числа більша за поточну, то вона віднімається від результату, інакше додається
            //IX: -1+10; XC: -10+100; XX: +10+10; CX: +100+10;
            // XIV: +10-1+5
            int pos = str.Length - 1;  // позиція останньої цифри числа
            char digit = str[pos];     // символ цифри
            int ind = Array.IndexOf(digits, digit);  // позиція цифри у масиві
            int val = 0;  // величина цифри
            int res = 0;



            // продовжуємо доки pos не дійде до 0
            while (pos != -1)
            {
                digit = str[pos]; // символ цифри  
                ind = Array.IndexOf(digits, digit); // позиція цифри у масиві
                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }
                // Визначаємо величину цифри
                val = digitValues[ind]; // величина цифри 
                // порівнюємо з наступною (останньою) цифрою (одержана вище)
                if (pos + 1 < str.Length - 1 && digit == str[pos + 1])
                {
                    res += val;
                }
                else if (res > val)
                {  // додаємо або віднімаємо в залежності від рез. порівняння
                    res -= val;
                }
                else
                {
                    res += val;
                }
                pos -= 1; //передостання цифра
            }

            return res;
            // res - это результат
        }
    }
}
