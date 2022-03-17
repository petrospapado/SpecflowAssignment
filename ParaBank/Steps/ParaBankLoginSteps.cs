using System;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using ParaBank.Pages;
using System.Threading.Tasks;

namespace ParaBank.Steps
{
    [Binding]
    public class ParaBankLoginSteps
    {
        private readonly ParaBankLoginPage _loginPage;

        public ParaBankLoginSteps(ParaBankLoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [Given(@"the user is on ParaBank homepage")]
        public async Task GivenTheUserIsOnParaBankHomepage()
        {
            await _loginPage.NavigateAsync();
        }
        
        [Given(@"user types username (.*)")]
        public async Task GivenUserTypesUsername(string username)
        {
            await _loginPage.ParaBankFillUsername(username);
        }
        
        [Given(@"user types password (.*)")]
        public async Task GivenUserTypesPassword(string password)
        {
            await _loginPage.ParaBankFillPassword(password);
        }
        
        [When(@"user clicks Login")]
        [Given(@"user clicks Login")]
        public async Task WhenUserClicksLogin()
        {
            await _loginPage.ParaBankLogin();
        }
        
        [Then(@"user should see the Log Out link")]
        public async Task UserShouldSeeTheLogOutLink()
        {
            await _loginPage.ParaBankWelcome();
        }

        [Then(@"user should get an error message")]
        public async Task ThenUserShouldGetAnErrorMessage()
        {
            await _loginPage.ParaBankError();
        }


    }
}
