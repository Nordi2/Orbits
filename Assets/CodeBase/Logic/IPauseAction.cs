using CodeBase.Logic.ObstaclLogic;

namespace CodeBase.Logic
{
    public interface IPause
    {
    }

    public interface IPauseAction : IPause
    {
        void StopAction();
        void StartAction();
    }

    public interface IPauseActionObstacle : IPause
    {
        void StopAction(Obstacle obstacle);
        void StartAction(Obstacle obstacle);
    }
}