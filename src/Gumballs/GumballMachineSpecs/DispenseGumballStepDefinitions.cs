using TechTalk.SpecFlow;

namespace GumballMachineSpecs
{
    [Binding]
    public class DispenseGumballStepDefinitions
    {
        [Given(@"I have a gumball machine")]
        public void GivenIHaveAGumballMachine()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"it has an empty coin slot")]
        public void GivenItHasAnEmptyCoinSlot()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I insert a coin")]
        public void WhenIInsertACoin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the machine should transition to ""waiting for crank turn""")]
        public void ThenTheMachineShouldTransitionToWaitingForCrankTurn()
        {
            ScenarioContext.Current.Pending();
        }
    }
}