using UnityEngine;

namespace Audio
{
    public enum AudioType
    {
        None = 0,
        Alarm = 1
    }

    [CreateAssetMenu(menuName = "Audio/Event")]
    public class AudioEventScriptAbleObject : ScriptableObject
    {
        [field: SerializeField] public AudioType audioType;
        [field: SerializeField] public AudioClip audioClip;
    }
}

