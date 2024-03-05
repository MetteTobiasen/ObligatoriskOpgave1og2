using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            BeersRepository beerList = new BeersRepository();

            Assert.AreEqual("1 Carlsberg Classic 4", beerList.Get().First().ToString());
        }

        [TestMethod()]
        public void AddTest()
        {
            Beer beerWithNotValidAlcoholProcent = new Beer()
            {
                name = "test",
                alcoholProcent = -1
            };

            BeersRepository repository = new BeersRepository();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.Add(beerWithNotValidAlcoholProcent));
            Assert.AreEqual(5, repository.Get().Count());

            Beer beerWithValidAlcoholProcent = new Beer()
            {   
                name = "test",
                alcoholProcent = 0
            };
            repository.Add(beerWithValidAlcoholProcent);

            Assert.AreEqual(6, repository.Get().Count());
            Assert.AreEqual("6 test 0", repository.Get().ElementAt(5).ToString());
            Assert.AreEqual("6 test 0", repository.GetById(6).ToString());
        }

        [TestMethod()]
        public void GetTest() 
        { 
            BeersRepository beerList = new BeersRepository();

            Assert.AreEqual(5, beerList.Get().Count());
            Assert.AreEqual(2, beerList.Get(4).Count());
            Assert.AreEqual(1, beerList.Get(3).Count());
            Assert.AreEqual("1 Carlsberg Classic 4", beerList.Get(orderBy: "name_asc").First().ToString());
            Assert.AreEqual("1 Carlsberg Classic 4", beerList.Get(orderBy: "name_desc").Last().ToString());
            Assert.AreEqual("3 Fynsk Forår 3", beerList.Get(orderBy: "alcoholprocent").First().ToString());
            Assert.AreEqual("3 Fynsk Forår 3", beerList.Get(orderBy: "alcoholprocent_desc").Last().ToString());

        }

        [TestMethod()]  
        public void GetByIdTest()
        {
            BeersRepository beerList = new BeersRepository();

            Assert.AreEqual("1 Carlsberg Classic 4", beerList.GetById(1).ToString());
            Assert.IsNull(beerList.GetById(6));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BeersRepository beerList = new BeersRepository();
            
            beerList.Delete(5);

            Assert.AreEqual(4, beerList.Get().Count());
            Assert.IsNull(beerList.Delete(6));

        }

        [TestMethod()]
        public void UpdateTest() 
        {
            BeersRepository BeerList = new BeersRepository();

            Beer beerToBeUpdatedNotValid = new Beer()
            {
                name = "",
                alcoholProcent = 2
            };

            Beer beerToBeUpdatedIsValid = new Beer()
            {
                name = "Fynsk Sommer",
                alcoholProcent = 2
            };

            Assert.ThrowsException<ArgumentException>(() => BeerList.Update(5, beerToBeUpdatedNotValid));
            Assert.AreEqual("3 Fynsk Sommer 2", BeerList.Update(3,beerToBeUpdatedIsValid).ToString());
            Assert.IsNull(BeerList.Update(6,beerToBeUpdatedIsValid));

        }

    }
}