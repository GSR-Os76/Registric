using GSR.Utilic;

namespace GSR.Registric
{
    /// <summary>
    /// Simple <see cref="IReference{Tkey, TValue}"/> implementation.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue">The type of object referenced.</typeparam>
    public sealed class Reference<TKey, TValue> : IReference<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        /// <inheritdoc/>
        public RegisterKey<TKey, TValue> Key { get; }

        private Lazy<TValue> _value;



        /// <summary>
        /// Constructs an <see cref="Reference{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The key of the object the reference refers to.</param>
        /// <param name="value">The providersof the value.</param>
        public Reference(RegisterKey<TKey, TValue> key, Lazy<TValue> value)
        {
            Key = key.IsNotNull();
            _value = value.IsNotNull();
        } // end constructor


        /// <inheritdoc/>
        public TValue Get() => this.IsPopulated()
            ? _value.Value
            : throw new MissingAssociationException("The object wasn't present in the register.");
    } // end class
} // end namespace