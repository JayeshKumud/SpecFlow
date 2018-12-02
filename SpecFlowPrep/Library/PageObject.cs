using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPrep.Library
{
    public class PageObject
    {
        private RemoteWebDriver driver;
        private WebDriverWait wait;
        private TimeSpan DRIVER_WAIT_TIME = TimeSpan.FromSeconds(10);

        public PageObject(RemoteWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, DRIVER_WAIT_TIME);
        }


        public IWebElement ElementExist(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        public IWebElement ElementToBeClickable(By by)
        {
            return wait.Until(d => d.FindElement(by));
        }

        public IWebElement ElementToBeClickable(By by, long waitInSeconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds)).Until(d => d.FindElement(by));
        }

        public void WaitForAlert(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public  IWebElement  ElementIsVisible(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public ReadOnlyCollection<IWebElement> PresenceOfAllElementsLocatedBy(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public void EnterText(By by)
        {
            ElementToBeClickable(by).Clear();
            ElementToBeClickable(by).Click();
        }
    }
}
