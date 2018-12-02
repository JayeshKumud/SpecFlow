using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowPrep.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowPrep.Steps
{
    [Binding]
    public class ProductSearchSteps
    {
        private ProductSearchPage productSearchPage;

        public ProductSearchSteps(ProductSearchPage productSearchPage)
        {
            this.productSearchPage = productSearchPage;
        }

        [Then(@"Product search page displays for '(.*)'")]
        public void ThenProductSearchPageDisplaysFor(string product)
        {
            Assert.IsTrue(productSearchPage.CheckPageTitle(product));
        }

        [Then(@"'(.*)' displays on product search page")]
        public void ThenDisplaysOnProductSearchPage(string message)
        {
            if(message.Contains("Sorry, no results found!"))
            {
                Assert.IsTrue(productSearchPage.MsgProductNoResults().Displayed);
            }
            else if (message.Contains("No Records"))
            {
                Assert.IsTrue(productSearchPage.MsgProductResults().Displayed);
            }
        }

    }
}
