namespace GSR.Registric
{
    /// <summary>
    /// Simple <see cref="IRegister{T, TKey}"/> implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class Register<T, TKey> : IRegister<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        private readonly IDictionary<RegisterKey<T>, T> _loaded = new Dictionary<RegisterKey<T>, T>();

        private readonly IDictionary<RegisterKey<T>, IReference<T>> _promised = new Dictionary<RegisterKey<T>, IReference<T>>();




        public IReference<T> GetMember(RegisterKey<T> key)
        {
            if (!_promised.ContainsKey(key))
                _promised[key] = new Reference<T>(key, new Lazy<T>(() => _loaded[key]));

            return _promised[key];
        } // end GetMember()

        public IReference<T> Register(RegisterKey<T> key, T value)
        {
            if (_loaded.ContainsKey(key))
                throw new KeyCollisionException(key);

            _loaded[key] = value;
            return GetMember(key);
        } // end Register

    } // end class
} // end namespace