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
        private readonly ParaBankPage _page;
        private readonly ScenarioContext _scenarioContext;

        public ParaBankLoginSteps(ParaBankPage page, ScenarioContext scenarioContext)
        {
            _page = page;
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user is on ParaBank homepage")]
        public async Task GivenTheUserIsOnParaBankHomepage()
        {
            await _page.NavigateAsync();
        }
        
        [Given(@"user types username (.*)")]
        public async Task GivenUserTypesUsername(string username)
        {
            await _page.ParaBankFillUsername(username);
        }
        
        [Given(@"user types password (.*)")]
        public async Task GivenUserTypesPassword(string password)
        {
            await _page.ParaBankFillPassword(password);
        }
        
        [When(@"user clicks Login")]
        public async Task WhenUserClicksLogin()
        {
            await _page.ParaBankLogin();
        }
        
        [Then(@"user should see the Log Out link")]
        public async Task henUserShouldSeeTheLogOutLink()
        {
            await _page.ParaBankWelcome();
        }

        [Then(@"user should get an error message")]
        public async Task ThenUserShouldGetAnErrorMessage()
        {
            await _page.ParaBankError();
        }


    }
}
