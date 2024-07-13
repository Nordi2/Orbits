using CodeBase.Logic.PlayerLogic;
using Zenject;

namespace CodeBase.Logic
{
    public class StopActionObject : IInitializable
    {
        private PlayerMovement _playerMovement;
        public StopActionObject(IPause pause)
        {
        }
        public void Initialize()
        {
            
        }
    }
}
