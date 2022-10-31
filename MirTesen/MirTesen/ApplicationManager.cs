using MirTesen.helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private SiteHelper site;

        public ApplicationManager()
        {
            driver = new ChromeDriver(@"D:\Tests\");
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();

            site = new SiteHelper(this);
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return auth;
            }
        }
        public SiteHelper Site
        {
            get
            {
                return site;
            }
        }
    }
}
