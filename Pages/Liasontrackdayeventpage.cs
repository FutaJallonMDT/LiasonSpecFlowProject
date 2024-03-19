using LiasonSpecFlowProject.Drivers;
using Microsoft.Playwright;


namespace LiasonSpecFlowProject.Pages
{
    public class Liasontrackdayeventpage
    {
        DriverHelper _driverHelpers;
        public Liasontrackdayeventpage(DriverHelper driverHelper)
        {
                _driverHelpers = driverHelper;
        }

        ILocator MoreDetailsBtn => _driverHelpers.page.GetByRole(AriaRole.Link, new() { Name = "More details" });
        ILocator TrackDayOutput => _driverHelpers.page.Locator("//h1");
       

        public async Task IsTrackDayOutputDisplayed() => await TrackDayOutput.IsVisibleAsync();
        

        public async Task ClickMoreDetailsBtn() => await MoreDetailsBtn.ClickAsync();
    }
}
