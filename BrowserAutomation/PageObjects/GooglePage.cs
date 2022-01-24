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
namespace BrowserAutomation.PageObjects
{
    public class GooglePage
    {

        public static ExtentTest test;
        IWebDriver _driver;
        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterTextInGoogleSearchBox(string text)
        {
            _driver.FindElement(By.XPath("//input[@title='Search']")).SendKeys(text);

        }

    }
}
