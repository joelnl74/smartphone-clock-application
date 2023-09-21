using Audio.Interfaces;
using UnityEngine;
using Zenject;

namespace Audio
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioEventScriptAbleObjectCollection audioEventScriptAbleObjectCollection;

        public override void InstallBindings()
        {
            // System.
            Container.Bind<IAudioSystem>().To<AudioSystem>().FromComponentInHierarchy().AsSingle();
            
            // Scriptable objects.
            Container.Bind<IAudioEventScriptAbleObjectCollection>().To<AudioEventScriptAbleObjectCollection>().FromInstance(audioEventScriptAbleObjectCollection).AsSingle();

            // Signals
            Container.DeclareSignal<PlayAudioSignal>();
            Container.BindSignal<PlayAudioSignal>()
                .ToMethod<IAudioSystem>(x => x.Play).FromResolve();
        }
    }
}
