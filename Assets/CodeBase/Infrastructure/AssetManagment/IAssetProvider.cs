using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagment
{
    public interface IAssetProvider
    {
        GameObject LoadPrefab(string path);
    }
}