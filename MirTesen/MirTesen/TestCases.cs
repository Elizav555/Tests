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
        public void ATheLoginTest()
        {
            var account = new Account(Secret.Email, Secret.Password);
            app.Navigation.GoToHomePage();
            app.Auth.Login(account);
            Thread.Sleep(5000);

            app.Navigation.GoToProfile();
            var createdEmail = app.Account.GetEmail();
            Assert.That(createdEmail, Is.EqualTo(account.Email));
        }

        [Test]
        public void BTheAddSiteTest()
        {
            //app.Navigation.GoToHomePage();
            //app.Auth.Login(new Account(Secret.Email,Secret.Password));
            //Thread.Sleep(5000);

            var site = new Site(domain: "55551111elizav5555555", name: "Elizavvv1111", desc: "Descr", keyWords: "key");
            app.Site.AddSite(site);
            app.Navigation.GoToSitePage(site.Address);

            app.Site.SelectCreatedSite(site.Address);
            var createdSite = app.Site.GetCreatedSiteData();
            Assert.That(createdSite.Name, Is.EqualTo(site.Name));
            Assert.That(createdSite.Address, Is.EqualTo(site.Address));
            Assert.That(createdSite.Domain, Is.EqualTo(site.Domain));
        }

        [Test]
        public void CTheEditSiteTest()
        {
            //app.Navigation.GoToHomePage();
            //app.Auth.Login(new Account(Secret.Email, Secret.Password));
            //Thread.Sleep(5000);

            var site = new Site(domain: "55551111elizav5555555", name: "Fufufu", desc: "Lililili", keyWords: "key");
            app.Navigation.GoToSitePage(site.Address);
            app.Site.SelectCreatedSite(site.Address);
            app.Site.EditSite(site);

            app.Site.SelectCreatedSite(site.Address);
            var createdSite = app.Site.GetCreatedSiteData();
            Assert.That(createdSite.Name, Is.EqualTo(site.Name));
            Assert.That(createdSite.Address, Is.EqualTo(site.Address));
            Assert.That(createdSite.Domain, Is.EqualTo(site.Domain));
            Assert.That(createdSite.Description, Is.EqualTo(site.Description));
        }
    }
}

