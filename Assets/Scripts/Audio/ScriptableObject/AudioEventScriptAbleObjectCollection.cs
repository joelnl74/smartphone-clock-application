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

        /// <summary>
        /// Get audio defintion from collection.
        /// </summary>
        /// <param name="audioType">Audio type you wish to retrieve.</param>
        /// <returns></returns>
        public AudioEventScriptAbleObject Get(AudioType audioType)
            => _audioEvents.FirstOrDefault(x => x.audioType == audioType);
    }
}
