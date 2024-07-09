using CodeBase.Infrastructure.AssetManagment;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class ScoreFactory : IScoreFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private GameObject ScoreGameObject { get; set; }

        public ScoreFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public GameObject CreateScore(Vector3 at)
        {
            ScoreGameObject = InstantiateRegistered(AssetPath.PathScore, at);
            return ScoreGameObject;
        }

        private GameObject InstantiateRegistered(string path, Vector3 position)
        {
            GameObject prefab = _assetProvider.LoadPrefab(path);
            return _instantiator.InstantiatePrefab(prefab, position, quaternion.identity, null);
        }
    }
}