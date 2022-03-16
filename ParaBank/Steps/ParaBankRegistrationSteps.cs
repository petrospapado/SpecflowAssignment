using System;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using ParaBank.Pages;
using System.Threading.Tasks;

namespace ParaBank.Steps
{
    [Binding]
    public class ParaBankregistrationSteps
    {
        private readonly ParaBankPage _page;
        private readonly ScenarioContext _scenarioContext;
        private readonly RegistrationPage _registrationPage;

        public ParaBankregistrationSteps(ParaBankPage page, ScenarioContext scenarioContext, RegistrationPage registrationPage)
        {
            _page = page;
            _scenarioContext = scenarioContext;
            _registrationPage = registrationPage;
        }


        [When(@"user successfully registers to ParaBank with (.*) and (.*)")]
        public async Task WhenUserRegistersToParaBankWithAnd(string username, string password)
        {
            await _registrationPage.FillRegisterForm(username, password);
        }

        [Then(@"user should see welcome message of (.*)")]
        public async Task ThenUserShouldSeeWelcomeMessageOf(string username)
        {
            await _registrationPage.AssertSuccessfulRegistration(username);
        }

        [Given(@"the user is on ParaBank registration page")]
        public async Task  GivenTheUserIsOnParaBankRegistrationPage()
        {
            await _registrationPage.NavigateToRegistrationPage();
        }
    }
}
