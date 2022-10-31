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
            app.Navigation.GoToHomePage();
            app.Auth.Login(new Account(Secret.Email, Secret.Password));
        }

        [Test]
        public void TheAddSiteTest()
        {
            app.Navigation.GoToHomePage();
            app.Auth.Login(new Account(Secret.Email,Secret.Password));
            app.Site.AddSite(new Site("5555elizav5555555","Elizavvv","Wow","Descr","key"));
        }
    }
}

