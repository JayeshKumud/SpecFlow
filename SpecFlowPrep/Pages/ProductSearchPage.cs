using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecFlowPrep.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPrep.Pages
{
    public class ProductSearchPage : PageObject
    {
        private RemoteWebDriver driver;

        public ProductSearchPage(RemoteWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By msgProductResults = By.CssSelector("._2yAnYN"); 
        private By msgProductNoResults = By.XPath("//div[@class='DUFPUZ']");
        private By rowProducts = By.XPath("//div[@class,'_3e7xtJ']/div/div[@class='_1HmYoV']/div");
        private By divLowToHigh = By.XPath("//div[contains(text(),'Price -- Low to High')]");
        private By divHighToLow = By.XPath("//div[contains(text(),'Price -- High to Low')]");

        public bool CheckProductPage(string page) => CheckPageTitle(page);
        public IWebElement MsgProductResults() => ElementVisible(msgProductResults);
        public IWebElement MsgProductNoResults() => ElementVisible(msgProductNoResults);
        public IWebElement DivLowToHigh() => ElementVisible(divLowToHigh);
        public IWebElement DivHighToLow() => ElementVisible(divHighToLow);
        public ReadOnlyCollection<IWebElement> GetRows() => PresenceOfAllElementsLocatedBy(rowProducts);
    }
}
