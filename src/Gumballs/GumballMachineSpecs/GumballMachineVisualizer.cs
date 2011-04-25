using System;
using System.IO;
using System.Reflection;
using Gumballs;
using Magnum.StateMachine;
using Magnum.Visualizers.StateMachine;
using Magnum;
using NUnit.Framework;

namespace GumballMachineSpecs
{
    [TestFixture]
    public class GumballMachineVisualizer
    {
        [Test]
        public void I_Want_To_See_The_Machine()
        {
            var machine = new GumballMachineWorkflow();
            var generator = new StateMachineGraphGenerator();
            
            string filename = Path.Combine(@"c:\temp\", string.Format("{0}.png", machine.GetType().Name)); //Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "graph.png");
            generator.SaveGraphToFile(machine.GetGraphData(), 2560, 1920, filename);
        }
    }
}