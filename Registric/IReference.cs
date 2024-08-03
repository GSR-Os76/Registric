namespace GSR.Registric
{
    /// <summary>
    /// A refernce to an object within a given register, that may or may not currently exist at the time that it's returned.
    /// </summary>
    /// <typeparam name="T">The objects type.</typeparam>
    /// <typeparam name="TKey">The type of value used to key the register.</typeparam>
    public interface IReference<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        /// <summary>
        /// The key identifying the object within it's respective register.
        /// </summary>
        public RegisterKey<T, TKey> Key { get; }



        /// <summary>
        /// Retrieve the object from the given register.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MissingObjectException">The referenced object didn't exist.</exception>
        public T Get();
    } // end interface
} // end namespace