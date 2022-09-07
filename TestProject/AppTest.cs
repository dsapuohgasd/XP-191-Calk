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
            var exp = new ArgumentException("Invalid char A"); // очікуване виключення з попереднього тесту
            Assert.AreEqual(exp.Message, exc.Message);

            var exc1 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXJ"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp1 = new ArgumentException("Invalid char J"); // очікуване виключення з попереднього тесту
            Assert.AreEqual(exp.Message, exc.Message);

            var exc2 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("XXK"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp2 = new ArgumentException("Invalid char K"); // очікуване виключення з попереднього тесту
            Assert.AreEqual(exp.Message, exc.Message);

            var exc3 = Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }); //зберігаємо виключення, що виникає при тестуванні
            var exp3 = new ArgumentException("Invalid char"); // очікуване виключення з попереднього тесту
            Assert.IsTrue(
                Assert.ThrowsException<ArgumentException>(() => { RomanNumber.Parse("X X"); }).Message.StartsWith("Invalid char"));

        }

        [TestMethod]
        public void RomanNumberParseEmpty()
        {
            //вимагати щоб не призводило до виключення
            //argexc з повідомленням empty str not allow
            Assert.AreEqual("Empty string not allowed", Assert.ThrowsException<ArgumentException>(()=>RomanNumber.Parse("")).Message);

            Assert.ThrowsException<ArgumentException>(() => RomanNumber.Parse(null!));
        }
    }
}

