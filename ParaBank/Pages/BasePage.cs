using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace ParaBank.Pages
{
    public abstract class BasePage
    {
        public abstract string PagePath { get; }

        public abstract IPage _page { get; set; }

        public abstract IBrowser _browser { get; }

        public async Task NavigateAsync()
        {
            _page = await _browser.NewPageAsync();
            await _page.GotoAsync(PagePath);
        }
    }
}
