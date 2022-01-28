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
            string DateTimestamp = DateTime.Now.ToString("dd_MMyyyy_HH_mm_ss");
            string executingPath = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            string reportpath = Path.Combine(executingPath, "Report", DateTimestamp);
            Directory.CreateDirectory(reportpath);

            string htmlReporterPath = Path.Combine(reportpath, "extent.html");
            var htmlreporter = new ExtentHtmlReporter(htmlReporterPath);
            extent.AttachReporter(htmlreporter);
        }

        public void Flush()
        {
            extent.Flush();
        }

    }
}
