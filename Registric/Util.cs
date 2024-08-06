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
        public static bool IsPopulated<TKey, TValue>(this IReference<TKey, TValue> reference)
            where TKey : notnull
            where TValue : notnull
            => reference.Key.Register.Contains(reference.Key);

        /// <summary>
        /// Create a key for a given register.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="register"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static RegisterKey<TKey, TValue> CreateKey<TKey, TValue>(this IRegister<TKey, TValue> register, TKey key)
            where TKey : notnull
            where TValue : notnull
            => new(register, key);



        /// <summary>
        /// Call <see cref="IRegister{TKey, TValue}.Contains(TKey)"/> using a RegisterKey.
        /// </summary>
        public static bool Contains<TKey, TValue>(this IRegister<TKey, TValue> register, RegisterKey<TKey, TValue> key)
            where TKey : notnull
            where TValue : notnull
            => ReferenceEquals(register, key.Register) && register.Contains(key.Key);

        /// <summary>
        /// Call <see cref="IRegister{TKey, TValue}.Promised(TKey)"/> using a RegisterKey.
        /// </summary>
        public static bool Promised<TKey, TValue>(this IRegister<TKey, TValue> register, RegisterKey<TKey, TValue> key)
            where TKey : notnull 
            where TValue : notnull
            => ReferenceEquals(register, key.Register) && register.Promised(key.Key);

        /// <summary>
        /// Call <see cref="IRegister{TKey, TValue}.Get(TKey)"/> using a RegisterKey.
        /// </summary>
        public static IReference<TKey, TValue> Get<TKey, TValue>(this IRegister<TKey, TValue> register, RegisterKey<TKey, TValue> key)
            where TKey : notnull 
            where TValue : notnull
            => ReferenceEquals(register, key.Register) 
                ? register.Get(key.Key) 
                : throw new InvalidOperationException("Key didn't belong to the register it was attemptedly used on.");

        /// <summary>
        /// Call <see cref="IRegister{TKey, TValue}.Associate(TKey, TValue)"/> using a RegisterKey.
        /// </summary>
        public static IReference<TKey, TValue> Associate<TKey, TValue>(this IRegister<TKey, TValue> register, RegisterKey<TKey, TValue> key, TValue value)
            where TKey : notnull
            where TValue : notnull
            => ReferenceEquals(register, key.Register)
                ? register.Associate(key.Key, value)
                : throw new InvalidOperationException("Key didn't belong to the register it was attemptedly used on.");



        /// <summary>
        /// Get's an <see cref="IReference{TKey, TValue}"/> to the value associated with the register key.
        /// </summary>
        public static IReference<TKey, TValue> Get<TKey, TValue>(this RegisterKey<TKey, TValue> key)
            where TKey : notnull
            where TValue : notnull
            => key.Register.Get(key.Key);

        /// <summary>
        /// Creates an association between the key and a value.
        /// </summary>
        public static IReference<TKey, TValue> AssociateValue<TKey, TValue>(this RegisterKey<TKey, TValue> key, TValue value)
            where TKey : notnull
            where TValue : notnull
            => key.Register.Associate(key.Key, value);


    } // end class
} // end namespace