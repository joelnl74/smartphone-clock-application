using UnityEngine;

namespace Audio
{
    public class AudioSystem : MonoBehaviour
        ,IAudioSystem
    {
        [SerializeField] private AudioSource _audioSource;

        public void Play(AudioEventScriptAbleObject audioEventScriptAbleObject)
            => _audioSource.PlayOneShot(audioEventScriptAbleObject.audioClip);
    }
}
