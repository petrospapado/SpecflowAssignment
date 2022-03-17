using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
//using TechTalk.SpecFlow;

namespace ParaBank.Pages
{
    public class ParaBankLoginPage : BasePage
    {
        public override string PagePath => "https://parabank.parasoft.com/parabank/index.htm";
        public override IPage _page { get; set; }
        public override IBrowser _browser { get; }

        public ParaBankLoginPage(IBrowser browser)
        {
            _browser = browser;
        }

        private string UsernameField => "[name='username']";
        private string PasswordField => "[name='password']";
        private string LoginButton => "text=Log In";
        private string LogOutLink => "text=Log Out";
        private string ErrorMsg => ".error";

        public async Task ParaBankFillUsername(string username)
        {
            await _page.FillAsync(UsernameField, username);
        }

        public async Task ParaBankFillPassword(string password) 
        {
            await _page.FillAsync(PasswordField, password);
        }

        public async Task ParaBankLogin()
        {
            await _page.ClickAsync(LoginButton);
        }

        public async Task ParaBankWelcome()
        {
            await _page.WaitForSelectorAsync(LogOutLink);
        }

        public async Task ParaBankError()
        {
            await _page.WaitForSelectorAsync(ErrorMsg);
        }
    }
}
