using GSR.Registric;

namespace GSR.Tests.Registric
{
    [TestClass]
    public class TestRegister
    {
        [TestMethod]
        public void TestGet()
        {
            string key = "test.gsr.key";
            IRegister<string, int> r = new Register<string, int>();
            RegisterKey<string, int> rk = new(r, key);

            Assert.IsFalse(r.Promised(rk));
            Assert.AreEqual(rk, r.Get(key).Key);
            Assert.IsTrue(r.Promised(rk));
            Assert.AreEqual(rk, r.Get(key).Key); // shouldn't expect on repeat get.
        } // end TestGet()

        [TestMethod]
        [ExpectedException(typeof(MissingAssociationException))]
        public void TestUnwrapGottenReferenceBeforeAssociation()
        {
            new Register<string, int>().Get("a").Get();
        } // end TestUnwrapReferenceEarly()


        [TestMethod]
        public void TestAssociateValue()
        {
            IRegister<string, int> r = new Register<string, int>();

            string key = "";
            int value = 64 ^ 2;
            Assert.IsFalse(r.Contains(key));
            Assert.IsFalse(r.Promised(key));
            IReference<string, int> rr = r.Associate(key, value);
            Assert.AreEqual(key, rr.Key.Key);
            Assert.AreEqual(value, rr.Get());
            Assert.IsTrue(r.Contains(key));
            Assert.IsTrue(r.Promised(key));
        } // end TestAssociateValue()

        [TestMethod]
        public void TestAssociateValueTwice()
        {
            IRegister<string, int> r = new Register<string, int>();

            string key1 = "";
            string key2 = "-";
            int value = 64 ^ 2;

            IReference<string, int> rr1 = r.Associate(key1, value);
            Assert.AreEqual(key1, rr1.Key.Key);
            Assert.AreEqual(value, rr1.Get());

            IReference<string, int> rr2 = r.Associate(key2, value);
            Assert.AreEqual(key2, rr2.Key.Key);
            Assert.AreEqual(value, rr2.Get());
        } // end TestAssociateValueTwice()

        [TestMethod]
        [ExpectedException(typeof(KeyCollisionException))]
        public void TestAssociateKeyCollision()
        {
            IRegister<string, int> r = new Register<string, int>();

            string key = "";
            int value1 = 64 ^ 2;
            int value2 = 62;
            r.Associate(key, value1);
            r.Associate(key, value2);
        } // end TestAssociateKeyCollision()



        [TestMethod]
        public void TestCloseWithNone()
        {
            new Register<string, int>().Close();
        } // end TestCloseWithNone()

        [TestMethod]
        public void TestCloseWithAssociated()
        {
            Register<string, int> r = new Register<string, int>();

            r.Associate("ejh", 904032);
            r.Close();
        } // end TestCloseWithAssociated()

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestCloseWithUnassociated()
        {
            Register<string, int> r = new Register<string, int>();

            r.Get(";;;;;;;;;;;;;;;;;;;");
            r.Close();
        } // end TestCloseWithUnassociated()

        [TestMethod]
        public void TestGetExistingAfterClosure()
        {
            Register<string, int> r = new Register<string, int>();

            string b = "304";
            int value = 85930258;
            r.Associate(b, value);
            r.Close();
            Assert.AreEqual(value, r.Get(b).Get());
        } // end TestGetExistingAfterClosure()

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetNewAfterClosure()
        {
            Register<string, int> r = new Register<string, int>();

            r.Close();
            r.Get("304");
        } // end TestGetNewAfterClosure()

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAssociateNewValueAfterClosure()
        {
            Register<string, int> r = new Register<string, int>();

            r.Close();
            r.Associate("304", default);
        } // end TestAssociateNewValueAfterClosure()

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAssociateExistingValueAfterClosure()
        {
            Register<string, int> r = new Register<string, int>();

            string k = "3459jmivgowe";
            r.Associate(k, 0);
            r.Close();
            r.Associate(k, default);
        } // end TestAssociateNewValueAfterClosure()

    } // end class
} // end namespace