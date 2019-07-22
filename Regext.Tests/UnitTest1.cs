using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Regext.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var util = PairingUtil.IsPaired("{}{}");
        }

        [TestMethod]
        public void TestMehtod2()
        {
            Assert.IsTrue(PairingUtil.IsPaired("(){}[(){}]"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsFalse(PairingUtil.IsPaired("()("));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsFalse(PairingUtil.IsPaired("}{}{"));
        }
    }
}
