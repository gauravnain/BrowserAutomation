using System;
namespace BrowserAutomation.Entities
{
    public class Input
    {
        public Input()
        {
        }

        //Declaring the Input parameters
        public string stepName { get; set; }
        public string Browser { get; set; }
        public string URL { get; set; }
        public string SearchText { get; set; }

        public string SearchResult { get; set; }
        

    }
}
