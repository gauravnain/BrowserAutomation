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

        public Inputs GetTestData(string jsonPath)
        {
            PathHelper pathHelper = new PathHelper();
            
            string testDataPath = Path.Combine(pathHelper.GetExcutingProjectPath, "TestData", "SearchInput" + ".json");

            StreamReader streamReader = new StreamReader(testDataPath);
            string readData = streamReader.ReadToEnd();

            //Deserializing the read Data
            return JsonConvert.DeserializeObject<Inputs>(readData);
        }
    }
}
