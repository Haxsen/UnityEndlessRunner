using _EndlessRunnerTestGame.Scripts.Player;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IRunningSideManager>().To<RunningSideManager>().AsSingle().NonLazy();
        }
    }
}