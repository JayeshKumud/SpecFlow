using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowPrep.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPrep.Steps
{
    [Binding]
    public class LoginSteps
    {

        private LoginPage loginPage;
        private UserHomePage homePage;
        public LoginSteps(LoginPage loginPage, UserHomePage homePage)
        {
            this.loginPage = loginPage;
            this.homePage = homePage;
        }

        [Given(@"User enter below credential on login page:")]
        public void GivenUserEnterBelowCredentialOnLoginPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            loginPage.TxtUserName().Clear();
            loginPage.TxtUserName().SendKeys(data.username);

            loginPage.TxtPassword().Clear();
            loginPage.TxtPassword().SendKeys(data.password.ToString());
        }

        [When(@"User select '(.*)' button on login page")]
        public void WhenUserSelectButtonOnLoginPage(string button)
        {
            if (button.Equals("Login")) { loginPage.BtnLogin().Click(); };
        }
        
        [Then(@"User '(.*)' displayes on home page")]
        public void ThenUserDisplayesOnHomePage(string user)
        {
            Assert.IsTrue(user.Contains(homePage.DivLoginUser().Text.ToLower().ToString()));
        }

        [Given(@"User logged in with below credential:")]
        public void GivenUserLoggedInWithBelowCredential(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login(data.username.ToString(), data.password.ToString());
        }

    }
}
