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


    } // end class
} // end namespace