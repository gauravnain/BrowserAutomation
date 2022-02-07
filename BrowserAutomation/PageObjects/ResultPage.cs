using System;
using BrowserAutomation.Utilities;
using OpenQA.Selenium;

namespace BrowserAutomation.PageObjects
{
    public class ResultPage
    {
        IWebDriver _driver;
        public ResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void waitForRelevantTestResults(string resultText)
        {
            PollingHelper.Poller(() => GetRelevantSearchResultCount(resultText) > 0, 100, 50);

        }

        public int GetRelevantSearchResultCount(string resultText)
        {
            return _driver.FindElements(By.XPath("//*[contains(.,'" + resultText + "')]")).Count;
        }
    }
}
