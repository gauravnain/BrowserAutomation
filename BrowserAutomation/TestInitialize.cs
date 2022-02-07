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
using BrowserAutomation.ExtentReportManager;
using BrowserAutomation.Utilities;

namespace BrowserAutomation
{
    public class TestInitialize : IDisposable
    {
        //Declaring Global Variables
        public IWebDriver driver;

        //Initializing testData a null value
        public Inputs testData = null;

        
        public TestInitialize(string jsonName)
        {

            //Defining the Path for Input JSON File and reading the Json Data and assigning to String variable
            ExtentReportManager.ExtentReportManager.getInstance.ExtentStart();

            InputJsonReader inputJsonReader = new InputJsonReader();
            testData = inputJsonReader.GetTestData(jsonName);
        }

        public void LaunchBrowser(string browserName)
        {
            //Providing a Switch condition for Browser which has been provided as input in JSON
            switch (browserName.ToLower())
            {

                //If the passed Browser input is Chrome
                case "chrome":
                    {
                        //Initializing the Browser Driver
                        driver = new ChromeDriver();

                        //Maximizing the Browser Window
                        driver.Manage().Window.Maximize();
                        break;
                    }

                //If the passed Browser input is Firefox
                case "firefox":
                    {
                        //Initializing the Browser Driver
                        driver = new FirefoxDriver();

                        //Maximizing the Browser Window
                        driver.Manage().Window.Maximize();
                        break;
                    }

            }

        }

        //Creating a Dispose method
        public void Dispose()
        {
            ExtentReportManager.ExtentReportManager.getInstance.Flush();
            if(driver != null)
                driver.Close();
        }

    }
}
