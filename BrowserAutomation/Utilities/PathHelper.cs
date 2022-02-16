using System;
using System.IO;

namespace BrowserAutomation.Utilities
{
    public class PathHelper
    {
        public PathHelper()
        {
        }

        //Assigning the path of a json to a string variable
        public string GetExcutingProjectPath => Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
        
    }
}
