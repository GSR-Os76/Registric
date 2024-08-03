using GSR.Registric;

namespace GSR.Tests.Registric
{
    [TestClass]
    public class TestRegisterKey
    {
        [TestMethod]
        [DataRow("__", "_", "_")]
        [DataRow("", "", "")]
        [DataRow("gsr.alpha.beta", "gsr", ".alpha.beta")]
        public void TestEquality(string a, string b, string c)
        {
            IRegister<int, string> r = new Register<int, string>();

            Assert.AreEqual(
                new RegisterKey<int, string>(r, a),
                new RegisterKey<int, string>(r, b + c));
        } // end TestEquality()

        [TestMethod]
        [DataRow("__", "_", "-")]
        [DataRow("", "k", "")]
        [DataRow("gsr.alpha.beta", "gsr", ".beta.alpha")]
        public void TestInequality1(string a, string b, string c)
        {
            IRegister<int, string> r = new Register<int, string>();

            Assert.AreNotEqual(
                new RegisterKey<int, string>(r, a),
                new RegisterKey<int, string>(r, b + c));
        } // end TestInequality1()

        [TestMethod]
        [DataRow("__", "_", "-")]
        [DataRow("", "k", "")]
        [DataRow("gsr.alpha.beta", "gsr", ".beta.alpha")]
        public void TestInequality2(string a, string b, string c)
        {

            Assert.AreNotEqual(
                new RegisterKey<int, string>(new Register<int, string>(), a),
                new RegisterKey<int, string>(new Register<int, string>(), b + c));
        } // end TestInequality2()

    } // end class
} // end namespace