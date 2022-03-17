using System;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using ParaBank.Pages;
using System.Threading.Tasks;

namespace ParaBank.Steps
{
    [Binding]
    public class ParaBankRegistrationSteps
    {
        private readonly RegistrationPage _registrationPage;

        public ParaBankRegistrationSteps(RegistrationPage registrationPage)
        {
            _registrationPage = registrationPage;
        }
        
        
        [When(@"user successfully registers to ParaBank with (.*) and (.*) (.*)")]
        public async Task WhenUserRegistersToParaBankWithAnd(string username, string password, string confirmPassword)
        {
            await _registrationPage.FillRegisterForm(username, password, confirmPassword);
        }

        [Then(@"user should see welcome message of (.*)")]
        public async Task ThenUserShouldSeeWelcomeMessageOf(string username)
        {
            await _registrationPage.AssertSuccessfulRegistration(username);
        }

        [Given(@"the user is on ParaBank registration page")]
        public async Task  GivenTheUserIsOnParaBankRegistrationPage()
        {
            await _registrationPage.NavigateAsync();
            // await _registrationPage.NavigateToRegistrationPage();
        }

        [When(@"user clicks Register")]
        public async Task WhenUserClicksRegister()
        {
            await _registrationPage.SubmitRegister();
        }

        [When(@"user should get registration error message")]
        [Then(@"user should get registration error message")]
        public async Task WhenUserShouldGetRegistrationErrorMessage()
        {
            await _registrationPage.AssertRegisterFailed();
        }
    }
}
