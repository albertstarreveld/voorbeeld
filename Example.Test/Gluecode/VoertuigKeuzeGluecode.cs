using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Example.Test.Gluecode
{
    [Binding]
    public class VoertuigKeuzeGluecode
    {
        private Voertuig _voertuig;
        private Coordinaten _bestemming;
        
        [Given("een afstand van maximaal 500km")]
        public void KorteAfstand()
        {
            var randomX = TestHelper.CreateRandom<int>(1, 500);
            _bestemming = new Coordinaten(randomX, 0);
        }

        [Given("een afstand van minimaal 501km")]
        public void LangeAfstand()
        {
            var randomX = TestHelper.CreateRandom<int>(501, 10000);
            var randomY = TestHelper.CreateRandom<int>(501, 10000);
            _bestemming = new Coordinaten(randomX, randomY);
        }

        [When("de voertuigkeuze gemaakt wordt")]
        public void MaakVoertuig()
        {
            var huidigePositie = new Coordinaten(0, 0);

            var factory = new VoertuigFactory();
            _voertuig = factory.Create(huidigePositie, _bestemming);
        }

        [Then("wordt er voor de auto gekozen")]
        public void ControleerAuto()
        {
            Assert.IsInstanceOfType(_voertuig, typeof(Auto));
        }
        
        [Then("wordt er voor het vliegtuig gekozen")]
        public void ControleerVliegtuig()
        {
            Assert.IsInstanceOfType(_voertuig, typeof(Vliegtuig));
        }
    }
}
