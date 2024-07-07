using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Mantis_tests
{
    [TestFixture]
    public class FTP_test : TestBase
    {
        [Test]
        public void TestMethod1()
        {

            AccountData account = new AccountData() 
            {Name = "vvv" , Password = "bbb"} ;
            ClassicAssert.IsFalse(app.James.Verify(account));
            app.James.Add(account);
            ClassicAssert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            ClassicAssert.IsFalse(app.James.Verify(account));
        }
    }
}
