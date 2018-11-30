using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Library
{
    public abstract class PageObject 
    {
        private static TimeSpan DRIVER_WAIT_TIME = TimeSpan.FromSeconds(10);
        protected WebDriverWait wait;
        private RemoteWebDriver driver;

        protected PageObject(RemoteWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, DRIVER_WAIT_TIME);
        }

    
        /**
         * Returns the current page title from page
         */
        public String getCurrentPageTitle()
        {
            return driver.Title;
        }

        /**
         * An expectation for checking the title of a page.
         *
         * @param title the expected title, which must be an exact match
         * @return true when the title matches, false otherwise
         */
        public bool checkPageTitle(String title)
        {
            //return new WebDriverWait(getWebDriver(), DRIVER_WAIT_TIME).Until(ExpectedConditions.TitleIs(title));
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(d => d.Title.Equals(title));
        }

        /**
         * An expectation for checking that the title contains a case-sensitive
         * substring
         * Function updated with Lemda
         * @param title the fragment of title expected
         * @return true when the title matches, false otherwise
         */
        public bool checkPageTitleContains(String title)
        {
            //return new WebDriverWait(getWebDriver(), DRIVER_WAIT_TIME).Until(ExpectedConditions.TitleContains(title));
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(d => d.Title.Contains(title));
        }

        /**
         * An expectation for the URL of the current page to be a specific url.
         *
         * @param url the url that the page should be on
         * @return <code>true</code> when the URL is what it should be
         */
        public bool checkPageUrlToBe(String url)
        {
            //return new WebDriverWait(getWebDriver(), DRIVER_WAIT_TIME).Until(ExpectedConditions.UrlToBe(url));
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(d => d.Url.Equals(url));
        }

        /**
         * An expectation for the URL of the current page to contain specific text.
         *
         * @param fraction the fraction of the url that the page should be on
         * @return <code>true</code> when the URL contains the text
         */
        public bool checkPageUrlContains(String fraction)
        {
            //return new WebDriverWait(getWebDriver(), DRIVER_WAIT_TIME).Until(ExpectedConditions.UrlContains(fraction));
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(d => d.Url.Contains(fraction));
        }

        /**
         * Find the dynamic element wait Until its visible
         *
         * @param by Element location found by css, xpath, id etc...
         **/
        protected IWebElement waitForExpectedElement(By by)
        {
            //return wait.Until(ExpectedConditions.ElementExists(by));
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(d => d.FindElement(by));
        }

        /**
         * Find the dynamic element wait Until its visible for a specified time
         *
         * @param by                Element location found by css, xpath, id etc...
         * @param waitTimeInSeconds max time to wait Until element is visible
         **/

        public IWebElement waitForExpectedElement(By by, long waitTimeInSeconds)
        {
            try
            {
                //return new WebDriverWait(getWebDriver(), TimeSpan.FromSeconds(waitTimeInSeconds)).Until(d => d.FindElement(by));
                return new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds)).Until(visibilityOfElementLocated(by));
            }
            catch (NoSuchElementException e)
            {
                return null;
            }
            catch (TimeoutException e)
            {
                return null;
            }
        }

        private Func<IWebDriver, IWebElement> visibilityOfElementLocated(By by)
        {
            return driver =>
            {
                IWebElement element = driver.FindElement(by);
                return element.Displayed ? element : null;
            };
        }

        /**
         * An expectation for checking if the given text is present in the specified element.
         *
         * @param element the WebElement
         * @param text    to be present in the element
         * @return true once the element contains the given text
         */
        public bool textToBePresentInElement(IWebElement element, String text)
        {
            //return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(ExpectedConditions.TextToBePresentInElement(element, text));
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));
        }


        /**
         * An expectation for checking if the given text is present in the element that matches
         * the given locator.
         *
         * @param by   used to find the element
         * @param text to be present in the element found by the locator
         * @return true once the first element located by locator contains the given text
         */
        public bool textToBePresentInElementLocated(By by, String text)
        {
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }


        /**
         * An expectation for checking if the given text is present in the specified
         * elements value attribute.
         *
         * @param element the WebElement
         * @param text    to be present in the element's value attribute
         * @return true once the element's value attribute contains the given text
         */
        public bool textToBePresentInElementValue(IWebElement element, String text)
        {
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(element, text));
        }


        /**
         * An expectation for checking if the given text is present in the specified
         * elements value attribute.
         *
         * @param by   used to find the element
         * @param text to be present in the value attribute of the element found by the locator
         * @return true once the value attribute of the first element located by locator contains
         * the given text
         */
        public bool textToBePresentInElementValue(By by, String text)
        {
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(by, text));
        }


        /**
         * An expectation for checking whether the given frame is available to switch
         * to. <p> If the frame is available it switches the given driver to the
         * specified frame.
         *
         * @param frameLocator used to find the frame (id or name)
         */
        public IWebDriver frameToBeAvailableAndSwitchToIt(String frameLocator)
        {
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocator));
        }


        /**
         * An expectation for checking whether the given frame is available to switch
         * to. <p> If the frame is available it switches the given driver to the
         * specified frame.
         *
         * @param by used to find the frame
         */
        public IWebDriver frameToBeAvailableAndSwitchToIt(By by)
        {
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
        }


        /**
         * An expectation for checking that an element is either invisible or not
         * present on the DOM.
         *
         * @param by used to find the element
         */
        public bool invisibilityOfElementLocated(By by)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        /**
         * An expectation for checking that an element with text is either invisible
         * or not present on the DOM.
         *
         * @param by   used to find the element
         * @param text of the element
         */
        public bool invisibilityOfElementWithText(By by, String text)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(by, text));
        }


        /**
         * An expectation for checking an element is visible and enabled such that you
         * can click it.
         *
         * @param by used to find the element
         * @return the WebElement once it is located and clickable (visible and enabled)
         */
        public IWebElement elementToBeClickable(By by)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }


        /**
         * An expectation for checking an element is visible and enabled such that you
         * can click it.
         *
         * @param element the WebElement
         * @return the (same) WebElement once it is clickable (visible and enabled)
         */

        public IWebElement elementToBeClickable(IWebElement element)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }


        /**
         * Wait Until an element is no longer attached to the DOM.
         *
         * @param element The element to wait for.
         * @return false is the element is still attached to the DOM, true
         * otherwise.
         */
        public bool stalenessOf(IWebElement element)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
        }

        /**
         * An expectation for checking if the given element is selected.
         */
        public bool elementToBeSelected(By by)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(by));
        }

        /**
         * An expectation for checking if the given element is selected.
         */
        public bool elementToBeSelected(IWebElement element)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
        }

        /**
         * An expectation for checking if the given element is selected.
         */
        public bool elementSelectionStateToBe(IWebElement element, bool selected)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementSelectionStateToBe(element, selected));
        }

        /**
         * An expectation for checking if the given element is selected.
         */
        public bool elementSelectionStateToBe(By by, bool selected)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementSelectionStateToBe(by, selected));
        }

        public void waitForAlert()
        {
            (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        /**
         * An expectation for checking that all elements present on the web page that
         * match the locator are visible. Visibility means that the elements are not
         * only displayed but also have a height and width that is greater than 0.
         *
         * @param by used to find the element
         * @return the list of WebElements once they are located
         */
        public ReadOnlyCollection<IWebElement> visibilityOfAllElementsLocatedBy(By by)
        {
            return new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }


        /**
         * An expectation for checking that all elements present on the web page that
         * match the locator are visible. Visibility means that the elements are not
         * only displayed but also have a height and width that is greater than 0.
         *
         * @param elements list of WebElements
         * @return the list of WebElements once they are located
         */
        public ReadOnlyCollection<IWebElement> visibilityOfAllElements(ReadOnlyCollection<IWebElement> elements)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
        }


        /**
         * An expectation for checking that there is at least one element present on a
         * web page.
         *
         * @param by used to find the element
         * @return the list of WebElements once they are located
         */
        public ReadOnlyCollection<IWebElement> presenceOfAllElementsLocatedBy(By by)
        {
            return (new WebDriverWait(driver, DRIVER_WAIT_TIME)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

         /**
         * An expectation for checking that an element is present on the DOM of a
         * page. This does not necessarily mean that the element is visible.
         *
         * @param by used to find the element
         * @return the WebElement once it is located
         */
        public bool isElementPresent(By by)
        {
            try
            {
                new WebDriverWait(driver, DRIVER_WAIT_TIME).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
            catch (TimeoutException e)
            {
                return false;
            }
            return true;
        }

        public void navigateToPreviousPageUsingBrowserBackButton()
        {
            driver.Navigate().Back();
        }

        public void clickWithinElementWithXYCoordinates(IWebElement webElement, int x, int y)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(webElement, x, y);
            builder.Click();
            builder.Perform();
        }

        public String getElementByTagNameWithJSExecutor(String tagName)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return window.getComputedStyle(document.getElementsByTagName('" + tagName + "')").ToString();
        }

        public String getElementByQueryJSExecutor(String cssSelector)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return window.getComputedStyle(document.querySelector('" + cssSelector + "')").ToString();
        }

        public void SelectJavaScriptElement(IWebElement element, String value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.height='auto'; arguments[0].style.visibility='visible';", element);
            element.Click();
        }

        /**
         * Wrapper for driver.findElement
         *
         * @param by Element location found by css, xpath, id etc...
         **/
        protected IWebElement findElement(By by)
        {
            return driver.FindElement(by);
        }

        /**
         * Wrapper for clear data and sendKeys in Input Text box
         *
         * @param by        Element location found by css, xpath, id etc...
         * @param inputText text to be entered
         **/

        protected void clearEnterText(By by, String inputText)
        {
            findElement(by).Clear();
            findElement(by).SendKeys(inputText);
        }

        /**
         * Wrapper for wait, clear data and sendKeys in Input Text box
         * <p>
         * * @param by Element location found by css, xpath, id etc...
         *
         * @param inputText text to be entered
         **/
        protected void waitClearEnterText(By by, String inputText)
        {
            waitForExpectedElement(by).Clear();
            findElement(by).SendKeys(inputText);

        }
    }
}
