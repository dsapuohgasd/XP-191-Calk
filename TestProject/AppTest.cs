using _08._02_CalkProject_.App;

namespace TestProject
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void CalcTest()
        {
            // Ñïðîáà ñòâîðèòè îá`ºêò ãîëîâíîãî êëàñó
            _08._02_CalkProject_.App.Calc calc = new();
            // Ìàºìî îäåðæàòè íå-null ðåçóëüòàò
            Assert.IsNotNull(calc);
        }

        [TestMethod]//Парсим симыолы в числа
        public void RomanNumberParse1Digit()
        {

            Assert.AreEqual(1, RomanNumber.Parse("I"));
            Assert.AreEqual(5, RomanNumber.Parse("V"));
            Assert.AreEqual(10, RomanNumber.Parse("X"));
            Assert.AreEqual(50, RomanNumber.Parse("L"));
            Assert.AreEqual(100, RomanNumber.Parse("C"));
            Assert.AreEqual(500, RomanNumber.Parse("D"));
            Assert.AreEqual(1000, RomanNumber.Parse("M"));
        }
        public void RomanNumberParseN()//Tests and exceptions for "N"  letter
        {
            Assert.AreEqual(0, RomanNumber.Parse("N"));// Vadim added this test. Converting "N" to Zero

            //Exceptions. Only one "N" in string
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("XN")); 
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("MNX"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse("NL"));

        }

        [TestMethod]
        public void RomanNumberParse2Digit()
        {
            Assert.AreEqual(4, RomanNumber.Parse("IV"));
            Assert.AreEqual(15, RomanNumber.Parse("XV"));
            Assert.AreEqual(900, RomanNumber.Parse("CM"));
            Assert.AreEqual(400, RomanNumber.Parse("CD"));
            Assert.AreEqual(55, RomanNumber.Parse("LV"));
            Assert.AreEqual(40, RomanNumber.Parse("XL"));
        }
        [TestMethod]
        public void RomanNumberParse3MoreDigit()
        {
            Assert.AreEqual(30, RomanNumber.Parse("XXX"));
            Assert.AreEqual(401, RomanNumber.Parse("CDI"));
            Assert.AreEqual(1999, RomanNumber.Parse("MCMXCIX"));
        }

        [TestMethod]
        public void RomanNumberParseInvalidDigits()
        {
            //Assert.AreEqual(30, RomanNumber.Parse("XXA"));

            var exc = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXA"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp = new ArgumentException(Resources.GetInvalidCharMessage('A')); // очікуване виключення з попереднього тесту
            Assert.AreEqual(exp.Message, exc.Message);

            var exc1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXJ"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp1 = new ArgumentException(Resources.GetInvalidCharMessage('J')); // очікуване виключення з попереднього тесту
            Assert.AreEqual(exp.Message, exc.Message);

            var exc2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXK"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp2 = new ArgumentException(Resources.GetInvalidCharMessage('K')); // очікуване виключення з попереднього тесту
            Assert.AreEqual(exp.Message, exc.Message);

            var exc3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp3 = new ArgumentException(Resources.GetInvalidCharMessage(' ')); // очікуване виключення з попереднього тесту
            
            Assert.IsTrue(
                Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }).Message.StartsWith(Resources.GetInvalidCharMessage(' ')));

        }

        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            //вимагати щоб не призводило до виключення
            //argexc з повідомленням empty str not allow

            Assert.AreEqual(Resources.GetEmptyStringMessage(), Assert.ThrowsException<ArgumentException>(()=>RomanNumber.Parse("")).Message);
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Parse(null!));
        }
        
        [TestMethod]
        public void RomanNumberСtor()
        {
            //тест конструкторов
            RomanNumber roman;
            roman = new(10);
            Assert.IsNotNull(roman);

            roman = new(0);
            Assert.IsNotNull(roman);
        }
        

        //Проверка переопледеления метода ToString
        [TestMethod]
        public void RomanNumberToString()
        {
            RomanNumber roman = new(10);
            Assert.AreEqual("X", roman.ToString());
            roman = new(90);
            Assert.AreEqual("XC", roman.ToString());
            roman = new(1999);
            Assert.AreEqual("MCMXCIX", roman.ToString());

        }
        
        [TestMethod]
        public void RomanNumberToStringCrossTest()
        {
            //Проверка совместной работы Parse - ToString
            //Циклом генерируем числа n=0-2022;
            //Roman(n)->ToString->Parse==n
            RomanNumber num=new();
            for(int n=0;n<=2022;++n)
            {
                num.Value = n;
                Assert.AreEqual(n, RomanNumber.Parse(num.ToString()));                                                                                          
            }
        }

        [TestMethod]
        public void RomanNumberTypeTest()
        {
            RomanNumber rn1 = new(10);
            RomanNumber rn2 = rn1;
            Assert.AreSame(rn1, rn2);// rn1,rn2 - ссылки на один объект
            RomanNumber rn3 = rn1 with { }; //клонирование
            
            Assert.AreEqual(rn3, rn1);
            Assert.IsTrue(rn1 == rn3);

            RomanNumber rn4 = rn1 with { Value = 20 };

            Assert.IsFalse(rn1 == rn4);
            Assert.AreNotEqual(rn4, rn1);
            Assert.AreNotSame(rn4, rn1);
        }

        [TestMethod]
        public void RomanNumberNegative()
        {
            Assert.AreEqual(-10, RomanNumber.Parse("-X"));
            Assert.AreEqual(-400, RomanNumber.Parse("-CD"));
            Assert.AreEqual(-1900, RomanNumber.Parse("-MCM"));

            RomanNumber rn = new() { Value = -10 };
            Assert.AreEqual("-X", rn.ToString());
            rn.Value = -90;
            Assert.AreEqual("-XC", rn.ToString());

            Assert.ThrowsException<ArgumentException> (() => RomanNumber.Parse("M-CM"));//1000-900
            Assert.ThrowsException<ArgumentException> (() => RomanNumber.Parse("M-"));//1000-
            Assert.ThrowsException<ArgumentException> (() => RomanNumber.Parse("-"));//пустую строку
            Assert.ThrowsException<ArgumentException> (() => RomanNumber.Parse("-N"));//-0
            Assert.ThrowsException<ArgumentException> (() => RomanNumber.Parse("--X"));//--10
        }
    }

    [TestClass]
    public class OperationTest
    {
        [TestMethod]
        public void AddRNTest()
        {
            RomanNumber rn2 = new(2);
            RomanNumber rn5 = new(5);
            RomanNumber rn7 = new(7);
            RomanNumber rn10 = new() { Value = 10};
            RomanNumber rn_5 = new() { Value = -5 };
            RomanNumber rn_7 = new() { Value = -7 };

            Assert.AreEqual(9, rn2.Add(rn7).Value);
            Assert.AreEqual(20, rn10.Add(rn10).Value);
            Assert.AreEqual(5, rn10.Add(rn_5).Value);
            Assert.AreEqual(3, rn10.Add(rn_7).Value);

            Assert.AreEqual(10, rn5.Add(rn5).Value);

            Assert.AreEqual(7, rn7.Add(new RomanNumber(0)).Value);
            Assert.AreEqual(5, rn5.Add(new RomanNumber()).Value);
            Assert.AreEqual(25, rn5.Add(new RomanNumber(20)).Value);
            Assert.AreEqual(6, rn5.Add(new RomanNumber(1)).Value);
            Assert.AreEqual(19, rn10.Add(new RomanNumber(9)).Value);

            Assert.AreEqual(-5, rn5.Add(new RomanNumber(-10)).Value);
         
            Assert.AreEqual(rn7, rn2.Add(rn5));
            Assert.AreEqual(rn_5, rn_7.Add(rn2));
            
            Assert.AreEqual("XVII", rn7.Add(rn10).ToString());
            Assert.AreEqual("III", rn_7.Add(rn10).ToString());
            Assert.AreEqual("-V", rn_7.Add(rn2).ToString());
            Assert.AreEqual("-XII", rn_7.Add(rn_5).ToString());

            Assert.ThrowsException<ArgumentNullException>(() => rn2.Add((RomanNumber)null!));
        }

        [TestMethod]
        public void AddValueTest()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(20,rn.Add(10).Value);
            Assert.AreEqual(30,rn.Add("XX").Value);
            Assert.AreEqual(rn,rn.Add(0));
        }

        [TestMethod]
        public void AddStringTest()
        {
            var rn = new RomanNumber(10);
            Assert.AreEqual(30,rn.Add("XX").Value);
            Assert.AreEqual("-XL",rn.Add("-L").ToString());
            Assert.AreEqual(rn,rn.Add("N"));

            Assert.ThrowsException<ArgumentException>(() => rn.Add(""));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("-"));
            Assert.ThrowsException<ArgumentException>(() => rn.Add("10"));
            Assert.ThrowsException<ArgumentNullException>(() => rn.Add((String)null!));
        }

        [TestMethod]
        public void AddStaticTest()
        {
            //
            RomanNumber rn5 = RomanNumber.Add(2, 3);
            RomanNumber rn8 = RomanNumber.Add(rn5, 3);
            RomanNumber rn10 = RomanNumber.Add("I", "IX");
            RomanNumber rn9 = RomanNumber.Add(rn5, "IV");
            RomanNumber rn13 = RomanNumber.Add(rn5, rn8);
            Assert.AreEqual(5, rn5.Value);
            Assert.AreEqual(8, rn8.Value);
            Assert.AreEqual(10, rn10.Value);
            Assert.AreEqual(9, rn9.Value);
            Assert.AreEqual(13, rn13.Value);
            Assert.AreEqual("III", RomanNumber.Add(1,2).ToString());
            Assert.AreEqual("N", RomanNumber.Add(1,-1).ToString());

            //null exc
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add((String)null!, 10));
            Assert.ThrowsException<ArgumentNullException>(() => RomanNumber.Add("X", (String)null!));

            //
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("", "X"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("1", "X"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("GGG", "X"));
            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Add("-", "X"));
        }

    }
}

