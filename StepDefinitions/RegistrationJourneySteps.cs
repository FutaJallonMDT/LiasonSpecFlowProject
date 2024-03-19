using LiasonSpecFlowProject.Drivers;
using LiasonSpecFlowProject.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace LiasonSpecFlowProject.StepDefinitions
{
    [Binding]
    public class RegistrationJourneySteps
    {
        DriverHelper _driverHelpers;
        LiasonHpage lhpage;
        SearchResultPage resultPage;
        Liasontrackdayeventpage LtrackPage;
        RegisterInterestPage RegInterestPage;
        public RegistrationJourneySteps(DriverHelper driverHelpers)
        {
            _driverHelpers = driverHelpers;
            lhpage = new LiasonHpage(driverHelpers);
            resultPage = new SearchResultPage(driverHelpers);
            LtrackPage = new Liasontrackdayeventpage(driverHelpers);
            RegInterestPage = new RegisterInterestPage(driverHelpers);

        }

        [Given(@"User is on Liaisongroup page")]
        public async Task GivenUserIsOnLiaisongroupPage()
        {
            await Task.Delay(100);
            string confirmedUrl =  _driverHelpers.page.Url;
            Assert.True(confirmedUrl.Contains("liaisongroup"));   
        }

        [Given(@"I Click on ABOUT US Button")]
        public async Task GivenIClickOnABOUTUSButton()
        {     
            await lhpage.ClickAboutUs(); 
        }

        [Then(@"I Navigate to Search Result for About Us Page")]
        public async Task ThenINavigateToSearchResultForAboutUsPage()
        {
            await _driverHelpers.page.Locator("//h1").WaitForAsync();
            var errmsg = await _driverHelpers.page.Locator("//h1").IsVisibleAsync();
            Assert.True(errmsg);
        }

        [Then(@"User Enter INSIGHTS in the Search Tab")]
        public async Task ThenUserEnterInsightsInTheSearchTab()
        {
            await resultPage.SearchText();
        }

        [Then(@"Click on Submit Button")]
        public async Task ThenClickOnSubmitButton()
        {
           await resultPage.ClickSubmitBtnForm();
        }

        [Then(@"Search Results Page is Displayed")]
        public async Task ThenSearchResultsPageIsDisplayed()
        {
            await resultPage.IsAboutUsResultOutputDisplayed();
            Assert.That(resultPage.IsAboutUsResultOutputDisplayed(), Is.EqualTo(true), "Not Displayed");
            
        }

        [Given(@"I Click on Register Button")]
        public async Task GivenIClickOnRegisterButton()
        {
            await lhpage.ClickRegister();
        }

        [Then(@"I Navigate to Liaison Group and HFMA Electric Car Track Day Page")]
        public async Task ThenINavigateToLiaisonGroupAndHFMAElectricCarTrackDayPage()
        {
            var re = await RegInterestPage.IsRegInterestOutputDisplayed();
            Assert.That(await RegInterestPage.IsRegInterestOutputDisplayed(), Is.EqualTo(true), "Not Displayed");
            
            
        }

        [Then(@"I should Click on MORE DETAILS Button")]
        [When(@"I should Click on MORE DETAILS Button")]
        public async Task ThenIShouldClickOnMOREDETAILSButton()
        {
           await LtrackPage.ClickMoreDetailsBtn();
        }

        [Then(@"I Naviagate to Liaison Group and HFMA Electric Car Track Day and Register your interest Page")]
        public async Task ThenINaviagateToLiaisonGroupAndHFMAElectricCarTrackDayAndRegisterYourInterestPage()
        {
            await Task.Delay(100);
            var re = await RegInterestPage.IsRegInterestOutputDisplayed();
            Assert.That(await RegInterestPage.IsRegInterestOutputDisplayed(), Is.EqualTo(true), "Not Displayed");
        }

        [Then(@"User Register interest to attend this event with Data and Submit")]
        public async Task ThenUserRegisterInterestToAttendThisEventWithData()
        {
            await RegInterestPage.FillRegistrationDetails("Jasolo", "Kings", "abc@abc.com", "Engineer", "PerfectlyMade");
        }

        [Then(@"Thank you for your submission\.is Displayed")]
        public async Task ThenThankYouForYourSubmission_IsDisplayed()
        {
            await Task.Delay(100);
            var msg = await RegInterestPage.IsFeedBackMessageDisplayed();
            Assert.That(await RegInterestPage.IsFeedBackMessageDisplayed(), Is.EqualTo(true), "Not Displayed");
        }

        [Given(@"I Click On integrated care systems Dropdown")]
        public async Task GivenIClickOnIntegratedCareSystemsDropdown()
        {
            await lhpage.ClickICSdrpDwn();
        }

        [Given(@"I Click on ICS Regions")]
        public async Task GivenIClickOnICSRegions()
        {
           await lhpage.ClickICSRegion();   
        }

        [Then(@"I ensure ICS Regions Page is Displayed")]
        public async Task ThenIEnsureICSRegionsPageIsDisplayed()
        {
            var ic = await lhpage.IsICSRegionDisplayed();
            Assert.That(await lhpage.IsICSRegionDisplayed(), Is.EqualTo(true), "Not Displayed");
        }


    }
}
