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
            IRegister<string, int> r = new Register<string, int>();

            Assert.AreEqual(
                new RegisterKey<string, int>(r, a),
                new RegisterKey<string, int>(r, b + c));
        } // end TestEquality()

        [TestMethod]
        [DataRow("__", "_", "-")]
        [DataRow("", "k", "")]
        [DataRow("gsr.alpha.beta", "gsr", ".beta.alpha")]
        public void TestInequality1(string a, string b, string c)
        {
            IRegister<string, int> r = new Register<string, int>();

            Assert.AreNotEqual(
                new RegisterKey<string, int>(r, a),
                new RegisterKey<string, int>(r, b + c));
        } // end TestInequality1()

        [TestMethod]
        [DataRow("__", "_", "-")]
        [DataRow("", "k", "")]
        [DataRow("gsr.alpha.beta", "gsr", ".beta.alpha")]
        public void TestInequality2(string a, string b, string c)
        {

            Assert.AreNotEqual(
                new RegisterKey<string, int>(new Register<string, int>(), a),
                new RegisterKey<string, int>(new Register<string, int>(), b + c));
        } // end TestInequality2()

    } // end class
} // end namespace