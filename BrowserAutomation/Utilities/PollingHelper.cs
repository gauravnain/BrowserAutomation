using System;
using System.Threading;

namespace BrowserAutomation.Utilities
{
    public class PollingHelper
    {
        public PollingHelper()
        {
        }

        public static void Poller(Func<bool> action, int timeOut, int maxTries)
        {
            for (int i = 0; i < maxTries; i++)
            {
                if (action())
                    break;
                else
                    Thread.Sleep(timeOut);
            }
        }

    }
}
