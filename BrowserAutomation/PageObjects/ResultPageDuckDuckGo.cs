using System;
using BrowserAutomation.Utilities;
using OpenQA.Selenium;

namespace BrowserAutomation.PageObjects
{
    public class ResultPageDuckDuckGo
    {
        //Creating instance of IWebDriver for output class
        IWebDriver _driver;

        //Initializing _driver with value of driver
        public ResultPageDuckDuckGo(IWebDriver driver)
        {
            _driver = driver;
        }

        //Calling PollingHelper class's poller method to perform wait in order to get output result
        public void waitForRelevantTestResults(string resultText)
        {
            PollingHelper.Poller(() => GetRelevantSearchResult(resultText) > 0, 100, 50);

        }

        //Declaring a method to search the output result
        public int GetRelevantSearchResult(string resultText)
        {
            return _driver.FindElements(By.XPath("//h2/a[contains(text(),'" + resultText + "')]")).Count;
        }
    }
}
