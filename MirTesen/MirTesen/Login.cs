using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace MirTesen
{
    [TestFixture]
    public class AuthTestCase
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

        [Test]
        public void TheLoginTest()
        {

            driver.Navigate().GoToUrl("https://mirtesen.ru/");
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div/div[5]/ul/li[2]/button")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Запросить бесплатный звонок'])[1]/following::button[1]")).Click();
            driver.FindElement(By.Id("authFormLoginByEmailEmail")).Click();
            driver.FindElement(By.Id("authFormLoginByEmailEmail")).Clear();
            driver.FindElement(By.Id("authFormLoginByEmailEmail")).SendKeys("lizagarkina5@gmail.com");
            driver.FindElement(By.Id("authFormLoginByEmailPassword")).Click();
            driver.FindElement(By.Id("authFormLoginByEmailPassword")).Clear();
            driver.FindElement(By.Id("authFormLoginByEmailPassword")).SendKeys("5dH0bd9d72");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Пароль'])[1]/following::button[1]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

