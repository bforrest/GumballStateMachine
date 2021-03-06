﻿using System;
using System.IO;
using Gumballs;
using Magnum.StateMachine;
using Magnum.Visualizers.StateMachine;
using NUnit.Framework;

namespace GumballMachineSpecs
{
    [TestFixture]
    public class TrafficLightVisualizer
    {
        [Test]
        public void I_Want_To_See_The_Machine()
        {
            var machine = new TrafficLightMachine();
            machine.RaiseEvent(TrafficLightMachine.SwitchedOn);
            var generator = new StateMachineGraphGenerator();

            string directoryPath = @"C:\Users\Barry Forrest\Documents\Visual Studio 2010\Projects\GumballStateMachine\";
            string filename = Path.Combine(directoryPath, string.Format("{0}.png", machine.GetType().Name)); 

            //Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "graph.png");
            generator.SaveGraphToFile(machine.GetGraphData(), 2560, 1920, filename);
            generator.SaveGraphToFile(machine.LightState.GetGraphData(), 2560, 1920, 
                Path.Combine(directoryPath, string.Format("{0}.png", machine.LightState.GetType().Name))); 

        }

        [Test]
        public void strings_are_shared()
        {
            var stringArray = new string[] {"String One", "String Two", "String Three"};

            var stringOne = "String One";

            Assert.AreEqual(stringOne, stringArray[0]);
            Assert.AreSame(stringOne, stringArray[0]);

        }
    }
}
