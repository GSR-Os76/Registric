namespace GSR.Registric
{
    /// <summary>
    /// A key wasn't associated in a <see cref="IRegister{T, TKey}"/> when it was expected to be.
    /// </summary>
    [Serializable]
    public class MissingObjectException : Exception

    {
        /// <summary>
        /// Construct an exception with a message indicating what key the error emerged from.
        /// </summary>
        /// <param name="key">The excepting key.</param>
        public static MissingObjectException Of<T, TKey>(RegisterKey<T, TKey> key)
            where T : notnull
            where TKey : notnull => new MissingObjectException($"Object missing for: \"{key}\".");



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