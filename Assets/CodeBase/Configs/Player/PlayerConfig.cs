using UnityEngine;

namespace CodeBase.Configs.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "ScritableObjects/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Range(0, 360)][SerializeField] private float _speed;
        [Range(0, 1)][SerializeField] private float _swapTime;

        public float Speed => _speed;
        public float SwapTime => _swapTime;
    }
}