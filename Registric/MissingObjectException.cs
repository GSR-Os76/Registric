using Microsoft.Win32;

namespace GSR.Registric
{
	/// <summary>
	/// An object wasn't present in a <see cref="IRegister{T}"/> when it was expected to be.
	/// </summary>
	[Serializable]
	public class MissingObjectException<T> : Exception
	{
        /// <summary>
        /// Construct an exception with a message indicating what key the error emerged from.
        /// </summary>
        /// <param name="key">The excepted key.</param>
        public MissingObjectException(RegisterKey<T> key) : base($"Object missing for: {key}.") { }
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