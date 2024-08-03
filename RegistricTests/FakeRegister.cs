using GSR.Registric;
using System.ComponentModel;

namespace GSR.Tests.Registric
{
    public sealed class FakeRegister<T, TKey> : IRegister<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        public int Count => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public RegisterKey<T, TKey>[] Keys => throw new NotImplementedException();



        private readonly Func<RegisterKey<T, TKey>, bool> _contains;
        private readonly Func<RegisterKey<T, TKey>, bool> _promised;



        public FakeRegister(Func<RegisterKey<T, TKey>, bool> contains, Func<RegisterKey<T, TKey>, bool> promised) 
        {
            _contains = contains;
            _promised = promised;
        } // end constructor



        public IReference<T, TKey> AssociateValue<T1>(RegisterKey<T, TKey> key, T value)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Contains(RegisterKey<T, TKey> key) => _contains(key);

        public IReference<T, TKey> Get(RegisterKey<T, TKey> key)
        {
            throw new NotImplementedException();
        }

        public bool Promised(RegisterKey<T, TKey> key) => _promised(key);

    } // end class
} // end namespace