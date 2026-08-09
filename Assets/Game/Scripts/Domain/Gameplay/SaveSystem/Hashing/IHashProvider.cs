namespace Game.Gameplay
{
    public interface IHashProvider
    {
        byte[] Compute(byte[] input);

        bool Verify(byte[] input, byte[] expectedHash);
    }
}