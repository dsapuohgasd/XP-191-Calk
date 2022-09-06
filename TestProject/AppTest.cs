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
        public void RomanNumberParse()
        {
            Assert.AreEqual(RomanNumber.Parse("I"),1,"I==1");
            Assert.AreEqual(RomanNumber.Parse("IV"), 4, "IV==4");
            Assert.AreEqual(RomanNumber.Parse("XV"), 15, "XV==15");
            Assert.AreEqual(RomanNumber.Parse("XXX"), 30, "XXX==30");
            Assert.AreEqual(RomanNumber.Parse("CM"), 900, "CM==900");
            Assert.AreEqual(RomanNumber.Parse("MCMXCIX"), 1999, "MCMXCIX==1999");
            Assert.AreEqual(RomanNumber.Parse("CD"), 400, "CD==400");
            Assert.AreEqual(RomanNumber.Parse("LV"), 55, "LV==55");
            Assert.AreEqual(RomanNumber.Parse("XL"), 40, "XL==40");

        }

    }
}

