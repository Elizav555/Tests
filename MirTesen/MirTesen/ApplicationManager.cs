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
        private AccountHelper account;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        private ApplicationManager()
        {
            driver = new ChromeDriver(@"D:\Tests\");
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();

            driver.Manage().Window.Maximize();

            site = new SiteHelper(this);
            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
            account = new AccountHelper(this);
        }

        ~ApplicationManager()
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

        public AccountHelper Account
        {
            get
            {
                return account;
            }
        }
    }
}
