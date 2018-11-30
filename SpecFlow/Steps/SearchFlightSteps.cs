using Microsoft.VisualBasic.Devices;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Classes;
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

        [Then(@"I See the '(.*)' search page")]
        public void ThenISeeTheSearchPage(string page)
        {
            if (page.Contains("Flight")) { Assert.IsTrue(searchFlightPage.checkPageTitleContains(page), "correct page : " + page + "displayed."); }
        }

        [Given(@"I entered the followings data as Flight Search Criteria")]
        public void GivenIEnteredTheFollowingsDataAsFlightSearchCriteria(Table table)
        {
            FlightSearch flightSearch = table.CreateInstance<FlightSearch>();

            searchFlightPage.EnterFrom(flightSearch.From);
            Thread.Sleep(2 * 1000);
            searchFlightPage.EnterTo(flightSearch.To);
            Thread.Sleep(2 * 1000);
            searchFlightPage.SelectFromDate(flightSearch.FromOffSet);
            Thread.Sleep(2 * 1000);
            //searchFlightPage.SelectToDate(flightSearch.ToOffSet);

            searchFlightPage.SelectPassenger(flightSearch.Adult, flightSearch.Child, flightSearch.Infant);
            Thread.Sleep(2 * 1000);
            searchFlightPage.SelectClass(flightSearch.Class);
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
            Console.WriteLine();
        }

        [Then(@"Displayed Flight Records are valid for '(.*)'")]
        public void ThenDisplayedFlightRecordsAreValidFor(string p0)
        {
            Console.WriteLine();
        }

    }

}
