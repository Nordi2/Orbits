using UnityEngine;

namespace CodeBase.Configs.Obstacle
{
    [CreateAssetMenu(fileName = "Obstacle", menuName = "ScritableObjects/ObstacleConfig", order = 1)]
    public class ObstacleConfig : ScriptableObject
    {
        [Range(0, 200)] [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}