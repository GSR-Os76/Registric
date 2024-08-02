namespace GSR.Registric
{
    /// <summary>
    /// Key uniquely identifying an object registered within a register.
    /// </summary>
    /// <param name="Register">The register that the key belongs to.</param>
    /// <param name="Key">The registered objects unique identifier</param>
    public record class RegisterKey<T, TKey>(IRegister<T, TKey> Register, TKey Key);
#warning add equality check and such.

#warning possibly make identifier type customizable. And hold a register reference. Register provides keys, a promise that they'll be registered eventually. Close() a register to cause any yet unfillfilled promise to become an exception.
} // end namespace