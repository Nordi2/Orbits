using UnityEngine;

namespace Config.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "ScritableObjects/PlayerConfig", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        [Range(0, 200)] [SerializeField] private float _speed;
        public float Speed => _speed;
    }
}