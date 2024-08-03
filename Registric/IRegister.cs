namespace GSR.Registric
{
    /// <summary>
    /// Contract for a object register.
    /// </summary>
    /// <typeparam name="T">The type of object held.</typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRegister<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        /// <summary>
        /// The number of register keys bound to this register, both associated with a value or not.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Has the register been closed to modification.
        /// </summary>
        public bool IsClosed { get; }

        /// <summary>
        /// All register keys bound to this register.
        /// </summary>
        public RegisterKey<T, TKey>[] Keys { get; }



        /// <summary>
        /// Check if the object referenced by the key is currently present.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(RegisterKey<T, TKey> key);

        /// <summary>
        /// Check if the register has promised there will be an object by that key registered before finalization.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Promised(RegisterKey<T, TKey> key);



        /// <summary>
        /// Gets a reference to an object that may or may not be loaded.
        /// </summary>
        /// <param name="key">The key identifying the object.</param>
        /// <returns></returns>
        public IReference<T, TKey> Get(RegisterKey<T, TKey> key);

        /// <summary>
        /// Associates a value with 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="KeyCollisionException">An object had already been associated with that key.</exception>
        public IReference<T, TKey> AssociateValue<T1>(RegisterKey<T, TKey> key, T value);



        /// <summary>
        /// Mark the register as closed, preventing further additions, and assuring all promises can be fullfilled.
        /// </summary>
        /// <exception cref="AggregateException">A collection of MissingObjectExceptions for every not associated key.</exception>
        /// <exception cref="MissingObjectException">A key was promised and yet never associated with a value.</exception>
        public void Close();
        
    } // end interface
} // end namespace