using MirTesen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen
{

    [TestFixture]
    public class LoginTests : TestBase
    {

        [Test]
        public void LoginWithValidData()
        {
            app.Auth.Logout();
            var account = new Account(Settings.Email(), Settings.Password());
            app.Navigation.GoToHomePage();
            app.Auth.Login(account);
            Thread.Sleep(5000);

            var profileId = app.Account.GetProfileId();
            app.Navigation.GoToProfile(profileId);
            var createdEmail = app.Account.GetEmail();
            Assert.That(createdEmail, Is.EqualTo(account.Email));
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Auth.Logout();
            var rnd = new Random();
            var account = new Account($"{rnd.Next()}@gmail.com", rnd.Next().ToString());
            app.Navigation.GoToHomePage();
            app.Auth.Login(account);
            Thread.Sleep(5000);
            Assert.That(app.Auth.IsLoggedIn, Is.EqualTo(false));
        }
    }
}
