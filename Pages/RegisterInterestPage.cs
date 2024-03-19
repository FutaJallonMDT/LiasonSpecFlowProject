using LiasonSpecFlowProject.Drivers;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiasonSpecFlowProject.Pages
{
    public class RegisterInterestPage
    {
        DriverHelper _driverHelpers;
        public RegisterInterestPage(DriverHelper driverHelper)
        {
             _driverHelpers = driverHelper;
        }

        ILocator FName => _driverHelpers.page.GetByLabel("First Name");
        ILocator LName => _driverHelpers.page.GetByText("Last Name");
        ILocator Email => _driverHelpers.page.GetByLabel("E-mail");
        ILocator JobTitle => _driverHelpers.page.GetByLabel("Job Title*");
        ILocator CoyName => _driverHelpers.page.GetByText("Company Name*");
        ILocator SubmitBtn => _driverHelpers.page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
        ILocator FeedBackMessage => _driverHelpers.page.Locator("//div[@class='onFormSubmittedFeedbackMessage']");
        ILocator RegInterestOutput => _driverHelpers.page.Locator("//h1");


        public async Task<bool> IsFeedBackMessageDisplayed()
        {
            await FeedBackMessage.WaitForAsync();
            return await FeedBackMessage.IsVisibleAsync();
        }
        
        public async Task<bool> IsRegInterestOutputDisplayed()
        {
            await RegInterestOutput.WaitForAsync();
            return await RegInterestOutput.IsVisibleAsync();
        }

        public async Task FillRegistrationDetails(string fn,string ln, string email, string jobtitle,string comname)
        {
            await FName.FillAsync(fn);
            await LName.FillAsync(ln);
            await Email.FillAsync(email);
            await JobTitle.FillAsync(jobtitle);
            await CoyName.FillAsync(comname);
            await SubmitBtn.ClickAsync();
        }

    }
}
