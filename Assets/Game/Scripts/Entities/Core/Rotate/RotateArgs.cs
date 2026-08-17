using UnityEngine;

namespace Game.Entities
{
    public struct RotateArgs
    {
        public Vector3 Direction;
        public float DeltaTime;

        public RotateArgs(Vector3 direction, float deltaTime)
        {
            Direction = direction;
            DeltaTime = deltaTime;
        }
    }
}