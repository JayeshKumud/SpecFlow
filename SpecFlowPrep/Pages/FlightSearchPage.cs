using OpenQA.Selenium.Remote;
using SpecFlowPrep.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPrep.Pages
{
    public class FlightSearchPage : PageObject
    {
        private RemoteWebDriver driver;

        public FlightSearchPage(RemoteWebDriver driver) : base(driver) => this.driver = driver;

    }
}
