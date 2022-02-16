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
using BrowserAutomation.Utilities;

namespace BrowserAutomation
{
    [TestFixture]
    public class SearchEngineTest : TestInitialize
    {


        public SearchEngineTest() : base("SearchInput")
        {

        }

        [Test, Category("Smoke Test"), Description("")]
        public void T001SearchEngineTest()
        {
            //
            var extent = ExtentReportManager.ExtentReportManager.extent;

            //Initialzing Logging with Information of Test to be conducted
            var test = extent.CreateTest("T001SearchEngineTest").Info("This test performs the input and Output operation on Search Engine with Browser of our Choice (which is passed in the form of JSON)");

            foreach (var input in testData.InputList)
            {
                //Creation of Test Node for Reports
                var step = test.CreateNode(input.stepName);

                //Validating a condition of execute flag if it is passed as Yes Test case will execute
                if (input.execute.ToLower() == "yes")
                {
                    
                    try
                    {

                        //Launching Browser
                        LaunchBrowser(input.Browser);

                        //Providing the Search Engine Input as URL
                        driver.Navigate().GoToUrl(input.URL);

                        //Logging information about what action has been performed
                        step.Log(Status.Info, "Go to Search Engine URL");

                        //Providing Input Text 
                        SearchPage searchPage = new SearchPage(driver);
                        searchPage.EnterTextInSearchBox(input.SearchText);


                        //Logging information about what action has been performed
                        step.Log(Status.Info, "Provided input of text to be Searched");

                        ResultPage resultPage = new ResultPage(driver);

                        //Performing a wait in order to get result output
                        resultPage.waitForRelevantTestResults(input.SearchResult);

                        /* --- As suggested commenting out the code of if else condition validation and using Assert in place of it ----
                        if (resultPage.GetRelevantSearchResultCount(input.SearchResult) > 0)
                            step.Pass("Results found");
                        else
                            step.Fail("Result not found");
                        */


                        //Validating The Expected Result if positive returning "Result matched" else returnig "Result not Found"
                        Assert.IsTrue(resultPage.GetRelevantSearchResult(input.SearchResult) > 0, "Result Not Found");
                        step.Pass("Result Found");
                        
                        
                    }
                    catch (Exception er)
                    {
                        //In case of exception Logging the Step Fail with an error message caught an exception
                        step.Fail(er.Message);
                    }
                    finally
                    {
                        //Closing the instance of driver
                        driver.Close();
                    }
                }

                //If the execute flag value is other then Yes else block will be executed and it will display the value as test case skipped in reports
                else
                {
                    step.Skip("Skipped by Test Suite");
                }
            }
        }
    }
}

