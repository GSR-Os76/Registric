using GSR.Utilic;
using System.Diagnostics.CodeAnalysis;

namespace GSR.Registric
{
    /// <summary>
    /// Key uniquely identifying an object registered within a register.
    /// </summary>
    public struct RegisterKey<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        /// <summary>
        /// The register that the key belongs to.
        /// </summary>
        public IRegister<TKey, TValue> Register { get; }

        /// <summary>
        /// The registered objects unique identifier.
        /// </summary>
        public TKey Key { get; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="register"></param>
        /// <param name="key"></param>
        public RegisterKey(IRegister<TKey, TValue> register, TKey key)
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
            obj is RegisterKey<TKey, TValue> rk &&
            ReferenceEquals(Register, rk.Register) &&
            Key.Equals(rk.Key);

        /// <inheritdoc/>
        public static bool operator ==(RegisterKey<TKey, TValue> left, RegisterKey<TKey, TValue> right) => left.Equals(right);

        /// <inheritdoc/>
        public static bool operator !=(RegisterKey<TKey, TValue> left, RegisterKey<TKey, TValue> right) => !(left == right);

    } // end record
} // end namespace