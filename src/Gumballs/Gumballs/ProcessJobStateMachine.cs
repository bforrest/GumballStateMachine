using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magnum.StateMachine;

namespace Gumballs
{
    [Serializable]
    public class ProcessJobStateMachine : StateMachine<ProcessJobStateMachine>
    {
        static ProcessJobStateMachine()
        {
            //Define();
        }

        public static State Pooled_Queued { get; set; }
        public static StateMachine ActiveStates { get; set; }

        public static StateMachine PostActive { get; set; }
        public static State Completed { get; set; }


        
    }

    [Serializable]
    public class PostActive : StateMachine<PostActive>
    {
        static PostActive()
        {//
           // Define();
        }

        public static State ProcessComplete { get; set; }

        public static State Aborted { get; set; }

        public static State Stopped { get; set; }
    }

    [Serializable]
    public class Active : StateMachine<Active>
    {
        static Active()
        {
            //Define( ()=> ) ;
            //    );
        }

        public static State Completed { get; set; }
    }
}