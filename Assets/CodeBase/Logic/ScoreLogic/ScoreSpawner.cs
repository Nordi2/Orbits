using UnityEngine;
using Zenject;

namespace CodeBase.Logic.ScoreLogic
{
    public class ScoreSpawner : MonoBehaviour
    {
        [Inject] private GameObject _score;

        [SerializeField] private GameObject Score;

        private void Awake()
        {
            Score = _score;
        }

        private void SpawnScore()
        {
        }
    }
}