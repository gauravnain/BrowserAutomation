using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Firefox;
using System.IO;
using Newtonsoft.Json;
using BrowserAutomation.Entities;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace BrowserAutomation.PageObjects
{
    public class SearchPage
    {

        public static ExtentTest test;
        IWebDriver _driver;
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        string searchTextBox_XPath = "//input[(contains(@aria-label,'search') or contains(@aria-label,'Search') or contains(@title,'search')) and (@type='text' or @type='search')]";
        IWebElement searchTextBox => _driver.FindElement(By.XPath(searchTextBox_XPath));
        public void EnterTextInSearchBox(string text)
        {
            searchTextBox.SendKeys(text);

            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
        }

        public void waitForRelevantTestResults(string resultText, int timeOut, int maxTries)
        {
            for(int i =  0; i < maxTries; i++)
            {
                if (GetRelevantSearchResultCount(resultText) > 0)
                    break;
                else
                    Thread.Sleep(timeOut);
            }
        }

        public int GetRelevantSearchResultCount(string resultText)
        {
            return _driver.FindElements(By.XPath("//*[contains(.,'" + resultText + "')]")).Count;
        }


    }
}
