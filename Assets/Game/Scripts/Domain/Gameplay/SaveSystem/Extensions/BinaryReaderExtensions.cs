using System.IO;
using UnityEngine;

namespace Game.Gameplay.Extensions
{
    public static class BinaryReaderExtensions
    {
        public static Vector3 ReadVector3(this BinaryReader reader)
        {
            return new Vector3(
                reader.ReadSingle(),
                reader.ReadSingle(),
                reader.ReadSingle());
        }

        public static Quaternion ReadQuaternion(this BinaryReader reader)
        {
            return new Quaternion(
                reader.ReadSingle(),
                reader.ReadSingle(),
                reader.ReadSingle(),
                reader.ReadSingle());
        }
    }
}