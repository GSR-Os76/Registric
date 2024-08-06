namespace GSR.Registric
{
    /// <summary>
    /// A key wasn't associated in a <see cref="IRegister{TKey, TValue}"/> when it was expected to be.
    /// </summary>
    [Serializable]
    public class MissingAssociationException : Exception

    {
        /// <summary>
        /// Construct an exception with a message indicating what key the error emerged from.
        /// </summary>
        /// <param name="key">The excepting key.</param>
        public static MissingAssociationException Of<TKey, TValue>(RegisterKey<TKey, TValue> key)
            where TKey : notnull
            where TValue : notnull => new MissingAssociationException($"Object missing for: \"{key}\".");



        /// <inheritdoc/>
        public MissingAssociationException() { }
        /// <inheritdoc/>
        public MissingAssociationException(string message) : base(message) { }
        /// <inheritdoc/>
        public MissingAssociationException(string message, Exception inner) : base(message, inner) { }
        /// <inheritdoc/>
        protected MissingAssociationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } // end class
} // end namespace