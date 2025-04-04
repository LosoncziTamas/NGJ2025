using UnityEngine;

namespace NordicGameJam
{
    [CreateAssetMenu]
    public class NoiseProps : ScriptableObject
    {
        [Range(0, 10)]
        public float NoiseLevel;
        public float Volume;
        public AudioClip ClipToPlay;
    }
}