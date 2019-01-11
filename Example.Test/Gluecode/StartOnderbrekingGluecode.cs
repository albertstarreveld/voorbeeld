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
     Scope(Feature = "Startonderbreking auto"),
     Scope(Feature = "Startonderbreking vliegtuig")]
    public class StartOnderbrekingGluecode
    {
        private Exception _foutmelding = null;
        private Voertuig _voertuig = null;

        [Given("de auto staat stil")]
        public void MaakStilstaandeAuto()
        {
            _voertuig = new Auto(TestHelper.CreateRandom<Coordinaten>());
        }

        [Given("het vliegtuig staat stil")]
        public void MaakStilstaandVliegtuig()
        {
            _voertuig = new Vliegtuig(TestHelper.CreateRandom<Coordinaten>());
        }

        [Given("de bestuurder is ingestapt")]
        [Given("de piloot is ingestapt")]
        public void BestuurderStaptIn()
        {
            var bestuurder = TestHelper.CreateRandom<Bestuurder>();
            bestuurder.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.First());
        }
        
        [Given("de copiloot is ingestapt")]
        public void CopilootStaptIn()
        {
            var bestuurder = TestHelper.CreateRandom<Bestuurder>();
            bestuurder.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.Last());
        }

        [When("de auto wordt gestart")]
        [When("het vliegtuig wordt gestart")]
        public void StartAuto()
        {
            try
            {
                _voertuig.Start();
            }
            catch(Exception foutmelding)
            {
                _foutmelding = foutmelding;
            }
        }

        [Then("lukt het niet om de auto te starten")]
        [Then("lukt het niet om het vliegtuig te starten")]
        public void ControleerAutoStartNiet()
        {
            Assert.IsNotNull(_foutmelding);
            Assert.IsInstanceOfType(_foutmelding, typeof(InvalidOperationException));
        }

        [Then("gaat de auto aan")]
        [Then("gaat het vliegtuig aan")]
        public void ControleerAutoGestart()
        {
            Assert.AreEqual(VoertuigStatus.Gestart, _voertuig.VoertuigStatus);
        }
    }
}
