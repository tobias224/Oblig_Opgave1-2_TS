using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblig_Opgave1_2_TS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig_Opgave1_2_TS.Tests
{
    [TestClass]
    public class TrophyTests
    {
        [TestMethod]
        public void TrophyConstructorTest()
        {

            // Test
            Trophy trophy1 = new() { Year = 2000, Competition = "swimning" };


            // Assert
            Assert.AreEqual("swimning", trophy1.Competition);
            Assert.AreEqual(2000, trophy1.Year);
        }

        [TestMethod]
        public void CompetitionValidationTest()
        {
            // Test variables
            Trophy trophy1 = new() { Year = 2000, Competition = "q" };

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy1.ValidateCompetition());
        }

        [TestMethod]
        public void YearValidationTest()
        {
            // Act and Assert
            Trophy trophy1 = new() { Year = 3000, Competition = "swimming" };
            Trophy trophy2 = new() { Year = 1900, Competition = "Spydkast" };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy1.ValidateYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy2.ValidateYear());
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Test variables
            Trophy trophy = new() { Year = 2000, Competition = "swimning" };
            var expectedString = $"ID:{trophy.Id},Competition:swimning,Year:2000\n";

            // Act
            var result = trophy.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }
}