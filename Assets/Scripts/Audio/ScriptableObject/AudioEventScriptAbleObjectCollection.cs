using Audio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "Audio/EventCollection")]
    public class AudioEventScriptAbleObjectCollection : ScriptableObject
        ,IAudioEventScriptAbleObjectCollection
    {
        [SerializeField] private List<AudioEventScriptAbleObject> _audioEvents;

        public AudioEventScriptAbleObject Get(AudioType audioType)
            => _audioEvents.FirstOrDefault(x => x.audioType == audioType);
    }
}
