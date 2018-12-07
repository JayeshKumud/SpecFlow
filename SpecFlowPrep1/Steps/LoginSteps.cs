using SpecFlowPrep1.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPrep1.Steps
{
    [Binding]
    public class US001_LoginSteps
    {
        private LoginPage loginPage;

        public US001_LoginSteps(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }

        [Given(@"User landed on '(.*)' page")]
        public void GivenUserLandedOnPage(string p0)
        {
            
        }
        
        [Given(@"User enter below credential on login page:")]
        public void GivenUserEnterBelowCredentialOnLoginPage(Table table)
        {
            
        }
        
        [When(@"User selects '(.*)' button on login page")]
        public void WhenUserSelectsButtonOnLoginPage(string p0)
        {
            
        }
        

        [Given(@"User logged in with credential on login page:")]
        public void GivenUserLoggedInWithCredentialOnLoginPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
        }
    }
}
