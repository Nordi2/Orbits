using UnityEngine;

enum TypeObstacle
{
    Far = 1,
    Middle = 2,
    Close = 3,
}

namespace MyNamespace
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Transform _rotateTransform;

        private void FixedUpdate()
        {
            _rotateTransform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
        }
    }
}