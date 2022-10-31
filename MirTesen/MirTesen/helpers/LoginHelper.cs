using MirTesen.model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager applicationManager) : base(applicationManager) { }

        public void Login(Account account)
        {
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div/div[5]/ul/li[2]/button")).Click();
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
