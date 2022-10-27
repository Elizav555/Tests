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

namespace MirTesen
{
    public class TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"D:\Tests\");
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
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

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("https://mirtesen.ru/");
        }

        public void AddSite(Site site)
        {
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='header-profile-tooltip']")));
            new Actions(driver).MoveToElement(element).Perform();
            driver.FindElement(By.LinkText("Создать сайт")).Click();
            driver.Navigate().GoToUrl("https://mirtesen.ru/create/");
            driver.FindElement(By.Name("domain")).Click();
            driver.FindElement(By.Name("domain")).Clear();
            driver.FindElement(By.Name("domain")).SendKeys(site.Domain);
            driver.FindElement(By.XPath("//div[@id='content-column']/div/form/div/div[2]/label")).Click();
            driver.FindElement(By.Name("name")).Click();
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys(site.Name);
            driver.FindElement(By.Name("tagLine")).Click();
            driver.FindElement(By.Name("tagLine")).Clear();
            driver.FindElement(By.Name("tagLine")).SendKeys(site.Tag);
            driver.FindElement(By.XPath("//textarea[@name='description']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='description']")).Clear();
            driver.FindElement(By.XPath("//textarea[@name='description']")).SendKeys(site.Description);
            driver.FindElement(By.XPath("//textarea[@name='keywords']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='keywords']")).Clear();
            driver.FindElement(By.XPath("//textarea[@name='keywords']")).SendKeys(site.KeyWords);
            driver.FindElement(By.XPath("//input[@value='Создать сайт']")).Click();
            driver.Navigate().GoToUrl(site.Address);
        }
    }
}
