namespace GSR.Registric
{
    /// <summary>
    /// An attempt was made to associate a value with an already associated key.
    /// </summary>
    [Serializable]
    public class KeyCollisionException : ArgumentException
    {
        /// <summary>
		/// Construct an exception with a message indicating what key the error emerged from.
		/// </summary>
		/// <param name="key">The excepting key.</param>
        public static KeyCollisionException Of<TKey, TValue>(RegisterKey<TKey, TValue> key)
            where TKey : notnull
            where TValue : notnull => new($"Key collision for: \"{key}\".");



        /// <inheritdoc/>
        public KeyCollisionException() { }
        /// <inheritdoc/>
        public KeyCollisionException(string message) : base(message) { }
        /// <inheritdoc/>
        public KeyCollisionException(string message, Exception inner) : base(message, inner) { }
        /// <inheritdoc/>
        protected KeyCollisionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } // end class
} // end namespace