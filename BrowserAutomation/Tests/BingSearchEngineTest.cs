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
using BrowserAutomation.PageObjects;
using System.Threading;

namespace BrowserAutomation
{
    [TestFixture]
    public class BingSearchEngineTest : TestInitialize
    {

        public BingSearchEngineTest() : base("BingInput")
        {

        }

        [OneTimeSetUp, Description("")]
        public void ExtentStart()
        {
            //Generating the report for Test Execution
            extent = new ExtentReports();
            string DateTimestamp = DateTime.Now.ToString("dd_MMyyyy_HH_mm_ss");
            string executingPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            string reportpath = Path.Combine(executingPath, "Report", DateTimestamp);
            Directory.CreateDirectory(reportpath);

            string htmlReporterPath = Path.Combine(reportpath, "extent.html");
            var htmlreporter = new ExtentHtmlReporter(htmlReporterPath);
            extent.AttachReporter(htmlreporter);
        }

        [Test, Description("")]
        public void T001BingSearchEngineTest()
        {
            //Assigning the Logger Varaible as Null Value
            test = null;

            //Initialzing Logging with Information of Test to be conducted
            test = extent.CreateTest("T001BingSearchEngineTest").Info("This test performs the input and Output operation on Google Search Engine with Browser of our Choice (which is passed in the form of JSON");

            //Providing the Search Engine Input as URL
            driver.Navigate().GoToUrl(testData.URL);
            test.Log(Status.Info, "Go to Search Engine URL");

            //Providing Input Text 
            BingPage homePage = new BingPage(driver);
            homePage.EnterTextInBingSearchBox(testData.SearchText);
            test.Log(Status.Info, "Provided input of text to be Searched");

            //Performing Enter Operation to Search the Result
            driver.FindElement(By.XPath("//label[@id='search_icon']")).Click();
            test.Log(Status.Info, "Provided EnterKey as an Input to search the result");

            Thread.Sleep(2000);

            //Searching the result output as a means of input text provided and validating if the condition has passed or failed
            string searchResultText = driver.FindElement(By.XPath("//ol[@id='b_results']/li[2]//h2/a")).Text;
            test.Log(Status.Info, "Searched the output text");

            //Validating The Expected Result if positive returning "Result matched" else returnig "Result did not match"
            if (searchResultText.Contains("Fiserv: Financial Services Technology, Mobile Banking, ..."))
                test.Pass("Result matched");
            else
                test.Fail("Result did not match");

        }


        [TearDown]
        public void CleanUp()
        {
            //Closing the Browser
            driver.Close();
            extent.Flush();
        }
    }
}

