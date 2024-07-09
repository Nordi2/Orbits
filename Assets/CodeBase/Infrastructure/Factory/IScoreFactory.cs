using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IScoreFactory
    {
        GameObject CreateScore(Vector3 at);
    }
}