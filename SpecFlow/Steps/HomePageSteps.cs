using NUnit.Framework;
using SpecFlow.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private HomePage homePage;

        public HomePageSteps(HomePage homePage)
        {
            this.homePage = homePage;
        }

        [Given(@"I am on the HomePage")]
        public void GivenIAmOnTheHomePage()
        {
            Assert.AreEqual("Sign In", homePage.GetSignInTitleOption());
        }

        [When(@"I click '(.*)' option on HomePage")]
        public void WhenIClickOptionOnHomePage(string option)
        {
            if (option.Contains("Flight")) { homePage.ClickFlightLink(); }
        }
    }
}
