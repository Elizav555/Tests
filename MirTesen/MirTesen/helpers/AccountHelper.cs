using MirTesen.model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.helpers
{
    public class AccountHelper : HelperBase
    {
        public AccountHelper(ApplicationManager applicationManager) : base(applicationManager) { }

        public string GetEmail()
        {
            string login = driver.FindElement(By.XPath("//*[@id=\"right-column\"]/div[1]/ul[2]/li")).Text;
            return login;
        }
    }
}
