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

        [When(@"I Click on '(.*)' on Home Page")]
        public void WhenIClickOnOnHomePage(string option)
        {
            if (option.Contains("Flight")) { homePage.ClickFlightLink(); }
        }
    }
}
