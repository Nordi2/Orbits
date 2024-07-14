using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Service
{
    [UsedImplicitly]
    public class InputService : ITickable, IInputService
    {
        public event Action OnClickMouseButton;
        public event Action OnClickFirsrMouseButton;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClickMouseButton?.Invoke();
                OnClickFirsrMouseButton?.Invoke();
            }
        }
    }
}