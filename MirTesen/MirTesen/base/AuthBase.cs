using MirTesen.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen
{
    public class AuthBase:TestBase
    {
        [SetUp]
        public void SetupTest()
        {
            base.SetupTest();
            var account = new Account(Settings.Email(), Settings.Password());
            app.Auth.Login(account);
            Thread.Sleep(5000);
        }
    }
}
