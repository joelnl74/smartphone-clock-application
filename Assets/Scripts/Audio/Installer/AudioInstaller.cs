using Zenject;

namespace Audio
{
    public class AudioInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAudioSystem>().To<AudioSystem>().FromComponentInHierarchy().AsSingle();
        }
    }
}
