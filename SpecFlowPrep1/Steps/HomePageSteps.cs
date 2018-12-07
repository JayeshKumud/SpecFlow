using System;
using TechTalk.SpecFlow;

namespace SpecFlowPrep1.Steps
{
    [Binding]
    public class HomePageSteps
    {
        [Given(@"User entered '(.*)' as product on home page")]
        public void GivenUserEnteredAsProductOnHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects '(.*)' button on home page")]
        public void WhenUserSelectsButtonOnHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User '(.*)' displays on user home page")]
        public void ThenUserDisplaysOnUserHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"User '(.*)' display on user home page")]
        public void GivenUserDisplayOnUserHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
