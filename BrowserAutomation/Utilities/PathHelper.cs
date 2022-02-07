using System;
using System.IO;

namespace BrowserAutomation.Utilities
{
    public class PathHelper
    {
        public PathHelper()
        {
        }

        public string GetExcutingProjectPath => Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
        
    }
}
