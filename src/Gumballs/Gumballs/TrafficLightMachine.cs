using System;
using System.Runtime.Serialization;
using Magnum.StateMachine;

namespace Gumballs
{
    [Serializable]
    public class TrafficLightMachine : StateMachine<TrafficLightMachine>
    {
        static TrafficLightMachine()
        {
            Define( () =>
                        {
                            Anytime(
                                When(SwitchedOn)
                                .Then( workflow => workflow.LogEvent(SwitchedOn))
                                    .TransitionTo(On).TransitionTo(Red),
                                When(SwitchedOff)
                                .Then(workflow =>
                                          {
                                              workflow.LogEvent(SwitchedOff);
                                              // another step
                                              // another step...
                                          })
                                    .TransitionTo(Off));

                            During(Red, 
                                When(TransitionToGreen)
                                .Then( workflow => workflow.LogEvent(SwitchedOff))
                                .TransitionTo(Green));

                            During(Green, 
                                When(TransitionToYellow)
                                              .TransitionTo(Yellow));
                            During(Yellow, 
                                When(TransitionToRed)
                                .Then(workflow => workflow.TakePhoto())
                                .TransitionTo(Red));
                        }
                );
        }

        private void TakePhoto()
        {
            // TODO: Photograph any light runners
        }

        private void LogEvent(Event triggerEvent)
        {

            Console.WriteLine(triggerEvent.Name);
        }

        public TrafficLightMachine(){}

        public TrafficLightMachine(SerializationInfo info,
            StreamingContext context) : base(info, context){}

        public static State Initial { get; set; }
        public static State Off { get; set; }
        public static State On { get; set; }

        public static State Red { get; set; }
        public static State Yellow { get; set; }
        public static State Green { get; set; }

        public static State Completed { get; set; }

        public static Event SwitchedOn { get; set; }
        public static Event SwitchedOff { get; set; }
        public static Event TransitionToRed { get; set; }
        public static Event TransitionToYellow { get; set; }

        public static Event TransitionToGreen { get; set; }
    }
}