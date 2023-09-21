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
    }
}