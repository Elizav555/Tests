using MirTesen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.helpers
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager applicationManager, string baseURL) : base(applicationManager) 
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("https://mirtesen.ru/");
        }

        public void GoToSitePage(string siteAddress)
        {
            driver.Navigate().GoToUrl(siteAddress);
        }

        public void GoToProfile()
        {
            driver.Navigate().GoToUrl("https://mirtesen.ru/people/587588326");
        }
    }
}
