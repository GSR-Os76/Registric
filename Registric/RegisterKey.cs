using GSR.Utilic;
using System.Diagnostics.CodeAnalysis;

namespace GSR.Registric
{
    /// <summary>
    /// Key uniquely identifying an object registered within a register.
    /// </summary>
    public struct RegisterKey<T, TKey>
        where T : notnull
        where TKey : notnull
    {
        /// <summary>
        /// The register that the key belongs to.
        /// </summary>
        public IRegister<T, TKey> Register { get; }

        /// <summary>
        /// The registered objects unique identifier.
        /// </summary>
        public TKey Key { get; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="register"></param>
        /// <param name="key"></param>
        public RegisterKey(IRegister<T, TKey> register, TKey key)
        {
            Register = register.IsNotNull();
            Key = key.IsNotNull();
        } // end constructor



        /// <inheritdoc/>
        public override string ToString() => $"Key";

        /// <inheritdoc/>
        public override int GetHashCode() => Tuple.Create(Register, Key).GetHashCode();

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? obj) =>
            obj is RegisterKey<T, TKey> rk &&
            ReferenceEquals(Register, rk.Register) &&
            Key.Equals(rk.Key);

        /// <inheritdoc/>
        public static bool operator ==(RegisterKey<T, TKey> left, RegisterKey<T, TKey> right) => left.Equals(right);

        /// <inheritdoc/>
        public static bool operator !=(RegisterKey<T, TKey> left, RegisterKey<T, TKey> right) => !(left == right);

    } // end record
} // end namespace