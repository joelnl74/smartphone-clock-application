using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "Audio/Event")]
    public class AudioEventScriptAbleObject : ScriptableObject
    {
        [field: SerializeField] public AudioClip audioClip;
    }
}

