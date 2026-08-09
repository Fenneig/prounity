using System.Security.Cryptography;

namespace Game.Gameplay
{
    public sealed class Sha256Provider : IHashProvider
    {
        public byte[] Compute(byte[] input)
        {
            using SHA256 sha = SHA256.Create();
            return sha.ComputeHash(input);
        }

        public bool Verify(byte[] input, byte[] expectedHash)
        {
            byte[] actualHash = Compute(input);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}