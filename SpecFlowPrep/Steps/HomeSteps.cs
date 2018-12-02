using SpecFlowPrep.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPrep.Steps
{
    [Binding]
    public class HomeSteps
    {
        private UserHomePage userHomePage;

        public HomeSteps(UserHomePage userHomePage) => this.userHomePage = userHomePage;
    
        [Given(@"User enter '(.*)' on home page")]
        public void GivenUserEnterOnHomePage(string product)
        {
            userHomePage.SearchProduct(product);
        }
        
        [When(@"I select '(.*)' button on home page")]
        public void WhenISelectButtonOnHomePage(string button)
        {
            if (button.Equals("Search")) { userHomePage.BtnSearch().Click(); }
        }

        [Given(@"User search for '(.*)' on home page")]
        public void GivenUserSearchForOnHomePage(string product)
        {
            userHomePage.SearchProduct(product);
            userHomePage.BtnSearch().Click();
        }
    }
}
