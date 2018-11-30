using NUnit.Framework.Internal;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;
using System.IO;

namespace SpecFlow.Library
{
    public abstract class WebDriverHelper : EventFiringWebDriver
    {
        private static RemoteWebDriver REAL_DRIVER = null;
        private static readonly Thread CLOSE_THREAD = new Thread(() => REAL_DRIVER.Quit());
        private static String BROWSER;
        private static String PLATFORM;
        private static String DRIVER_ROOT_DIR;
        private static String SELENIUM_HOST;
        private static String SELENIUM_PORT;
        private static String SELENIUM_REMOTE_URL;

        
        public WebDriverHelper() : base(REAL_DRIVER)
        {
          
        }

        public static void setBrowser()
        {
            try
            {
                SELENIUM_HOST = ConfigurationManager.AppSettings["DriverHost"];
                SELENIUM_PORT = ConfigurationManager.AppSettings["DriverPort"];
                PLATFORM = ConfigurationManager.AppSettings["Platform"];
                BROWSER = ConfigurationManager.AppSettings["Browser"];
                DRIVER_ROOT_DIR = ConfigurationManager.AppSettings["DriverDir"];

                switch (BROWSER.ToLower())
                {
                    case ("chrome"):
                        startChromeDriver();
                        break;
                    case ("firefox"):
                        startFireFoxDriver();
                        break;
                    case ("iexplore"):
                        startIEDriver();
                        break;
                    default:
                        throw new Exception("Browser " + BROWSER + " or Platform "
                                + PLATFORM + " type not supported");
                }

            }
            catch (Exception e)
            {

            }
        }

        private static String getDriverPath()
        {
            String DRIVER_PATH = ConfigurationManager.AppSettings["DriverDir"];
            return DRIVER_PATH;
        }

        private static void startIEDriver()
        {
            InternetExplorerOptions options = getInternetExploreDesiredCapabilities();
            REAL_DRIVER = new InternetExplorerDriver(options);
            REAL_DRIVER.Manage().Window.Maximize();
        }

        private static void startFireFoxDriver()
        {
            FirefoxOptions options = getFireFoxDesiredCapabilities();
            REAL_DRIVER = new FirefoxDriver();
            REAL_DRIVER.Manage().Window.Maximize();
        }

        private static IWebDriver startChromeDriver()
        {
            ChromeOptions options = getChromeDesiredCapabilities();
            REAL_DRIVER = new ChromeDriver(ChromeDriverService.CreateDefaultService(getDriverPath()), options);
            return REAL_DRIVER;
        }

        private static RemoteWebDriver getRemoteWebDriver(DriverOptions options)
        {
            SELENIUM_REMOTE_URL = "http://" + SELENIUM_HOST + ":" + SELENIUM_PORT + "/wd/hub";
            return new RemoteWebDriver(new Uri(SELENIUM_REMOTE_URL), options);
        }

        public static IWebDriver getWebDriver()
        {
            return REAL_DRIVER;
        }

        private static ChromeOptions getChromeDesiredCapabilities()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-extensions");
            options.AddArgument("--verbose");
            options.AddArgument("test-type");
            return options;
        }

        private static FirefoxOptions getFireFoxDesiredCapabilities()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            return options;
        }

        private static InternetExplorerOptions getInternetExploreDesiredCapabilities()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AddAdditionalCapability("ignoreProtectedModeSettings", true);
            options.AddAdditionalCapability("EnsureCleanSession", true);
            return options;
        }

        public new void Close()
        {
            if (Thread.CurrentThread != CLOSE_THREAD)
            {
                throw new Exception(
                "You shouldn't close this WebDriver. It's shared and will close when the JVM exits.");
            }
            base.Close();
        }
    }
}
