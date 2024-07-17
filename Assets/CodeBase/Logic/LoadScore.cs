using CodeBase.Data;
using CodeBase.SaveSystem;
using JetBrains.Annotations;
using Zenject;

namespace CodeBase.Logic
{
    [UsedImplicitly]
    public class LoadScore : IInitializable
    {
        private int _maxScore;
        public int MaxScore => _maxScore;

        public void Initialize()
        {
            PlayerData data = LoadProgress.LoadPlayer();
            _maxScore = data?.MaxScore ?? Constant.InitialScore;
        }
    }
}