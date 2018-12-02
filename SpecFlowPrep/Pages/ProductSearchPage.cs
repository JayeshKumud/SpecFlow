using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecFlowPrep.Library;
using System;
using System.Collections.Generic;
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
        private By msgProductNoResults = By.CssSelector("DUFPUZ");

        public bool CheckProductPage(string page) => CheckPageTitle(page);
        public IWebElement MsgProductResults() => ElementVisible(msgProductResults);
        public IWebElement MsgProductNoResults() => ElementVisible(msgProductNoResults);

    }
}
