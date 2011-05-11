using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gumballs;
using NUnit.Framework;

namespace GumballMachineSpecs
{
    [TestFixture]
    public class Given_A_New_TrafficLightMachine
    {
        private TrafficLightMachine trafficLight;
        [SetUp]
        public void TestInitialize()
        {
            trafficLight = new TrafficLightMachine();
        }

        [Test]
        public void TrafficLightMachine_ShouldInitializeTo_Initial()
        {
            Assert.AreEqual(trafficLight.CurrentState, TrafficLightMachine.Initial);
        }

        [Test]
        public void LightOperatingState_ShouldBe_Initial()
        {
            Assert.IsNotNull(trafficLight.LightState);
            Assert.AreEqual(trafficLight.LightState.CurrentState, LightOperatingStates.Initial);
        }

        [Test]
        public void When_SwitchedOn_StateShouldBe_On()
        {
            trafficLight.RaiseEvent(TrafficLightMachine.SwitchedOn);
            Assert.AreEqual(trafficLight.CurrentState, TrafficLightMachine.On);
        }
        [Test]
        public void When_SwitchedOn_LigthState_ShouldBe_Green()
        {
            trafficLight.RaiseEvent(TrafficLightMachine.SwitchedOn);
            Assert.AreEqual(trafficLight.LightState.CurrentState, LightOperatingStates.Green);
        }
    }
}
