using NUnit.Framework;
using Zenject;
using Audio;
using Audio.Interfaces;

namespace Tests.Audio.Installer
{
    [TestFixture]
    public class AudioMonoInstallerTests : ZenjectUnitTestFixture
    {
        [Test]
        public void Bindings_ShouldContainAudioEventCollection()
        {
            //Arange.
            SignalBusInstaller.Install(Container);
            Container.Bind<IAudioEventScriptAbleObjectCollection>().To<AudioEventScriptAbleObjectCollection>().AsSingle();

            //Act.
            var audioEventScriptAbleObject = Container.Resolve<IAudioEventScriptAbleObjectCollection>();

            //Assert.
            Assert.NotNull(audioEventScriptAbleObject);
        }

        [Test]
        public void Bindings_ShouldContainSignalBus()
        {
            // Arrange.
            SignalBusInstaller.Install(Container);
            Container.Inject(this);

            // Act.
            var signalBus = Container.Resolve<SignalBus>();

            // Assert.
            Assert.NotNull(signalBus);
        }

        [Test]
        public void Bindings_CanFire_PlayAudioSignal()
        {
            // Arrange.
            var received = false;
            SignalBusInstaller.Install(Container);
            Container.Inject(this);

            Container.DeclareSignal<PlayAudioSignal>();
            Container.BindSignal<PlayAudioSignal>().ToMethod(() => { received = true; });
            Container.ResolveRoots();

            var signalBus = Container.Resolve<SignalBus>();
            // Act.
            signalBus.Fire(new PlayAudioSignal());

            // Assert.
            Assert.IsTrue(received);
        }
    }
}
