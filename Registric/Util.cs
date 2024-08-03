namespace GSR.Registric
{
    /// <summary>
    /// Utility methods specific to GSR.Registric.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Is the referenced object currently present in the register.
        /// </summary>
        public static bool IsPopulated<T, TKey>(this IReference<T, TKey> reference)
            where T : notnull
            where TKey : notnull
            => reference.Key.Register.Contains(reference.Key);

        /// <summary>
        /// Create a key for a given register.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="r"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static RegisterKey<T, TKey> CreateKey<T, TKey>(this IRegister<T, TKey> r, TKey key)
            where T : notnull
            where TKey : notnull
            => new(r, key);



        /// <summary>
        /// Call <see cref="IRegister{T, TKey}.Contains(TKey)"/> using a RegisterKey.
        /// </summary>
        public static bool Contains<T, TKey>(this IRegister<T, TKey> r, RegisterKey<T, TKey> key)
            where T : notnull
            where TKey : notnull 
            => r.Contains(key.Key);

        /// <summary>
        /// Call <see cref="IRegister{T, TKey}.Promised(TKey)"/> using a RegisterKey.
        /// </summary>
        public static bool Promised<T, TKey>(this IRegister<T, TKey> r, RegisterKey<T, TKey> key)
            where T : notnull
            where TKey : notnull 
            => r.Promised(key.Key);

        /// <summary>
        /// Call <see cref="IRegister{T, TKey}.Get(TKey)"/> using a RegisterKey.
        /// </summary>
        public static IReference<T, TKey> Get<T, TKey>(this IRegister<T, TKey> r, RegisterKey<T, TKey> key)
            where T : notnull
            where TKey : notnull 
            => r.Get(key.Key);

        /// <summary>
        /// Call <see cref="IRegister{T, TKey}.AssociateValue(TKey, T)"/> using a RegisterKey.
        /// </summary>
        public static IReference<T, TKey> AssociateValue<T, TKey>(this IRegister<T, TKey> r, RegisterKey<T, TKey> key, T value)
            where T : notnull
            where TKey : notnull
            => r.AssociateValue(key.Key, value);


    } // end class
} // end namespace