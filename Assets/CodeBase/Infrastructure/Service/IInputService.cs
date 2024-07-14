using System;

namespace CodeBase.Infrastructure.Service
{
    public interface IInputService
    {
        event Action OnClickMouseButton;
        event Action OnClickFirsrMouseButton;
    }
}