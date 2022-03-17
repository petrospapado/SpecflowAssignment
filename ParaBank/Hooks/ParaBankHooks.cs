using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using BoDi;
using NUnit.Framework;
using ReportPortal.Client.Abstractions.Requests;
using ReportPortal.SpecFlowPlugin;
using ParaBank.Pages;
using TechTalk.SpecFlow.Infrastructure;

namespace ParaBank.Hooks
{
    [Binding]
    public class ParaBankHooks
    {
        private static IObjectContainer _objectContainer;
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        private static ISpecFlowOutputHelper _specFlowOutputHelper;
        private static ScenarioContext _scenarioContext;
        private static IPage _page;

        public ParaBankHooks(IPlaywright playwright, ISpecFlowOutputHelper specFlowOutputHelper, IBrowser browser, ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _playwright = playwright;
            _specFlowOutputHelper = specFlowOutputHelper;
            _browser = browser;
            _scenarioContext = scenarioContext;
            _objectContainer  = objectContainer;
        }
        
        [BeforeTestRun]
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
        }


        [AfterScenario(Order = 100000)]
        public static async Task DisposePlaywright()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
        
        [AfterScenario(Order = 1)]
        public static async Task SaveScreenshot()
        {
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                var basePath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName ??
                               Path.GetTempPath();

                var fileName = Path.ChangeExtension(Path.GetRandomFileName(), "png");

                var fullPath = Path.Combine(basePath, "TestMetadata", "TestResults", fileName);

                var scBytes = await _page.ScreenshotAsync(new PageScreenshotOptions()
                {
                    Path = fullPath,
                    FullPage = true
                });

                _specFlowOutputHelper.AddAttachment(fileName);
                _specFlowOutputHelper.WriteLine(TestContext.CurrentContext.Result.StackTrace);

                var scenarioTestReporter = ReportPortalAddin.GetScenarioTestReporter(_scenarioContext);
                scenarioTestReporter.Log(
                    new CreateLogItemRequest() { 
                        Text = "my screenshot",
                        Attach = new LogItemAttach { MimeType = "image/png", Data = scBytes, Name = "Name of attachment"}
                        
                    });
            }
        }
    }
}
