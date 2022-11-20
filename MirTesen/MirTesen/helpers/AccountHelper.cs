using MirTesen.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
            string email = driver.FindElement(By.XPath("//*[@id=\"right-column\"]/div[1]/ul[2]/li")).Text;
            return email;
        }

        public string GetProfileId()
        {
            Thread.Sleep(2000);
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='header-profile-tooltip']")));
            Thread.Sleep(2000);
            new Actions(driver).MoveToElement(element).Perform();
            Thread.Sleep(2000);
            return driver.FindElement(By.LinkText("Моя страница")).GetAttribute("href").Split('/').Last();
        }
    }
}
