using UnityEngine;

namespace NordicGameJam.GameLogic
{
    [CreateAssetMenu]
    public class NoiseProps : ScriptableObject
    {
        [Range(0, 100)]
        public float NoiseLevel;
        public float Volume;
        public AudioClip ClipToPlay;
    }
}