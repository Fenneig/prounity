using Newtonsoft.Json.Linq;

namespace Game.Gameplay
{
    public interface ISaveSerializer
    {
        string Key => GetType().Name;
        
        JToken Serialize();
        
        void Deserialize(JToken token);
    }

    public interface ISaveSerializer<T> : ISaveSerializer
    {
        JToken ISaveSerializer.Serialize() => JToken.FromObject(Serialize());
        
        void ISaveSerializer.Deserialize(JToken token) => Deserialize(token.ToObject<T>());
        
        new T Serialize();
        
        void Deserialize(T value);
    }
}