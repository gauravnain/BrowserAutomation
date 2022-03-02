using System;
using BrowserAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BrowserAutomation.Utilities
{
    public class NavigatingResultPage : resultPageNavigation
    {
        IWebDriver _driver;

        public NavigatingResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void navigateToResultPage(string URL, string ResultText)
        {
            switch(URL.ToLower())
            {
                case "http://www.google.com":
                    {
                        ResultPage resultPage = new ResultPage(_driver);
                        resultPage.waitForRelevantTestResults(ResultText);
                        Assert.IsTrue(resultPage.GetRelevantSearchResult(ResultText) > 0, "Result Not Found");
                        break;
                    }
                case "http://www.duckduckgo.com":
                    {
                        ResultPageDuckDuckGo resultPage = new ResultPageDuckDuckGo(_driver);
                        resultPage.waitForRelevantTestResults(ResultText);
                        Assert.IsTrue(resultPage.GetRelevantSearchResult(ResultText) > 0, "Result Not Found");
                        break;
                    }
            }
        }
    }
}
