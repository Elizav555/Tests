using MirTesen.model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

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

        public static List<Site> SiteDataFromJsonFile()
        {
            string folder = @"D:\Github\Tests\";
            string fileName = "siteData.json";
            string fileEditedName = "siteEditedData.json";
            using (FileStream fs = new FileStream(folder+fileName, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Site>>(fs);
            }
        }


        [Test, TestCaseSource(nameof(SiteDataFromJsonFile))]
        public void BTheAddSiteTest(Site site)
        {
            //app.Navigation.GoToHomePage();
            //app.Auth.Login(new Account(Secret.Email,Secret.Password));
            //Thread.Sleep(5000);

            app.Site.AddSite(site);
            app.Navigation.GoToSitePage(site.Address);

            app.Site.SelectCreatedSite(site.Address);
            var createdSite = app.Site.GetCreatedSiteData();
            Assert.That(createdSite.Name, Is.EqualTo(site.Name));
            Assert.That(createdSite.Address, Is.EqualTo(site.Address));
            Assert.That(createdSite.Domain, Is.EqualTo(site.Domain));
        }

        public static List<Site> SiteEditedDataFromJsonFile()
        {
            string folder = @"D:\Github\Tests\";
            string fileEditedName = "siteEditedData.json";
            using (FileStream fs = new FileStream(folder + fileEditedName, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Site>>(fs);
            }
        }


        [Test, TestCaseSource(nameof(SiteEditedDataFromJsonFile))]
        public void CTheEditSiteTest(Site site)
        {
            //app.Navigation.GoToHomePage();
            //app.Auth.Login(new Account(Secret.Email, Secret.Password));
            //Thread.Sleep(5000);

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

