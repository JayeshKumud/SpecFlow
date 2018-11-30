using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
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
        private RemoteWebDriver driver;
        public HomePage(RemoteWebDriver driver) : base(driver) => this.driver = driver;
       
        private By signIn = By.CssSelector("#get_sign_in");
        private By flight = By.XPath("//span[contains(@class,'iconText')][contains(text(),'Flights')]");
        
        public String GetSignInTitleOption() => waitForExpectedElement(signIn).Text; 

        public void ClickFlightLink() => elementToBeClickable(flight).Click();

        public void ClickSignInLink() => elementToBeClickable(signIn).Click();
    }
}
