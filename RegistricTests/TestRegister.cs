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
            IRegister<int, string> r = new Register<int, string>();
            RegisterKey<int, string> rk = new(r, key);

            Assert.IsFalse(r.Promised(rk));
            Assert.AreEqual(rk, r.Get(key).Key);
            Assert.IsTrue(r.Promised(rk));
            Assert.AreEqual(rk, r.Get(key).Key); // shouldn't expect on repeat get.
        } // end TestGet()

        [TestMethod]
        [ExpectedException(typeof(MissingAssociationException))]
        public void TestUnwrapGottenReferenceBeforeAssociation()
        {
            new Register<int, string>().Get("a").Get();
        } // end TestUnwrapReferenceEarly()


        [TestMethod]
        public void TestAssociateValue()
        {
            IRegister<int, string> r = new Register<int, string>();

            string key = "";
            int value = 64 ^ 2;
            Assert.IsFalse(r.Contains(key));
            Assert.IsFalse(r.Promised(key));
            IReference<int, string> rr = r.AssociateValue(key, value);
            Assert.AreEqual(key, rr.Key.Key);
            Assert.AreEqual(value, rr.Get());
            Assert.IsTrue(r.Contains(key));
            Assert.IsTrue(r.Promised(key));
        } // end TestAssociateValue()

        [TestMethod]
        public void TestAssociateValueTwice()
        {
            IRegister<int, string> r = new Register<int, string>();

            string key1 = "";
            string key2 = "-";
            int value = 64 ^ 2;

            IReference<int, string> rr1 = r.AssociateValue(key1, value);
            Assert.AreEqual(key1, rr1.Key.Key);
            Assert.AreEqual(value, rr1.Get());

            IReference<int, string> rr2 = r.AssociateValue(key2, value);
            Assert.AreEqual(key2, rr2.Key.Key);
            Assert.AreEqual(value, rr2.Get());
        } // end TestAssociateValueTwice()

        [TestMethod]
        [ExpectedException(typeof(KeyCollisionException))]
        public void TestAssociateKeyCollision()
        {
            IRegister<int, string> r = new Register<int, string>();

            string key = "";
            int value1 = 64 ^ 2;
            int value2 = 62;
            r.AssociateValue(key, value1);
            r.AssociateValue(key, value2);
        } // end TestAssociateKeyCollision()



        [TestMethod]
        public void TestCloseWithNone()
        {
            new Register<int, string>().Close();
        } // end TestCloseWithNone()

        [TestMethod]
        public void TestCloseWithAssociated()
        {
            Register<int, string> r = new Register<int, string>();

            r.AssociateValue("ejh", 904032);
            r.Close();
        } // end TestCloseWithAssociated()

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestCloseWithUnassociated()
        {
            Register<int, string> r = new Register<int, string>();

            r.Get(";;;;;;;;;;;;;;;;;;;");
            r.Close();
        } // end TestCloseWithUnassociated()

        [TestMethod]
        public void TestGetExistingAfterClosure()
        {
            Register<int, string> r = new Register<int, string>();

            string b = "304";
            int value = 85930258;
            r.AssociateValue(b, value);
            r.Close();
            Assert.AreEqual(value, r.Get(b).Get());
        } // end TestGetExistingAfterClosure()

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetNewAfterClosure()
        {
            Register<int, string> r = new Register<int, string>();

            r.Close();
            r.Get("304");
        } // end TestGetNewAfterClosure()

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAssociateNewValueAfterClosure()
        {
            Register<int, string> r = new Register<int, string>();

            r.Close();
            r.AssociateValue("304", default);
        } // end TestAssociateNewValueAfterClosure()

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAssociateExistingValueAfterClosure()
        {
            Register<int, string> r = new Register<int, string>();

            string k = "3459jmivgowe";
            r.AssociateValue(k, 0);
            r.Close();
            r.AssociateValue(k, default);
        } // end TestAssociateNewValueAfterClosure()

    } // end class
} // end namespace