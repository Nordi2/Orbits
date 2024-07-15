using System;

namespace CodeBase.Logic.PlayerLogic
{
    public interface IPlayerFacade : IPauseAction
    {
        event Action DiePlayer;
    }
}