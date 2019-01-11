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
     Scope(Feature = "Remmen auto"),
     Scope(Feature = "Remmen vliegtuig"),
     Scope(Feature = "Accelereren auto"),
     Scope(Feature = "Accelereren vliegtuig")]
    public class RemmenEnAccelererenGluecode
    {
        private int _snelheid = 0;
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

        [Given("de auto rijdt")]
        public void MaakRijdendeAuto()
        {
            MaakStilstaandeAuto();

            var bestuurder = TestHelper.CreateRandom<Bestuurder>();
            bestuurder.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.First());

            _voertuig.Start();
            _voertuig.Accellereer();

            _snelheid = _voertuig.Snelheid;
        }

        [Given("het vliegtuig vliegt")]
        public void MaakVliegendVliegtuig()
        {
            MaakStilstaandVliegtuig();

            var piloot = TestHelper.CreateRandom<Bestuurder>();
            piloot.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.First());

            var copiloot = TestHelper.CreateRandom<Bestuurder>();
            copiloot.StapIn(_voertuig, _voertuig.BestuurdersPlaatsen.Last());

            _voertuig.Start();
            _voertuig.Accellereer();

            _snelheid = _voertuig.Snelheid;
        }

        [Given("de auto rijdt de maximale snelheid")]
        public void MaakVolGasRijdendeAuto()
        {
            MaakRijdendeAuto();

            while (_voertuig.MaximaleSnelheid != _voertuig.Snelheid)
            {
                _voertuig.Accellereer();
            }

            _snelheid = _voertuig.Snelheid;
        }
        
        [Given("het vliegtuig vliegt de maximale snelheid")]
        public void MaakVolGasVliegendVliegtuig()
        {
            MaakStilstaandVliegtuig();

            while (_voertuig.MaximaleSnelheid != _voertuig.Snelheid)
            {
                _voertuig.Accellereer();
            }

            _snelheid = _voertuig.Snelheid;
        }
        
        [When("er wordt geaccellereerd")]
        public void Accellereer()
        {
            _voertuig.Accellereer();
        }

        [When("er wordt geremd")]
        public void Rem()
        {
            _voertuig.Rem();
        }
        
        [Then("neemt de snelheid toe")]
        public void ControleerSnelheidNeemtToe()
        {
            Assert.IsTrue(_voertuig.Snelheid > _snelheid);
        }

        [Then("neemt de snelheid af")]
        public void ControleerSnelheidNeemtAf()
        {
            Assert.IsTrue(_voertuig.Snelheid < _snelheid);
        }
        
        [Then("blijft de snelheid gelijk")]
        public void ControleerSnelheidBlijftGelijk()
        {
            Assert.AreEqual(_snelheid, _voertuig.Snelheid);
        }
    }
}
