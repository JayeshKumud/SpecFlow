using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Library
{
    public class UrlBuilder
    {
        public static void startAtHomePage()
        {
            WebDriverHelper.getWebDriver().Navigate().GoToUrl((ConfigurationManager.AppSettings["URL"]));
        }
    }
}
