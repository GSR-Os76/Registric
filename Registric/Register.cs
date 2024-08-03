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
        private readonly IDictionary<TKey, T> _loaded = new Dictionary<TKey, T>();

        private readonly IDictionary<TKey, IReference<T, TKey>> _promised = new Dictionary<TKey, IReference<T, TKey>>();

        /// <inheritdoc/>
        public int Count => _promised.Count;

        /// <inheritdoc/>
        public bool IsClosed => _isClosed;

        /// <inheritdoc/>
        public bool _isClosed = false;

        /// <inheritdoc/>
        public TKey[] Keys => _promised.Keys.ToArray();



        /// <summary>
        /// Mark the register as closed, preventing further additions, and assuring all promises can be fullfilled.
        /// </summary>
        /// <exception cref="AggregateException">A collection of <see cref="MissingAssociationException"/> for every key that wasn't associated with a value.</exception>
        public void Close()
        {
            if (_isClosed)
                return;

            MissingAssociationException[] e = _promised
                .Select((x) => x.Key)
                .Where((x) => !Contains(x))
                .Select((x) => MissingAssociationException.Of(this.CreateKey(x))).ToArray();
            if (e.Length > 0)
                throw new AggregateException(e);

            _isClosed = true;
        } // end Close()

        /// <inheritdoc/>
        public bool Contains(TKey key) => _loaded.ContainsKey(key);

        /// <inheritdoc/>
        public bool Promised(TKey key) => _promised.ContainsKey(key);

        /// <inheritdoc/>
        public IReference<T, TKey> Get(TKey key)
        {
            if (!Promised(key))
                if (_isClosed)
                    throw new InvalidOperationException("Register is closed, can't promise any further values.");
                else
                    _promised[key] = new Reference<T, TKey>(this.CreateKey(key), new Lazy<T>(() => _loaded[key]));

            return _promised[key];
        } // end Get()


        /// <inheritdoc/>
        public IReference<T, TKey> AssociateValue(TKey key, T value)
        {
            if (_isClosed)
                throw new InvalidOperationException("Register is closed, can't associate any further values.");

            if (Contains(key.IsNotNull()))
                throw KeyCollisionException.Of(this.CreateKey(key));

            _loaded[key] = value.IsNotNull();
            return Get(key);
        } // end AssociateValue()

    } // end class
} // end namespace