using SpecFlow.Library;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class NavigationalSteps
    {
        [Given(@"I have Launch in '(.*)'")]
        public void GivenIHaveLaunchIn(string browser)
        {
            WebDriverHelper.setBrowser();
        }
        
        [When(@"I Navigate to URL '(.*)'")]
        public void WhenINavigateToURL(string url)
        {
            UrlBuilder.startAtHomePage();
        }
        
    
    }
}
