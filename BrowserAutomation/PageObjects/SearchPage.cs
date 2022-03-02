﻿using System;
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
using BrowserAutomation.Utilities;

namespace BrowserAutomation.PageObjects
{
    public class SearchPage
    {
        //Defining instance of IWebDriver
        IWebDriver _driver;

        //Initializing _driver with value of driver
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //Defining a generic XPath for search text box on different search engine like Google and Bing
        string searchTextBox_XPath = "//input[contains(@aria-label,'Search') and @type='text']";

        //Defining instance of IWebElement
        IWebElement searchTextBox => _driver.FindElement(By.XPath(searchTextBox_XPath));

        //Declaring a method to enter text in search box and perform click event to submit out text search that need to performed
        public void EnterTextInSearchBox(string text)
        {
            searchTextBox.SendKeys(text);

            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
        }

        
    }
}
