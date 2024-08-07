using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Service
{
    [UsedImplicitly]
    public class InputService : ITickable, IInputService
    {
        public event Action OnClick;

        void ITickable.Tick()
        {
#if (UNITY_ANDROID || Unity_IOS) && !UNITY_EDITOR
            MobileInput();
#else
            DestopInput();
#endif
        }

        private void MobileInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    OnClick?.Invoke();
                }
            }
        }

        private void DestopInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick?.Invoke();
            }
        }
    }
}