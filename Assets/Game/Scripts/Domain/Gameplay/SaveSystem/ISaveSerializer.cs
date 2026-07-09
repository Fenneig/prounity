namespace Game.Gameplay
{
    public interface ISaveSerializer
    {
        void Serialize(ref SaveWriter writer);

        void Deserialize(ref SaveReader reader);
    }
}