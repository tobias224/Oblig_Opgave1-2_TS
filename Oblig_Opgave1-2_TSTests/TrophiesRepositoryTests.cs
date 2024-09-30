using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblig_Opgave1_2_TS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig_Opgave1_2_TS.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // objects
            TrophiesRepository repository = new TrophiesRepository();
            Trophy trophy1 = new() { Year = 2000, Competition = "swimning" };
            Trophy trophy2 = new() { Year = 2020, Competition = "Soccer" };
            //act
            repository.Add(trophy2);
            repository.Add(trophy1);

            var List = repository.GetFullList();
            var TrophyInList = repository.GetById(trophy1.Id);

            //assert 
            Assert.IsNotNull(List); // tjekker om det ikke er et null objekt
            Assert.AreEqual("swimning", TrophyInList.Competition); // tjekker om det er det rigtige string
            Assert.AreEqual(2000, TrophyInList.Year); // tjekker om det er det rigtige int
            Assert.AreEqual(7, TrophyInList.Id);
            Assert.IsTrue(repository.GetFullList().Contains(trophy1));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            TrophiesRepository repository = new TrophiesRepository();


            Assert.IsNull(repository.GetById(22));

        }

        [TestMethod()]
        public void GetFullListTest()
        {
            TrophiesRepository repository = new TrophiesRepository();

            Trophy trophy1 = new() { Year = 2000, Competition = "swimning" };
            Trophy trophy2 = new() { Year = 2020, Competition = "Soccer" };

            repository.Add(trophy2);
            repository.Add(trophy1);

            var List = repository.GetFullList();

            Assert.AreEqual(7, List.Count());

        }

        [TestMethod()]
        public void RemoveTest()
        {
            TrophiesRepository repository = new TrophiesRepository();

            Trophy trophy1 = new() { Year = 2000, Competition = "swimning" };

            repository.Add(trophy1);

            Trophy? retrophy = repository.Removebyid(trophy1.Id);

            Assert.AreEqual(5, repository.GetFullList().Count);
            Assert.IsNull(repository.Removebyid(10));
        }

        [TestMethod()]
        public void GetbydataTest()
        {
            TrophiesRepository repository = new TrophiesRepository();
            // objekts 
            var orderby = repository.Getbydata(null, null, null);
            var result = repository.Getbydata(Year: 2012, null, orderBy: null);

            var compe1 = repository.Getbydata(orderBy: "Competition_desc");
            var compe2 = repository.Getbydata(orderBy: "Competition_asc");

            var year1 = repository.Getbydata(orderBy: "year_desc");
            var year2 = repository.Getbydata(orderBy: "year_asc");

            // Assert på Competition
            Assert.AreEqual(5, orderby.Count());
            Assert.AreEqual("Handball", compe1.First().Competition);

            Assert.AreEqual(5, compe2.Count());
            Assert.AreEqual("basketball", compe2.Last().Competition);

            // Assert på Year
            Assert.AreEqual(5, orderby.Count());
            Assert.AreEqual(2012, year1.First().Year);

            Assert.AreEqual(5, year2.Count());
            Assert.AreEqual(2012, year2.Last().Year);

            ////Assert på samlet
            //Assert.AreEqual(1, result.Count()); // test fejl, skal ændre i koden
            //Assert.AreEqual(2012, result.First().Year);
            //Assert.AreEqual("basketball", result.First().Competition);

            //// throw exception
            //Assert.ThrowsException<ArgumentException>(() => repository.Getbydata(orderBy: "title"));
        }
    }
}