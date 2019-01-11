using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Example.Reizen;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Example.Test.Gluecode
{
    [Binding,
     Scope(Feature = "Sturen auto"),
     Scope(Feature = "Sturen vliegtuig")]
    public class SturenGluecode
    {
        private Coordinaten _positie = null;
        private Voertuig _voertuig = null;
        
        [Given("de auto rijdt")]
        public void MaakRijdendeAuto()
        {
            _voertuig = new Auto(TestHelper.CreateRandom<Coordinaten>());

            var bestuurder = TestHelper.CreateRandom<Bestuurder>();
            bestuurder.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.First());

            _voertuig.Start();
            _voertuig.Accellereer();

            _positie = _voertuig.Positie;
        }

        [Given("het vliegtuig vliegt")]
        public void MaakVliegendVliegtuig()
        {
            _voertuig = new Vliegtuig(TestHelper.CreateRandom<Coordinaten>());

            var piloot = TestHelper.CreateRandom<Bestuurder>();
            piloot.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.First());

            var copiloot = TestHelper.CreateRandom<Bestuurder>();
            copiloot.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.Last());

            _voertuig.Start();
            _voertuig.Accellereer();

            _positie = _voertuig.Positie;
        }
        
        [When(@"er naar het (\w+) wordt gestuurd")]
        public void Stuur(string invoer)
        {
            switch (invoer)
            {
                case "noorden":
                    _voertuig.Stuur(Richting.Noord);
                    break;
                case "oosten":
                    _voertuig.Stuur(Richting.Oost);
                    break;
                case "zuiden":
                    _voertuig.Stuur(Richting.Zuid);
                    break;
                case "westen":
                    _voertuig.Stuur(Richting.West);
                    break;
                default:
                    throw new NotSupportedException($"Richting {invoer} wordt niet ondersteund.)");
            }
        }

        [Then(@"rijdt de auto in (\w+) richting")]
        [Then(@"vliegt het vliegtuig in (\w+) richting")]
        public void ControleerRichting(string invoer)
        {
            switch (invoer)
            {
                case "noordelijke":
                    Assert.IsTrue(_positie.Y < _voertuig.Positie.Y);
                    break;
                case "oostelijke":
                    Assert.IsTrue(_positie.X < _voertuig.Positie.X);
                    break;
                case "zuidelijke":
                    Assert.IsTrue(_positie.Y > _voertuig.Positie.Y);
                    break;
                case "westelijke":
                    Assert.IsTrue(_positie.X > _voertuig.Positie.X);
                    break;
                default:
                    throw new NotSupportedException($"Richting {invoer} wordt niet ondersteund.)");
            }
        }
    }
}
