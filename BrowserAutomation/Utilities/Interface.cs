using System;
namespace BrowserAutomation.Utilities
{
    public interface inputPageNavigation
    {
        public void navigateToSearchPage(String URL, String InputText);
    }

    public interface resultPageNavigation
    {
        public void navigateToResultPage(String URL, String ResultText);
    }
}
