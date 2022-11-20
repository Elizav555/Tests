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
    public class SiteHelper : HelperBase
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
        }

        public void SelectCreatedSite(string siteAddress)
        {
            driver.Navigate().GoToUrl(siteAddress);
            var button = new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Настройки")));
            driver.ExecuteJavaScript("arguments[0].click()", button);
        }

        public Site GetCreatedSiteData()
        {
            string name = driver.FindElement(By.XPath("//*[@id=\"content-column\"]/div/div[1]/form/div[2]/div[1]/input")).GetAttribute("value");
            string desc = driver.FindElement(By.XPath("//*[@id=\"content-column\"]/div/div[1]/form/div[2]/div[2]/textarea")).GetAttribute("value");
            string keyWords = driver.FindElement(By.XPath("//*[@id=\"content-column\"]/div/div[1]/form/div[2]/div[3]/div/div[1]/button/span")).Text;

            driver.FindElement(By.LinkText("Настроить")).Click();
            string domain = driver.FindElement(By.XPath("//div[@id='content-column']/div/div[11]/form/div/div/ul/li")).Text.Split(".").First();

            return new Site(domain: domain, name: name, description: desc, keyWords: keyWords);
        }

        public void EditSite(Site newSite)
        {
            driver.FindElement(By.Name("name")).Click();
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys(newSite.Name);
            var textArea = new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@name='description']")));
            driver.ExecuteJavaScript("arguments[0].click()", textArea);
            driver.FindElement(By.XPath("//textarea[@name='description']")).Clear();
            driver.FindElement(By.XPath("//textarea[@name='description']")).SendKeys(newSite.Description);
            var button = new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='content-column']/div/div/form/div[3]/div/button")));
            driver.ExecuteJavaScript("arguments[0].click()", button);
        }
    }
}
