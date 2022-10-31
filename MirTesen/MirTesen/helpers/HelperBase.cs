using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.helpers
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected bool acceptNextAlert = true;
        private ApplicationManager applicationManager;

        public HelperBase(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
            this.driver = applicationManager.Driver;
        }
    }
}
