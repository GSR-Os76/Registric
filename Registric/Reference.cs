using GSR.Utilic;

namespace GSR.Registric
{
    /// <summary>
    /// Simple <see cref="IReference{T, TKey}"/> implementation.
    /// </summary>
    /// <typeparam name="T">The type of object referenced.</typeparam>
    /// <typeparam name="TKey"></typeparam>
    public sealed class Reference<T, TKey> : IReference<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        /// <inheritdoc/>
        public RegisterKey<T, TKey> Key { get; }

        private Lazy<T> _value;



        /// <summary>
        /// Constructs an <see cref="Reference{T, TKey}"/>.
        /// </summary>
        /// <param name="key">The key of the object the reference refers to.</param>
        /// <param name="value">The providersof the value.</param>
        public Reference(RegisterKey<T, TKey> key, Lazy<T> value)
        {
            Key = key.IsNotNull();
            _value = value.IsNotNull();
        } // end constructor


        /// <inheritdoc/>
        public T Get() => this.IsPopulated()
            ? _value.Value
            : throw new MissingObjectException("The object wasn't present in the register.");
    } // end class
} // end namespace