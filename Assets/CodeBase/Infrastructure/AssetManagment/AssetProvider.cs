using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadPrefab(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return prefab;
        }
    }
}