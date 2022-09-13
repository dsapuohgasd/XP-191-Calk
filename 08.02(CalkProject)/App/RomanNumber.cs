using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

        //переопределение стандартного tostring
        public override string ToString()
        {
            if (this.num == 0)
            {
                return "N";
            }
            int n = this.Value<0?-this.Value:this.Value;
            String res = this.Value<0 ? "-" : "";
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
            if (str == null)    //null строка
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (str == "N")     //если 0 то вернем 0
            {
                return 0;
            }
            bool isNegative = false;
            if (str.StartsWith('-'))    //начало с -
            {
                isNegative = true;
                str = str[1..];
            }
            if (str.Length<1)//пустая строка
            {
                throw new ArgumentException("Empty string not allowed");
            }

            char[] digits = {'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
            //якщо наступна цифра числа більша за поточну, то вона віднімається від результату, інакше додається
            //IX: -1+10; XC: -10+100; XX: +10+10; CX: +100+10;
            // XIV: +10-1+5
            int pos = str.Length - 1;   // позиція останньої цифри числа
            char digit = str[pos];     // символ цифри
            int ind = Array.IndexOf(digits, digit);     // позиція цифри у масиві
            int val;    // величина цифри
            int res = 0;


            // продовжуємо доки pos не дійде до 0
            while (pos != -1)
            {
                digit = str[pos];   // символ цифри  
                ind = Array.IndexOf(digits, digit);     // позиція цифри у масиві
                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }
                // Визначаємо величину цифри
                val = digitValues[ind];     // величина цифри 
                // порівнюємо з наступною (останньою) цифрою (одержана вище)
                if (pos + 1 < str.Length - 1 && digit == str[pos + 1])
                {
                    res += val;
                }
                else if (res > val)     // додаємо або віднімаємо в залежності від рез. порівняння
                {  
                    res -= val;
                }
                else
                {
                    res += val;
                }
                pos -= 1; //передостання цифра
            }

            return isNegative ? -res : res;
            // res - это результат
        }

        //сложение 

        // Рефакторинг - алгоритм повторяется в каждом методе

        #region
        //public RomanNumber Add(RomanNumber rn)
        //{
        //    if(rn is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn));
        //    }
        //    return new(this.Value+rn.Value);
        //    //return this with { Value = this.Value+rn.Value};
        //}
        ////cложение + строка
        //public RomanNumber Add(String val)
        //{
        //    if (val is null)
        //    {
        //        throw new ArgumentNullException(nameof(val));
        //    }
        //    return new(this.Value + Parse(val));
        //}

        ////сложение статик
        //public static RomanNumber Add(RomanNumber rn1, RomanNumber rn2)
        //{
        //    if(rn1 is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn1));
        //    }
        //    if(rn2 is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn2));
        //    }
        //    return new(rn1.Value+rn2.Value);
        //}

        ////сложение + число
        //public RomanNumber Add(int val)
        //{
        //    return this with { Value=this.Value+val};
        //}

        ////сложение + число статик
        //public static RomanNumber Add(int val, RomanNumber rn)
        //{
        //    if (rn is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn));
        //    }
        //    return new (val + rn.Value);
        //}
        ////сложение + число статик
        //public static RomanNumber Add(RomanNumber rn, int val)
        //{
        //    if (rn is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn));
        //    }
        //    return new (rn.Value+val);
        //}
        ////сложение + число статик
        //public static RomanNumber Add(int val, int val1)
        //{
        //    return new (val + val1);
        //}
        //public static RomanNumber Add(String rn, int val)
        //{
        //    if (rn is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn));
        //    }
        //    return new (Parse(rn)+val);
        //}
        //public static RomanNumber Add(int val,String rn)
        //{
        //    if (rn is null)
        //    {
        //        throw new ArgumentNullException(nameof(rn));
        //    }
        //    return new (Parse(rn)+val);
        //}
        //public static RomanNumber Add(String val, String val1)
        //{
        //    if (val is null)
        //    {
        //        throw new ArgumentNullException(nameof(val));
        //    }
        //    if (val1 is null)
        //    {
        //        throw new ArgumentNullException(nameof(val1));
        //    }
        //    return new(Parse(val) + Parse(val1));
        //}
        //public static RomanNumber Add(RomanNumber val, String val1)
        //{
        //    if (val is null)
        //    {
        //        throw new ArgumentNullException(nameof(val));
        //    }
        //    if (val1 is null)
        //    {
        //        throw new ArgumentNullException(nameof(val));
        //    }
        //    return new(val.Value+Parse(val1));
        //}
        #endregion

        // Рефакторинг -->

        public RomanNumber Add(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException(nameof(rn));
            }
            return new(this.Value + rn.Value);
            //return this with { Value = this.Value+rn.Value};
        }

        //Вместо дублирования алгоритма сложения мы создаем объект из серых данных и делегируем сложение другому методу
        public RomanNumber Add(int val)
        {
            return this.Add(new RomanNumber(val));
        }

        //Вместо дублирования алгоритма сложения мы создаем объект из серых данных и делегируем сложение другому методу
        public RomanNumber Add(String val)
        {
            if (val is null)
            {
                throw new ArgumentNullException(nameof(val));
            }
            return this.Add(new RomanNumber(Parse(val)));
        }

        //Статические методы сложения
        #region
        //static Add -->

        //int + int
        //public static RomanNumber Add(int val1, int val2)
        //{
        //    return new RomanNumber(val1).Add(val2);
        //}

        ////string + int || int + string
        //public static RomanNumber Add(int val1, String val2)
        //{
        //    return new RomanNumber(val1).Add(val2);
        //}
        //public static RomanNumber Add(String val1,int val2)
        //{
        //    return new RomanNumber(RomanNumber.Parse(val1)).Add(val2);
        //}

        ////string + string
        //public static RomanNumber Add(String val1,String val2)
        //{
        //    return new RomanNumber(RomanNumber.Parse(val1)).Add(val2);
        //}

        ////object + int || int + object
        //public static RomanNumber Add(RomanNumber val1,int val2)
        //{
        //    return val1.Add(val2);
        //}
        //public static RomanNumber Add(int val1,RomanNumber val2)
        //{
        //    return val2.Add(val1);
        //}

        ////object + object
        //public static RomanNumber Add(RomanNumber val1,RomanNumber val2)
        //{
        //    return val1.Add(val2);
        //}

        ///// <summary>
        ///// Calculate sum of RomanNumber val1 and String val2
        ///// </summary>
        ///// <param name="val1"></param>
        ///// <param name="val2"></param>
        ///// <returns>RomanNumber</returns>
        ////object + string
        //public static RomanNumber Add(RomanNumber val1,String val2)
        //{
        //    return val1.Add(val2);
        //}

        //<-- static add
        #endregion

        //superduper add
        public static RomanNumber Add(object obj1,object obj2)
        {
            var rns = new RomanNumber[] {null!, null!};
            var pars = new object[] { obj1, obj2 };
            var res = new RomanNumber(0);
            for (int i = 0; i < 2; i++) 
            {
                if (pars[i] is null) throw new ArgumentNullException($"obj{i+1}");

                if (pars[i] is int val) rns[i] = new RomanNumber(val);
                else if (pars[i] is String str) rns[i] = new RomanNumber(Parse(str));
                else if (pars[i] is RomanNumber rn) rns[i] = rn;
                else throw new ArgumentException($"obj{i+1}: rype unsupported");
                res = res.Add(rns[i]);
            }
            return res;
        }
    }
}
