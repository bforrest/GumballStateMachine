using System.Runtime.Serialization;

namespace Gumballs
{
    using System;
    using Magnum.StateMachine;

    [Serializable]
    public class GumballMachineWorkflow : StateMachine<GumballMachineWorkflow>
    {
        static GumballMachineWorkflow()
        {
            Define(() =>
                       {
                           Initially(When(TokenAdded)
                               .TransitionTo(WaitingForHandleTurn));

                           During(WaitingForToken, 
                                    When(TokenAdded)
                                    .TransitionTo(WaitingForHandleTurn));

                           During(WaitingForHandleTurn,
                                    When(HandleTurned)
                                    .Then( worflow =>
                                               {
                                                   worflow.Dispense();
                                                   // check stock
                                               }
                                    ).TransitionTo(GumballDispensed));

                           During(GumballDispensed,
                                  When(LastGumballSold)
                                      .TransitionTo(SoldOut),
                                  When(TokenCleared)
                           .TransitionTo(WaitingForToken));
                           
                           During(SoldOut,
                                  When(Restocked)
                                      .Then(workflow => workflow.Restock(Restocked))
                                      .TransitionTo(WaitingForToken));
                       }
            );
        }

        private void Restock(Event<RestockDetails> restockEvent )
        {
            Quantity += ((RestockDetails)restockEvent).Quantity;
        }

        public GumballMachineWorkflow(){}

        public GumballMachineWorkflow(SerializationInfo info,
            StreamingContext context) : base(info, context){}


        public void Dispense()
        {
            Quantity--;
            RaiseEvent(Quantity == 0 ? LastGumballSold : TokenCleared);
        }

        public static State Initial { get; set; }
        public static State WaitingForToken { get; set; }
        public static State WaitingForHandleTurn { get; set; }
        public static State GumballDispensed { get; set; }
        public static State SoldOut { get; set; }
        public static State Completed { get; set; }

        public static Event TokenAdded { get; set; }
        public static Event HandleTurned { get; set; }
        public static Event LastGumballSold { get; set; }
        public static Event<RestockDetails> Restocked { get; set; }
        public static Event TokenCleared { get; set; }


        public int Quantity { get; private set; }
    }
}