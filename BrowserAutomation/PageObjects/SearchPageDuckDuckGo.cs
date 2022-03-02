using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BrowserAutomation.PageObjects
{
    public class SearchPageDuckDuckGo
    {
        //Defining instance of IWebDriver
        IWebDriver _driver;

        //Initializing _driver with value of driver
        public SearchPageDuckDuckGo(IWebDriver driver)
        {
            _driver = driver;
        }

        //Defining instance of IWebElement
        IWebElement searchTextBox => _driver.FindElement(By.XPath("//input[@id = \"search_form_input_homepage\"]"));

        //Declaring a method to enter text in search box and perform click event to submit out text search that need to performed
        public void EnterTextInSearchBox(string text)
        {
            searchTextBox.SendKeys(text);

            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
        }
    }
}
