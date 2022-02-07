using System;
namespace BrowserAutomation.Entities
{
    public class Input
    {
        public Input()
        {
        }

        //Declaring the Input parameters

        //Declaring a execute Flag for execution if it is Yes it will execute otherwise it will not
        public string execute { get; set; }

        //Declaring stepName that we will be using as a Node Creation for our test result reports
        public string stepName { get; set; }

        //Declaring Browser parameter to pass browser as an input in which operation need to be performed
        public string Browser { get; set; }

        //Declaring URL parameter to pass search engine URL in which search need to performed
        public string URL { get; set; }

        //Declaring SearchText parameter to pass input text that need to searched on the selected search engine
        public string SearchText { get; set; }

        //Declaring SearchResult parameter to pass the expected search as a result of input text provided
        public string SearchResult { get; set; }

        public string screenshotFOlderPath { get; set; }


    }
}
