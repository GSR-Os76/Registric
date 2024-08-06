namespace GSR.Registric
{
    /// <summary>
    /// A refernce to an object within a given register, that may or may not currently exist at the time that it's returned.
    /// </summary>
    /// <typeparam name="TKey">The type of value used to key the register.</typeparam>
    /// <typeparam name="TValue">The objects type.</typeparam>
    public interface IReference<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        /// <summary>
        /// The key identifying the object within it's respective register.
        /// </summary>
        public RegisterKey<TKey, TValue> Key { get; }



        /// <summary>
        /// Retrieve the object from the given register.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MissingAssociationException">The referenced object didn't exist.</exception>
        public TValue Get();
    } // end interface
} // end namespace