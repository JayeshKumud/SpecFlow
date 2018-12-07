using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SpecFlowPrep1.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPrep1.Pages
{
    public class ProductSearchPage : PageObject
    {
        private RemoteWebDriver driver;

        public ProductSearchPage(RemoteWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By txtUserName = By.CssSelector("");
        private By txtPassword = By.CssSelector("");
        private By btnLogin = By.CssSelector("");

        public IWebElement TxtUserName() => ElementVisible(txtUserName);
        public IWebElement TxtPassword() => ElementVisible(txtPassword);
        public IWebElement BtnLogin() => ElementVisible(btnLogin);
    }
}
