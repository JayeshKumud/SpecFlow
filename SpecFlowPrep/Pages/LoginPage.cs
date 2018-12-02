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
    public class LoginPage : PageObject
    {
        private RemoteWebDriver driver;

        public LoginPage(RemoteWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By txtUserName = By.XPath("//input[contains(@class,'_2zrpKA')][contains(@type,'text')]");
        private By txtPassword = By.XPath("//input[contains(@type,'password')]");
        private By btnLogin = By.XPath("//button[contains(@class,'_2AkmmA')][@type='submit']");

        public IWebElement TxtUserName() => ElementVisible(txtUserName);
        public IWebElement TxtPassword() => ElementVisible(txtPassword);
        public IWebElement BtnLogin() => ElementVisible(btnLogin);

        public void Login(string username, string password)
        {
            EnterText(txtUserName, username);
            EnterText(txtPassword, password);
            ElementVisible(btnLogin).Click();
        }

    }
}
