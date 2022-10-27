using MirTesen.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace MirTesen
{
    [TestFixture]
    public class TestCases:TestBase
    {

        [Test]
        public void TheLoginTest()
        {
            GoToHomePage();
            Login(new Account(Secret.Email,Secret.Password));
        }

        [Test]
        public void TheAddSiteTest()
        {
            GoToHomePage();
            Login(new Account(Secret.Email,Secret.Password));
            AddSite(new Site("elizav5","ElizavV","Wow","Descr","key"));
        }
    }
}

