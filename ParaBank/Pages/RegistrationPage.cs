using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
//using TechTalk.SpecFlow;

namespace ParaBank.Pages
{
    public class RegistrationPage : BasePage
    {
        public override string PagePath => "https://parabank.parasoft.com/parabank/index.htm";
        public override IPage _page { get; set; }
        public override IBrowser _browser { get; }

        public RegistrationPage(IBrowser browser, IPage page)
        {
            _browser = browser;
            _page = page;
        }

        private string FirstNameField => "//input[#'customer.firstName']";
        private string LastNameField => "//input[#'customer.lastName']";
        private string AddressField => "//input[#'customer.address.street']";
        private string CityField => "//input[#'customer.address.city']";
        private string StateField => "//input[#'customer.address.state']";
        private string ZipCodeField => "//input[#'customer.address.zipCode']";
        private string PhoneNumberField => "//input[#'customer.phoneNumber']";
        private string SSNField => "//input[#'customer.ssn']";
        private string UsernameField => "//input[#'customer.username']";
        private string PasswordField => "//input[#'customer.password']";
        private string ConfirmField => "//input[#'repeatedPassword']";
        private string RegisterButton => ".form2 .button";
        private string LoginTitle => "div#rightPanel > .title";
        private string LogoutLink => "//a[@href='/parabank/logout.htm']";

        
        public async Task FillRegisterForm(string userName, string password)
        {
            var rand = new Random();
            await _page.FillAsync(FirstNameField, $"AutomatedName{rand.Next()}");
            await _page.FillAsync(LastNameField, $"AutomatedLastname{rand.Next()}");
            await _page.FillAsync(CityField, $"City{rand.Next()}");
            await _page.FillAsync(StateField, $"State{rand.Next()}");
            await _page.FillAsync(ZipCodeField, "1234");
            await _page.FillAsync(PhoneNumberField, "123456789");
            await _page.FillAsync(SSNField, "12345");
            await _page.FillAsync(UsernameField, userName);
            await _page.FillAsync(PasswordField, password);
            await _page.FillAsync(ConfirmField, password);
            await _page.ClickAsync(RegisterButton);
        }

        public async Task AssertSuccessfulRegistration(string userName)
        {
            var titleText = await _page.InnerTextAsync(LoginTitle);
            titleText.Should().Be($"Welcome {userName}");;
        }

        public async Task AssertUserIsLoggedIn()
        {
            await _page.WaitForSelectorAsync(LogoutLink);
        }

        public async Task NavigateToRegistrationPage()
        {
            await _page.GotoAsync("https://parabank.parasoft.com/parabank/register.htm");
        }
    }
}
