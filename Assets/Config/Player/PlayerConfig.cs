using UnityEngine;

namespace Config.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "ScritableObjects/PlayerConfig", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        [Range(0, 360)] [SerializeField] private float _speed;
        [Range(0, 1)] [SerializeField] private float _moveTime;
        public float Speed => _speed;
        public float MoveTime => _moveTime;
    }
}