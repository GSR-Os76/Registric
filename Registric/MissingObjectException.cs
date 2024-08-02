namespace GSR.Registric
{
    /// <summary>
    /// An object wasn't present in a <see cref="IRegister{T, TKey}"/> when it was expected to be.
    /// </summary>
    [Serializable]
    public class MissingObjectException<T, TKey> : Exception
        where T : notnull
        where TKey : notnull
    {
        /// <summary>
        /// Construct an exception with a message indicating what key the error emerged from.
        /// </summary>
        /// <param name="key">The excepted key.</param>
        public MissingObjectException(RegisterKey<T, TKey> key) : base($"Object missing for: {key}.") { }
        /// <inheritdoc/>
        public MissingObjectException() { }
        /// <inheritdoc/>
        public MissingObjectException(string message) : base(message) { }
        /// <inheritdoc/>
        public MissingObjectException(string message, Exception inner) : base(message, inner) { }
        /// <inheritdoc/>
        protected MissingObjectException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } // end class
} // end namespace