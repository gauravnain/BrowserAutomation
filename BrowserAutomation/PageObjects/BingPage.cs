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
    public class BingPage
    {

        public static ExtentTest test;
        IWebDriver _driver;
        public BingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterTextInBingSearchBox(string text)
        {
            _driver.FindElement(By.XPath("//input[@id='sb_form_q']")).SendKeys(text);
        }

    }
}