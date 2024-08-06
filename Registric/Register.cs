using GSR.Utilic;

namespace GSR.Registric
{
    /// <summary>
    /// Simple <see cref="IRegister{TKey, TValue}"/> implementation.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public sealed class Register<TKey, TValue> : IRegister<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        private readonly IDictionary<TKey, TValue> _loaded = new Dictionary<TKey, TValue>();

        private readonly IDictionary<TKey, IReference<TKey, TValue>> _promised = new Dictionary<TKey, IReference<TKey, TValue>>();

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
        public IReference<TKey, TValue> Get(TKey key)
        {
            if (!Promised(key))
                if (_isClosed)
                    throw new InvalidOperationException("Register is closed, can't promise any further values.");
                else
                    _promised[key] = new Reference<TKey, TValue>(this.CreateKey(key), new Lazy<TValue>(() => _loaded[key]));

            return _promised[key];
        } // end Get()


        /// <inheritdoc/>
        public IReference<TKey, TValue> Associate(TKey key, TValue value)
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