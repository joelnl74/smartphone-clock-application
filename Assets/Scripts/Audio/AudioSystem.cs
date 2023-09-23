using Audio.Interfaces;
using UnityEngine;
using Zenject;

namespace Audio
{
    public class AudioSystem : MonoBehaviour
        ,IAudioSystem
    {
        [SerializeField] private AudioSource _audioSource;

        private IAudioEventScriptAbleObjectCollection collection;

        [Inject]
        public void Constructor(IAudioEventScriptAbleObjectCollection audioEventScriptAbleObjectCollection)
            => collection = audioEventScriptAbleObjectCollection;

        /// <summary>
        /// Play audio clip.
        /// </summary>
        /// <param name="playAudio"></param>
        public void Play(PlayAudioSignal playAudio)
            => _audioSource.PlayOneShot(collection.Get(playAudio.audioType).audioClip);
    }
}
