using LiasonSpecFlowProject.Drivers;
using LiasonSpecFlowProject.Support;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiasonSpecFlowProject.Hooks
{
    [Binding]
    public sealed class BaseHooks
    {
        DriverHelper _driverHelpers;
        public BaseHooks(DriverHelper driverHelper)
        {
            _driverHelpers = driverHelper;
        }

        [BeforeScenario]
        public async Task BeforeScenarioWithTag()
        {
            _driverHelpers.playwright = Playwright.CreateAsync().Result;
            _driverHelpers.browser = await _driverHelpers.playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
                Channel = "chrome"
            });
            _driverHelpers.page = _driverHelpers.browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize
                {
                    Height = 1080,
                    Width = 1920
                }
            }).Result;
            await _driverHelpers.page.GotoAsync(Env.Url);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await _driverHelpers.page.CloseAsync();
           
        }

    }
}
