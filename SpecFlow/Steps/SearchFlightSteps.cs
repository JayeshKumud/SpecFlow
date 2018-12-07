using Microsoft.VisualBasic.Devices;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.PageObjects;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow.Steps
{
    [Binding]
    public class SearchFlightSteps
    {
        private SearchFlightPage searchFlightPage;

        public SearchFlightSteps(SearchFlightPage searchFlightPage)
        {
            this.searchFlightPage = searchFlightPage;
        }

        [Then(@"I see Flight Search Page")]
        public void ThenISeeFlightSearchPage()
        {
            Assert.IsTrue(searchFlightPage.CheckPageTitleContains("Flight"), "correct page displayed.");
        }

        [Given(@"I entered the followings data as Flight Search Criteria")]
        public void GivenIEnteredTheFollowingsDataAsFlightSearchCriteria(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            searchFlightPage.SelectFromDate(data.FromOffSet);
            Thread.Sleep(2 * 1000);
            searchFlightPage.SelectToDate(data.ToOffSet);

            searchFlightPage.SelectPassenger(data.Adult, data.Child, data.Infant);
            Thread.Sleep(2 * 1000);
            searchFlightPage.SelectClass(data.Class);
            Thread.Sleep(2 * 1000);

            searchFlightPage.EnterFrom(data.From);
            Thread.Sleep(2 * 1000);
            searchFlightPage.EnterTo(data.To);
            Thread.Sleep(2 * 1000);
        }

        [Given(@"I update the Flight Search Criteria as '(.*)'")]
        public void GivenIUpdateTheFlightSearchCriteriaAs(string Trip)
        {
            if (Trip.Equals("OneWay")) { searchFlightPage.SelectOneWayTrip(); }
            else if (Trip.Equals("RoundTrip")) { searchFlightPage.SelectRoundTrip(); }
            else if (Trip.Equals("MultiCity")) { searchFlightPage.SelectMultiCityTrip(); }
            else throw new Exception();
        }

        [When(@"I Click '(.*)' button on Flight Search Page")]
        public void WhenIClickButtonOnFlightSearchPage(string element)
        {
            if (element.Equals("SearchButton")) { searchFlightPage.ClickSearchButton(); }
        }

        [When(@"I see Flight Records displayed are valid as followings")]
        public void WhenISeeFlightRecordsDisplayedAreValidAsFollowings(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
        }

        [Then(@"Displayed Flight Records are valid for '(.*)'")]
        public void ThenDisplayedFlightRecordsAreValidFor(string p0)
        {
            Console.WriteLine();
        }
    }
}
