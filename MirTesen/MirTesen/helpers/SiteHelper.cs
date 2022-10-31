using MirTesen.model;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;

namespace MirTesen.helpers
{
    public class SiteHelper:HelperBase
    {

        public SiteHelper(ApplicationManager applicationManager) : base(applicationManager) { }

        public void AddSite(Site site)
        {
            Thread.Sleep(2000);
            var element = new WebDriverWait(driver, TimeSpan.FromSeconds(5000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='header-profile-tooltip']")));
            Thread.Sleep(2000);
            new Actions(driver).MoveToElement(element).Perform();
            Thread.Sleep(2000);
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
            Thread.Sleep(5000);
            var button = new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Создать сайт']")));
            driver.ExecuteJavaScript("arguments[0].click()", button);
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl(site.Address);
        }
    }
}
