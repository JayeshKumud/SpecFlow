using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using SpecFlowPrep.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowPrep
{
    [Binding]
    public class Hooks
    {
        public readonly IObjectContainer objectContainer;
        public RemoteWebDriver driver;
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
            // extent report and html report initilize
            var htmlReporter = new ExtentHtmlReporter(Directory.GetParent(Directory.GetCurrentDirectory()) + @"\Reports\ExtentReport.html");
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
            // feature info add title
            feature = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // add scrnario node details (title in feature object)
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            SelectBrowser(BrowserType.FireFox);
            NavigateToURL(new Uri(ConfigurationManager.AppSettings["URL"]));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            new UserHomePage(driver).DivLoginUser().Click();
            Thread.Sleep(1 * 1000);
            new UserHomePage(driver).BtnLogout().Click();
            driver.Quit();
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }

            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }

        private void NavigateToURL(Uri uri)
        {
            driver.Navigate().GoToUrl(uri);
            driver.Manage().Window.Maximize();
        }

        private void SelectBrowser(BrowserType browserType)
        {
            if(browserType == BrowserType.FireFox)
            {
                var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + @"\Resource\");
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                service.HideCommandPromptWindow = true;
                service.SuppressInitialDiagnosticInformation = true;
                driver = new FirefoxDriver(service);
                objectContainer.RegisterInstanceAs<RemoteWebDriver>(driver);
            }
        }
    }

    enum BrowserType
    {
        IE,
        FireFox,
        Chrome
    }
}
