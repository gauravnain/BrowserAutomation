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
    public class GoogleSearchEngineTest : TestInitialize
    {


        public GoogleSearchEngineTest() : base("SearchInput")
        {

        }

        [Test, Category("Smoke Test"), Description("")]
        public void T001GoogleSearchEngineTest()
        {
            var extent = ExtentReportManager.ExtentReportManager.extent;
            //Initialzing Logging with Information of Test to be conducted
            var test = extent.CreateTest("T001GoogleSearchEngineTest").Info("This test performs the input and Output operation on Google Search Engine with Browser of our Choice (which is passed in the form of JSON");

            foreach (var input in testData.InputList)
            {

                var step = test.CreateNode(input.stepName);

                try
                {
                    LaunchBrowser(input.Browser);
                    //Providing the Search Engine Input as URL
                    driver.Navigate().GoToUrl(input.URL);
                    step.Log(Status.Info, "Go to Search Engine URL");

                    //Providing Input Text 
                    SearchPage homePage = new SearchPage(driver);
                    homePage.EnterTextInSearchBox(input.SearchText);
                    step.Log(Status.Info, "Provided input of text to be Searched");

                    homePage.waitForRelavantTestResults(input.SearchResult, 100, 50);

                    //Validating The Expected Result if positive returning "Result matched" else returnig "Result did not match"
                    if (homePage.GetRelevantSearchResultCount(input.SearchResult) > 0)
                        step.Pass("Results found");
                    else
                        step.Fail("Result not found");
                }
                catch(Exception er)
                {
                    step.Fail(er.Message);
                }
                finally
                {
                    driver.Close();
                }
            }
        }
    }
}

