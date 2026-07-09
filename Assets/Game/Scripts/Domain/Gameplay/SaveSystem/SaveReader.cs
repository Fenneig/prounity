using System.IO;
using System.Text;
using UnityEngine;

namespace Game.Gameplay
{
    public class SaveReader
    {
        private readonly BinaryReader _reader;

        public SaveReader(byte[] data) => 
            _reader = new BinaryReader(new MemoryStream(data), Encoding.UTF8, true);

        public int ReadInt() => _reader.ReadInt32();

        public float ReadFloat() => _reader.ReadSingle();

        public string ReadString() => _reader.ReadString();

        public Vector3 ReadVector3()
        {
            return new Vector3(
                ReadFloat(),
                ReadFloat(),
                ReadFloat());
        }

        public Quaternion ReadQuaternion()
        {
            return new Quaternion(
                ReadFloat(),
                ReadFloat(),
                ReadFloat(),
                ReadFloat());
        }
    }
}