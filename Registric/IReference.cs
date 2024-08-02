namespace GSR.Registric
{
    /// <summary>
    /// A refernce to an object within a given register, that may or may not currently exist at the time that it's returned.
    /// </summary>
    /// <typeparam name="T">The objects type.</typeparam>
    public interface IReference<T>
    {
        /// <summary>
        /// Is the referenced object currently present in the register.
        /// </summary>
        public bool IsPopulated => Key.Register.Contains(Key);

        /// <summary>
        /// The key identifying the object within it's respective register.
        /// </summary>
        public RegisterKey<T> Key { get; }



        /// <summary>
        /// Retrieve the object from the given register.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MissingObjectException{T}">The referenced object didn't exist.</exception>
        public T Get();
    } // end interface
} // end namespace