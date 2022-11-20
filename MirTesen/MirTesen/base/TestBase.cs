using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.Security.Principal;
using MirTesen.model;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;

namespace MirTesen
{
    public class TestBase
    {
        protected ApplicationManager app;


        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.Navigation.GoToHomePage();
        }
    }
}
