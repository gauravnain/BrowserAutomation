using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace BrowserAutomation.ExtentReportManager
{
    public class ExtentReportManager
    {

        public static ExtentTest test;
        public static ExtentReports extent;
        public static string reportpath;
        private static ExtentReportManager _Instance;
        public static ExtentReportManager getInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExtentReportManager();
                }
                return _Instance;
            }
        }


        public void ExtentStart()
        {
            //Generating the report for Test Execution
            extent = new ExtentReports();

            //Taking the Date Time Stamp of the system to a string variable.
            string DateTimestamp = DateTime.Now.ToString("dd_MMyyyy_HH_mm_ss");

            //Fetching the location of executing path to a string varaible.
            string executingPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();

            //Defining the unique reportpath using the above two variables i.e. DateTimeStamp and executingPath
             reportpath = Path.Combine(executingPath, "Report", DateTimestamp);

            //Creating the Unique Directory where the report would be stored
            Directory.CreateDirectory(reportpath);

            //Defining the htmlReporterPath string variable
            string htmlReporterPath = Path.Combine(reportpath, "executionreport.html");

            //Creating an object of a class that we have added as dependent class package
            var htmlreporter = new ExtentHtmlReporter(htmlReporterPath);

            //Attaching the Report
            extent.AttachReporter(htmlreporter);
        }

        //Flush method will clear all buffers of extent and will write any buffered data to the file
        public void Flush()
        {
            extent.Flush();
        }

    }
}
