using System;

namespace Game.Gameplay
{
    public interface ICommandArgs
    {
        Type CommandType { get; set; }
    }
}