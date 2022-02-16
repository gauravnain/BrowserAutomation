using System;
using System.IO;
using BrowserAutomation.Entities;
using Newtonsoft.Json;

namespace BrowserAutomation.Utilities
{
    public class InputJsonReader
    {
        public InputJsonReader()
        {
        }

        //Defining method to get test data from json
        public Inputs GetTestData(string jsonPath)
        {
            //Instantiating the object of pathHelper class
            PathHelper pathHelper = new PathHelper();
            
            //Combining the actual path of json to a string variable using pathHelper object instance
            string testDataPath = Path.Combine(pathHelper.GetExcutingProjectPath, "TestData", "SearchInput" + ".json");

            //Creating an instance of StreamReader
            StreamReader streamReader = new StreamReader(testDataPath);
            string readData = streamReader.ReadToEnd();

            //Deserializing the read Data
            return JsonConvert.DeserializeObject<Inputs>(readData);
        }
    }
}
