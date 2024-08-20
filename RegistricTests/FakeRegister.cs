using GSR.Registric;

namespace GSR.Tests.Registric
{
    public sealed class FakeRegister<TKey, TValue> : IRegister<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        public int Count => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public TKey[] Keys => throw new NotImplementedException();

        public IReference<TKey, TValue>[] Values => throw new NotImplementedException();



        private readonly Func<TKey, bool> _contains;
        private readonly Func<TKey, bool> _promised;



        public FakeRegister(Func<TKey, bool> contains, Func<TKey, bool> promised)
        {
            _contains = contains;
            _promised = promised;
        } // end constructor



        public IReference<TKey, TValue> Associate(TKey key, TValue value)
        {
            throw new NotImplementedException();
        } // end AssociateValue()

        public bool Contains(TKey key) => _contains(key);

        public IReference<TKey, TValue> Get(TKey key)
        {
            throw new NotImplementedException();
        } // end Get()

        public bool Promised(TKey key) => _promised(key);

    } // end class
} // end namespace