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

namespace BrowserAutomation
{
    public class TestInitialize
    {
        //Declaring Global Variables
        public IWebDriver driver;
        public static ExtentTest test;
        public static ExtentReports extent;

        //Initializing testData a null value
        public Input testData = null;


        public TestInitialize(string jsonName)
        {

            //Defining the Path for Input JSON File and reading the Json Data and assigning to String variable

            string executingPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            string testDataPath = Path.Combine(executingPath, "TestData", jsonName + ".json");
            
            StreamReader streamReader = new StreamReader(testDataPath);
            string readData = streamReader.ReadToEnd();

            //Deserializing the read Data
            testData = JsonConvert.DeserializeObject<Input>(readData);

            //Providing a Switch condition for Browser which has been provided as input in JSON
            switch (testData.Browser.ToLower())
            {
                case "chrome":
                    {
                        //Initializing the Browser Driver
                        driver = new ChromeDriver();

                        //Maximizing the Browser Window
                        driver.Manage().Window.Maximize();
                        break;
                    }
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



    }
}
