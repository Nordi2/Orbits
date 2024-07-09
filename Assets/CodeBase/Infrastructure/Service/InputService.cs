using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Service
{
    public class InputService : ITickable , IInputService
    {
        public event Action ClickMouseButton;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickMouseButton?.Invoke();
            }
        }
    }

    public interface IInputService
    {
        event Action ClickMouseButton;
    }
}