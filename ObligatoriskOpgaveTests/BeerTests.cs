using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Beer beer = new Beer()
            {
                id = 1,
                name = "Mette",
                alcoholProcent = 0
            };

            Assert.AreEqual("1 Mette 0", beer.ToString());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beerNameIsNull = new Beer()
            {
                id = 1,
                name = null,
                alcoholProcent = 0
            };

            Assert.ThrowsException<ArgumentNullException>(() => beerNameIsNull.ValidateName()); 

            Beer beerNameTooShort = new Beer()
            {
                id = 1,
                name = "No",
                alcoholProcent = 0
            };

            Assert.ThrowsException<ArgumentException>(() => beerNameTooShort.ValidateName());

            Beer beerNameIsValid = new Beer()
            {
                id = 1,
                name = "Mette",
                alcoholProcent = 0
            };
            beerNameIsValid.ValidateName();
        }

        [TestMethod()]
        [DataRow(-1)]
        [DataRow(68)]
        public void AlcoholProcentNotValidTest(int alcoholProcent)
        {

            Beer beerNotValid = new Beer()
            {
                id = 1,
                name = "Mette",
                alcoholProcent = -1
            };

            beerNotValid.alcoholProcent = alcoholProcent;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerNotValid.ValidateAlcoholProcent());
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(67)]
        public void AlcoholProcentIsValidTest(int alcoholProcent)
        {
            Beer alcoholProcentIsValid = new Beer()
            {
                id = 1,
                name = "Mette",
                alcoholProcent = 0
            };

            alcoholProcentIsValid.alcoholProcent = alcoholProcent;

            alcoholProcentIsValid.ValidateAlcoholProcent();
        }
    }
}