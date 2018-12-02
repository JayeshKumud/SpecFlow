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
            if(message.Contains("Sorry, no results found!") || message.Equals("Sorry, no results found!"))
            {
                Assert.IsTrue(productSearchPage.MsgProductNoResults().Displayed);
            }
            else
            {
                Assert.IsTrue(productSearchPage.MsgProductResults().Displayed);
            }
        }

        [Given(@"'(.*)' displayes on product search page")]
        public void GivenDisplayesOnProductSearchPage(string product)
        {
            Assert.IsTrue(productSearchPage.MsgProductResults().Text.ToString().Contains(product));
            int count = productSearchPage.GetRows().Count;
            Assert.IsTrue(productSearchPage.GetRows().Count > 0);
        }

    }
}
