using LiasonSpecFlowProject.Drivers;
using Microsoft.Playwright;


namespace LiasonSpecFlowProject.Pages
{
    public class LiasonHpage
    {
        DriverHelper _driverHelpers;
        public LiasonHpage(DriverHelper driverHelper)
        {
            _driverHelpers = driverHelper;

        }

        ILocator AboutUs => _driverHelpers.page.GetByRole(AriaRole.Link, new() { Name = "About us" }).Nth(2);
        ILocator ICSdrpDwn => _driverHelpers.page.Locator("div:nth-child(2) > .z-10 > .w-4");
        ILocator ICSRegiondisplay => _driverHelpers.page.Locator("(//h2)[4]");
        ILocator Register => _driverHelpers.page.GetByRole(AriaRole.Link, new() { Name = "Register" });
        ILocator ICSRegion => _driverHelpers.page.GetByRole(AriaRole.Link, new() { Name = "ICS Regions" });

        public async Task ClickAboutUs() => await AboutUs.ClickAsync(); 
        public async Task ClickRegister() => await Register.ClickAsync();
        public async Task ClickICSdrpDwn() => await ICSdrpDwn.ClickAsync();
        public async Task ClickICSRegion() => await ICSRegion.ClickAsync();
        public async Task<bool> IsICSRegionDisplayed()
        {
            await ICSRegiondisplay.WaitForAsync();
            return await ICSRegiondisplay.IsVisibleAsync();
        }

    }
}
