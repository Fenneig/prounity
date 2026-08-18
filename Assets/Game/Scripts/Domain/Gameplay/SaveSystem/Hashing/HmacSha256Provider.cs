using System.Security.Cryptography;
using System.Text;
using Zenject;

namespace Game.Gameplay
{
    public sealed class HmacSha256Provider : IHashProvider
    {
        private readonly byte[] _key;

        public HmacSha256Provider(byte[] key) => _key = key;

        [Inject]
        public HmacSha256Provider(string key) : this(Encoding.UTF8.GetBytes(key)) { }

        public byte[] Compute(byte[] input)
        {
            using HMACSHA256 hmac = new HMACSHA256(_key);
            return hmac.ComputeHash(input);
        }

        public bool Verify(byte[] input, byte[] expectedHash)
        {
            byte[] actualHash = Compute(input);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}