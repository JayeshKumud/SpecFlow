using System;
using TechTalk.SpecFlow;

namespace SpecFlowPrep1.Steps
{
    [Binding]
    public class ProductSearchSteps
    {
        [Then(@"Product search '(.*)' page displays")]
        public void ThenProductSearchPageDisplays(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Product 'mobile display on product search page")]
        public void ThenProductMobileDisplayOnProductSearchPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
