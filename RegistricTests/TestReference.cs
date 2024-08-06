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
            IRegister<string, int> r = new FakeRegister<string, int>(contains: (r) => true, promised: (r) => true);
            RegisterKey<string, int> rk = new(r, "test.gsr.key");
            IReference<string, int> rr = new Reference<string, int>(rk, new Lazy<int>(() => value));
            Assert.AreEqual(value, rr.Get());
        } // end TestGet()


        [TestMethod]
        [ExpectedException(typeof(MissingAssociationException))]
        public void TestGetUnassociated()
        {
            IRegister<string, int> r = new FakeRegister<string, int>(contains: (r) => false, promised: (r) => true);
            RegisterKey<string, int> rk = new(r, "test.gsr.key");
            IReference<string, int> rr = new Reference<string, int>(rk, new Lazy<int>(() => throw new Exception()));
            rr.Get();
        } // end TestGetUnloaded()

    } // end class
} // end namespace