using GSR.Registric;

namespace GSR.Tests.Registric
{
    public sealed class FakeRegister<T, TKey> : IRegister<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        public int Count => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public TKey[] Keys => throw new NotImplementedException();



        private readonly Func<TKey, bool> _contains;
        private readonly Func<TKey, bool> _promised;



        public FakeRegister(Func<TKey, bool> contains, Func<TKey, bool> promised)
        {
            _contains = contains;
            _promised = promised;
        } // end constructor



        public IReference<T, TKey> AssociateValue(TKey key, T value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(TKey key) => _contains(key);

        public IReference<T, TKey> Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Promised(TKey key) => _promised(key);

    } // end class
} // end namespace