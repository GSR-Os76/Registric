namespace GSR.Registric
{
    public interface IRegister<T, TKey>
    {
        Count

            indexerGetAt. index of key.

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
        public IReference<T> Get(RegisterKey<T, TKey> key);

        /// <summary>
        /// Associates a value with 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="KeyCollisionException{T}">An object had already been registered under that key.</exception>
        public IReference<T> Register(RegisterKey<T, TKey> key, T value);



        /// <summary>
        /// Mark the registry as final, preventing further additions.
        /// </summary>
        public void Finalize() 
        {

        } // end Finalize()

    } // end interface
} // end namespace