using GSR.Registric;

namespace GSR.Tests.Registric
{
    [TestClass]
    public class TestReference
    {

        [TestMethod]
        [DataRow(0)]
        public void TestGet(int value)
        {
            IRegister<int, string> r = new FakeRegister<int, string>(contains: (r) => true, promised: (r) => true);
            RegisterKey<int, string> rk = new(r, "test.gsr.key");
            IReference<int, string> rr = new Reference<int, string>(rk, new Lazy<int>(() => value));
            Assert.AreEqual(value, rr.Get());
        } // end TestGet()


        [TestMethod]
        [ExpectedException(typeof(MissingObjectException))]
        public void TestGetUnassociated()
        {
            IRegister<int, string> r = new FakeRegister<int, string>(contains: (r) => false, promised: (r) => true);
            RegisterKey<int, string> rk = new(r, "test.gsr.key");
            IReference<int, string> rr = new Reference<int, string>(rk, new Lazy<int>(() => throw new Exception()));
            rr.Get();
        } // end TestGetUnloaded()

    } // end class
} // end namespace