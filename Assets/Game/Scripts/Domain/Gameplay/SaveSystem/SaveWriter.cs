using System.IO;
using System.Text;
using UnityEngine;

namespace Game.Gameplay
{
    public class SaveWriter
    {
        private readonly MemoryStream _stream;
        private readonly BinaryWriter _writer;
        
        private const int DEFAULT_CAPACITY = 4096;

        public SaveWriter()
        {
            _stream = new MemoryStream(DEFAULT_CAPACITY);
            _writer = new BinaryWriter(_stream, Encoding.UTF8, true);
        }

        public void Write(int value) => _writer.Write(value);

        public void Write(float value) => _writer.Write(value);

        public void Write(string value) => _writer.Write(value ?? string.Empty);

        public void Write(Vector3 value)
        {
            Write(value.x);
            Write(value.y);
            Write(value.z);
        }

        public void Write(Quaternion value)
        {
            Write(value.x);
            Write(value.y);
            Write(value.z);
            Write(value.w);
        }
        
        public byte[] ToArray() => _stream.ToArray();
    }
}