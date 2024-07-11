using UnityEngine;

namespace CodeBase.Infrastructure.Service
{
    public class InputService : MonoBehaviour, IInputService
    {
        public bool СlickMouseButton { get; private set; }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                СlickMouseButton = true;
            }
        }
    }

    public interface IInputService
    {
        bool СlickMouseButton { get; }
    }
}