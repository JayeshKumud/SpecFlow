using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecFlowPrep1
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private RemoteWebDriver driver;

        private static ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var htmlReporter = new ExtentHtmlReporter(Directory.GetCurrentDirectory() + @"\Reports\ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            scenario = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            feature = scenario.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            SelectBrowser(BrowserType.FireFox);
            NavigateToURL(new Uri(ConfigurationManager.AppSettings["URL"]));

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        private void NavigateToURL(Uri uri)
        {
            driver.Navigate().GoToUrl(uri);
        }

        private void SelectBrowser(BrowserType browser)
        {
            if (browser.Equals(BrowserType.FireFox))
            {
                var dirDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resource\";
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(dirDriver, "geckodriver.exe");
                service.HideCommandPromptWindow = true;
                driver = new FirefoxDriver(service);
                objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
            }
        }
    }
    enum BrowserType
    {
        IE,
        Chrome,
        FireFox
    }
}
