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
    class UserHomePage : PageObject
    {
        private RemoteWebDriver driver;

        public UserHomePage(RemoteWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By txtUserName = By.CssSelector("");
    }
}
