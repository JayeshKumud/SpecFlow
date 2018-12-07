using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPrep1.Library
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

        public bool PageTitle(string value)
        {
            return wait.Until(d => d.Url.Contains(value));
        }

        public IWebElement GetElement(By by)
        {
            return wait.Until(d => d.FindElement(by));
        }

        public IWebElement ElementVisible(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public IWebElement ElementToBeClickable(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public bool ElementToBeSelected(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(by));
        }

        public ReadOnlyCollection<IWebElement> PresenceOfAllElementsLocatedBy(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public ReadOnlyCollection<IWebElement> VisibilityOfAllElementsLocatedBy(By by)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public void EnterText(By by, string value)
        {
            ElementVisible(by).Clear();
            ElementVisible(by).SendKeys(value);
        }
    }
}
