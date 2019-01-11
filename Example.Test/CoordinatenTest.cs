using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Reizen.Positie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Test
{
    [TestClass]
    public class CoordinatenTest
    {
        [TestMethod]
        public void AlsCoordinatenHetzelfdeZijn_DanEqualsGeeftTrueTerug()
        {
            // Arrange
            var coordinaat1 = TestHelper.CreateRandom<long>();
            var coordinaat2 = TestHelper.CreateRandom<long>();

            var coordinaten1 = new Coordinaten(coordinaat1, coordinaat2);
            var coordinaten2 = new Coordinaten(coordinaat1, coordinaat2);

            // Act
            var resultaat = coordinaten1.Equals(coordinaten2);

            // Assert
            Assert.IsTrue(resultaat);
        }

        [TestMethod]
        public void AlsCoordinatenVerschillen_DanEqualsGeeftFalseTerug()
        {
            // Arrange
            var coordinaat1 = TestHelper.CreateRandom<long>();
            var coordinaat2 = TestHelper.CreateRandom<long>();
            var coordinaat3 = coordinaat1 + 1;
            var coordinaat4 = coordinaat2 + 1;

            var coordinaten1 = new Coordinaten(coordinaat1, coordinaat2);
            var coordinaten2 = new Coordinaten(coordinaat3, coordinaat4);

            // Act
            var resultaat = coordinaten1.Equals(coordinaten2);

            // Assert
            Assert.IsFalse(resultaat);
        }

        // Enzovoorts....
    }
}
