using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.PageObjects
{
    public class SearchFlightPage : PageObject
    {
        private RemoteWebDriver driver;
        public SearchFlightPage(RemoteWebDriver driver) : base(driver) => this.driver = driver;

        private By fromText = By.CssSelector("#gosuggest_inputSrc.form-control");
        private By uiTag = By.CssSelector("#react-autosuggest-1");
        //private By uiTag = By.XPath("//ui[contains(@id,'react-autosuggest-1')]");
        private By liTag = By.XPath("//ui[contains(@id,'react-autosuggest-1')]/li[contains(text(),'Mumbai')]");
        private By toText = By.CssSelector(".form-control#gosuggest_inputDest");
        private By roundTrip = By.XPath("//input[@id='gi_roundtrip_label']");
        private By oneWayTrip = By.CssSelector("#gi_oneway_label");
        private By multiCityTrip = By.XPath("//input[@id='gi_multicity_label']");
        private By searchButton = By.CssSelector("#gi_search_btn");
        private By shCalanderBox = By.XPath("//div[contains(@class,'shCalenderBox')]");
        //private By departDiv = By.XPath("//div[contains(@class,'shCalenderBox')]/div/span[contains(text(),'Depart')]/parent::div");
        //private By returnDiv = By.XPath("//div[contains(@class,'shCalenderBox')]/div/span[contains(text(),'Return')]/parent::div");
        private By returnDiv = By.XPath("//span[contains(text(),'Return')]/parent::div");
        private By departDiv = By.XPath("//span[contains(text(),'Depart')]/parent::div");
        private By selectTraveler = By.CssSelector("#pax_label");
        private By selectClass = By.CssSelector("#gi_class");
        private By dateSelector = By.CssSelector("#fare_20181127");
        private By adultPlus = By.CssSelector("#adultPaxPlus");
        private By adultMinus = By.CssSelector("#adultPaxMinus");
        private By ChildPlus = By.CssSelector("#childPaxPlus");
        private By ChildMinus = By.CssSelector("#childPaxMinus");
        private By InfantPlus = By.CssSelector("#infantPaxPlus");
        private By InfantMinus = By.CssSelector("#infantPaxMinus");
        private By ClosePax = By.CssSelector("#pax_close");

        public void EnterFrom(String value)
        {
            ElementToBeClickable(fromText).SendKeys(value);
            //UITag().FindElement(By.XPath("//li/div/div[contains(@class,'textOverflow')]/div[contains(@class,'mainTxt clearfix')]/span[contains(text(),'" + value + "')]")).Click();
            //UITag().FindElement(By.XPath("//span[contains(text(),'" + value + "')]")).Click();
            ElementToBeClickable(By.XPath("//span[contains(text(),'" + value + "')]")).Click();
        }

        public void EnterTo(String value)
        {
            ElementToBeClickable(toText).SendKeys(value);
            //UITag().FindElement(By.XPath("//li/div/div[contains(@class,'textOverflow')]/div[contains(@class,'mainTxt clearfix')]/span[contains(text(),'" + value + "')]")).Click();
            UITag().FindElement(By.XPath("//span[contains(text(),'" + value + "')]")).Click();
            //elementToBeClickable(By.XPath("//span[contains(text(),'" + value + "')]")).Click();
        }

        public IWebElement UITag() => ElementToBeClickable(uiTag); 

        public IWebElement ToText() => ElementToBeClickable(toText); 

        public void SelectRoundTrip() => ElementToBeClickable(roundTrip).Click(); 

        public void SelectOneWayTrip() => ElementToBeClickable(oneWayTrip).Click(); 

        public void SelectMultiCityTrip() => ElementToBeClickable(multiCityTrip).Click(); 

        public void ClickSearchButton() => ElementToBeClickable(searchButton).Click(); 

        public void SelectFromDate(int dateOffSet)
        {
            string date = DateTime.Now.AddDays(dateOffSet).ToString("yyyyMMdd");
            ElementToBeClickable(departDiv).FindElement(By.XPath("//i[contains(@class,'calendar1')]")).Click();
            ElementToBeClickable(By.CssSelector("#fare_" + date)).Click();
        }

        public void SelectToDate(int dateOffSet)
        {
            string date = DateTime.Now.AddDays(dateOffSet).ToString("yyyyMMdd");
            ElementToBeClickable(returnDiv).FindElement(By.XPath("//i[contains(@class,'calendar1')]")).Click();
            ElementToBeClickable(By.CssSelector("#fare_" + date)).Click();
        }

        public void SelectPassenger(int adult, int child, int infant)
        {
            ElementToBeClickable(selectTraveler).Click();

            for (int i = 1; i < adult; i++)
            {
                ElementToBeClickable(adultPlus).Click();
            }

            for (int i = 0; i < child; i++)
            {
                ElementToBeClickable(ChildPlus).Click();
            }

            for (int i = 0; i < infant; i++)
            {
                ElementToBeClickable(InfantPlus).Click();
            }

            ElementToBeClickable(ClosePax).Click();
        }

        public void SelectClass(String classToBeSelected)
        {
            new SelectElement(ElementToBeClickable(selectClass)).SelectByText(classToBeSelected);
        }
    }
}
