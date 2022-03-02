using System;
using BrowserAutomation.PageObjects;
using OpenQA.Selenium;

namespace BrowserAutomation.Utilities
{
    public class NavigatingSearchPage : inputPageNavigation
    {
        IWebDriver _driver;


        public NavigatingSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void navigateToSearchPage(string URL, string InputText)
        {
            switch(URL.ToLower())
            {
                case "http://www.google.com":
                    {
                        SearchPage searchPage = new SearchPage(_driver);
                        searchPage.EnterTextInSearchBox(InputText);
                        break;
                    }
                case "http://www.duckduckgo.com":
                    {
                        SearchPageDuckDuckGo searchPage = new SearchPageDuckDuckGo(_driver);
                        searchPage.EnterTextInSearchBox(InputText);
                        break;
                    }
            }
        }
    }
}
