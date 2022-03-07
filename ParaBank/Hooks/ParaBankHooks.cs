using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using BoDi;
using ParaBank.Pages;

namespace ParaBank.Hooks
{
    [Binding]
    public static class ParaBankHooks
    {
        private static IObjectContainer _objectContainer;
        private static IPlaywright _playwright;
        private static IBrowser _browser;

        [BeforeTestRun(Order = 1)]
        public static void BeforeTestRun(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            StartBrowserAsync().Wait();
        }


        private static async Task StartBrowserAsync()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            _objectContainer.RegisterInstanceAs(_playwright);
            _objectContainer.RegisterInstanceAs(_browser);
            var _page = new ParaBankPage(_browser);
            _objectContainer.RegisterInstanceAs(_page);
        }


        [AfterTestRun]
        public static async Task DisposePlaywright()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
