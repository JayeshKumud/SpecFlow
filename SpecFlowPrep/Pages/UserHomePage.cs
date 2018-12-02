using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class UserHomePage : PageObject
    {
        private RemoteWebDriver driver;

        public UserHomePage(RemoteWebDriver driver) : base(driver) => this.driver = driver;

        /// <summary>
        /// page element
        /// </summary>
        private By divLoginUser = By.CssSelector("._2cyQi_");
        private By txtSearch = By.CssSelector(".LM6RPg");
        private By btnSearch = By.CssSelector(".vh79eN");
        private By btnLogout = By.XPath("//div[contains(@class,'_2k0gmP')][contains(text(),'Logout')]");

        public IWebElement DivLoginUser() => ElementVisible(divLoginUser);
        public IWebElement BtnLogout() => ElementVisible(btnLogout);
        public IWebElement BtnSearch() => ElementVisible(btnSearch);

        public void SearchProduct(string product)
        {
            EnterText(txtSearch, product);
            ElementVisible(btnSearch).Click();
        }
    }
}
