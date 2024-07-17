using UnityEngine;

namespace CodeBase.Logic.ObstaclLogic
{
    public abstract class Obstacle : MonoBehaviour
    {
        protected void FixedUpdate(Transform transformParent, float speed) =>
            MoveObstacle(transformParent, speed);


        private void MoveObstacle(Transform rotateTransform, float rotateSpeed) =>
            rotateTransform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }
}