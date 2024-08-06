namespace GSR.Registric
{
    /// <summary>
    /// Contract for a object register.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue">The type of object held.</typeparam>
    public interface IRegister<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        /// <summary>
        /// The number of register keys bound to this register, both associated with a value or not.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Has the register been closed to modification, and assured that all promises are fulfilled.
        /// </summary>
        public bool IsClosed { get; }

        /// <summary>
        /// All register keys bound to this register.
        /// </summary>
        public TKey[] Keys { get; }



        /// <summary>
        /// Check if the object referenced by the key is currently present.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(TKey key);

        /// <summary>
        /// Check if the register has promised there will be an object by that key registered before finalization.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Promised(TKey key);



        /// <summary>
        /// Gets a reference to an object that may or may not be loaded.
        /// </summary>
        /// <param name="key">The key identifying the object.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Register is closed, and can't promise further values.</exception>
        public IReference<TKey, TValue> Get(TKey key);

        /// <summary>
        /// Associates a value with 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Register is closed, and can't try to associate further values.</exception>
        /// <exception cref="KeyCollisionException">An object had already been associated with that key.</exception>
        public IReference<TKey, TValue> Associate(TKey key, TValue value);

    } // end interface
} // end namespace