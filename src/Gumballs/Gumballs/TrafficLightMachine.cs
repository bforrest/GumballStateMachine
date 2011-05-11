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
                                        .TransitionTo(On)
                                        .Then(workflow =>
                                                  {
                                                      workflow.TurnSignalOn();
                                                  }
                                        ),
                                When(SwitchedOff)
                                    .Then(workflow =>
                                                {
                                                    workflow.LogEvent(SwitchedOff);
                                                    // another step
                                                    // another step...
                                                })
                                    .TransitionTo(Off));
                        }
                );
        }

        private void TurnSignalOn()
        {
            LightState.RaiseEvent(LightOperatingStates.TransitionToGreen);
        }

        private void LogEvent(Event triggerEvent)
        {

            Console.WriteLine(triggerEvent.Name);
        }

        public TrafficLightMachine()
        {
            if (LightState == null)
                LightState = new LightOperatingStates();
        }

        public TrafficLightMachine(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public static State Initial { get; set; }
        public static State Off { get; set; }
        public static State On { get; set; }
        public static State Completed { get; set; }

        public static Event SwitchedOn { get; set; }
        public static Event SwitchedOff { get; set; }

        public LightOperatingStates LightState { get; set; }

    }

    public class LightOperatingStates : StateMachine<LightOperatingStates>
    {
        static LightOperatingStates()
        {
            Define( () =>
                        {
                            Anytime(
                                When(TransitionToRed)
                                        .TransitionTo(Red)
                                        .Then(work => work.TakePhoto()),
                                 When(TransitionToGreen)
                                    .TransitionTo(Green));

                            During(Red,
                                   When(TransitionToGreen)
                                       .Then(workflow => workflow.LogEvent(TransitionToGreen))
                                       .TransitionTo(Green));

                            During(Green,
                                   When(TransitionToYellow)
                                       .TransitionTo(Yellow));

                            During(Yellow,
                                   When(TransitionToRed)
                                       .Then(workflow => workflow.TakePhoto())
                                       .TransitionTo(Red));
                        });
        }

        private void TakePhoto()
        {
            // TODO: Photograph any light runners
            Console.WriteLine("Photo on Red");
        }

        private void LogEvent(Event triggerEvent)
        {
            Console.WriteLine(triggerEvent.Name);
        }

        public static State Initial { get; set; }
        public static State Red { get; set; }
        public static State Yellow { get; set; }
        public static State Green { get; set; }
        public static State Completed { get; set; }

        public static Event TransitionToRed { get; set; }
        public static Event TransitionToYellow { get; set; }
        public static Event TransitionToGreen { get; set; }
    }
}