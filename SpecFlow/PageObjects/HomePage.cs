using OpenQA.Selenium;
using SpecFlow.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.PageObjects
{
    public class HomePage : PageObject
    {
        private By signInLink = By.CssSelector("#get_sign_in");
        private By flightLink = By.XPath("//span[contains(@class,'iconText')][contains(text(),'Flights')]");

        public String GetSignInTitleOption() { return waitForExpectedElement(signInLink).Text; }

        public void ClickFlightLink() { elementToBeClickable(flightLink).Click(); }
    }
}
