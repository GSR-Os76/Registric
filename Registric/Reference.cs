using GSR.Utilic;

namespace GSR.Registric
{
    /// <summary>
    /// Simple <see cref="IReference{T}"/> implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Reference<T> : IReference<T>
    {
        /// <inheritdoc/>
        public RegisterKey<T> Key { get; }

        private Lazy<T> _value;



        /// <summary>
        /// Constructs an <see cref="Reference{T}"/>.
        /// </summary>
        /// <param name="key">The key of the object the reference refers to.</param>
        /// <param name="value">The providersof the value.</param>
        public Reference(RegisterKey key, Lazy<T> value)
        {
            Key = key.IsNotNull();
            _value = value.IsNotNull();
        } // end ctor


        /// <inheritdoc/>
        public T Get() => this.IsPopulated()
    } // end class
} // end namespace