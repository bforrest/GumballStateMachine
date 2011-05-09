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
            var generator = new StateMachineGraphGenerator();

            string filename = Path.Combine(@"C:\Users\Barry Forrest\Documents\Visual Studio 2010\Projects\GumballStateMachine\", string.Format("{0}.png", machine.GetType().Name)); //Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), "graph.png");
            generator.SaveGraphToFile(machine.GetGraphData(), 2560, 1920, filename);
        }
    }
}
