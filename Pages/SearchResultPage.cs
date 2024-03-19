using LiasonSpecFlowProject.Drivers;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiasonSpecFlowProject.Pages
{
    
    public class SearchResultPage
    {
        DriverHelper _driverHelpers;
        public SearchResultPage(DriverHelper driverHelper)
        {
            _driverHelpers = driverHelper;
        }
        ILocator EnterTextMsg => _driverHelpers.page.GetByRole(AriaRole.Textbox, new() { Name = "Search" });
        ILocator SubmitBtnForm => _driverHelpers.page.Locator("#submitForm").GetByRole(AriaRole.Button);
        ILocator AboutUsOutput => _driverHelpers.page.Locator("//h1['Search results for About us']");
        ILocator AboutUsResultOutput => _driverHelpers.page.Locator("//h1");

        public async Task IsAboutUsResultOutputDisplayed() => await AboutUsOutput.IsVisibleAsync();
        public async Task IsAboutUsOutputDisplayed() => await AboutUsResultOutput.IsVisibleAsync();
        public async Task SearchText() => await EnterTextMsg.FillAsync("INSIGHTS");
        public async Task ClickSubmitBtnForm() => await SubmitBtnForm.ClickAsync();
     
    }
}
