using MirTesen.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager applicationManager) : base(applicationManager) { }

        public bool IsLoggedIn()
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id=\"header-profile-tooltip\"]"));
                return true;
            }
            catch { return false; }
        }

        public bool IsLoggedIn(string userEmail)
        {
            Thread.Sleep(2000);
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='header-profile-tooltip']")));
            Thread.Sleep(2000);
            new Actions(driver).MoveToElement(element).Perform();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Моя страница")).Click();

            var createdEmail = driver.FindElement(By.XPath("//*[@id=\"right-column\"]/div[1]/ul[2]/li")).Text;
            return createdEmail == userEmail;
        }

        public void Logout()
        {
            if (!IsLoggedIn()) { return; }
            Thread.Sleep(2000);
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='header-profile-tooltip']")));
            Thread.Sleep(2000);
            new Actions(driver).MoveToElement(element).Perform();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Выход")).Click();
        }

        public void Login(Account account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account.Email))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.XPath("//header[@id='header']/div/div/div/div/div[4]/ul/li[2]/button")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Запросить бесплатный звонок'])[1]/following::button[1]")).Click();
            driver.FindElement(By.Id("authFormLoginByEmailEmail")).Click();
            driver.FindElement(By.Id("authFormLoginByEmailEmail")).Clear();
            driver.FindElement(By.Id("authFormLoginByEmailEmail")).SendKeys(account.Email);
            driver.FindElement(By.Id("authFormLoginByEmailPassword")).Click();
            driver.FindElement(By.Id("authFormLoginByEmailPassword")).Clear();
            driver.FindElement(By.Id("authFormLoginByEmailPassword")).SendKeys(account.Password);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Пароль'])[1]/following::button[1]")).Click();
        }
    }
}
