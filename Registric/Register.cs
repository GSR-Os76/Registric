using GSR.Utilic;

namespace GSR.Registric
{
    /// <summary>
    /// Simple <see cref="IRegister{T, TKey}"/> implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public sealed class Register<T, TKey> : IRegister<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        private readonly IDictionary<RegisterKey<T, TKey>, T> _loaded = new Dictionary<RegisterKey<T, TKey>, T>();

        private readonly IDictionary<RegisterKey<T, TKey>, IReference<T, TKey>> _promised = new Dictionary<RegisterKey<T, TKey>, IReference<T, TKey>>();

        /// <inheritdoc/>
        public int Count => _promised.Count;

        /// <inheritdoc/>
        public bool IsClosed => _isClosed;

        /// <inheritdoc/>
        public bool _isClosed = false;

        /// <inheritdoc/>
        public RegisterKey<T, TKey>[] Keys => _promised.Keys.ToArray();



        /// <inheritdoc/>
        public void Close()
        {
            if (_isClosed)
                return;

            MissingObjectException[] e = _promised
                .Select((x) => x.Key)
                .Where((x) => !Contains(x))
                .Select((x) => MissingObjectException.Of(x)).ToArray();
            if(e.Length > 0)
                throw new AggregateException(e);

            _isClosed = true;
        } // end Close()

        /// <inheritdoc/>
        public bool Contains(RegisterKey<T, TKey> key) => _loaded.ContainsKey(key);

        /// <inheritdoc/>
        public bool Promised(RegisterKey<T, TKey> key) => _promised.ContainsKey(key);

        /// <inheritdoc/>
        public IReference<T, TKey> Get(RegisterKey<T, TKey> key) 
        {
            if (!_promised.ContainsKey(key))
                _promised[key] = new Reference<T, TKey>(key, new Lazy<T>(() => _loaded[key]));

            return _promised[key];
        } // end Get()

        /// <inheritdoc/>
        public IReference<T, TKey> AssociateValue<T1>(RegisterKey<T, TKey> key, T value)
        {
            if (_loaded.ContainsKey(key.IsNotNull()))
                throw KeyCollisionException.Of(key);

            _loaded[key] = value.IsNotNull();
            return Get(key);
        } // end AssociateValue()

    } // end class
} // end namespace