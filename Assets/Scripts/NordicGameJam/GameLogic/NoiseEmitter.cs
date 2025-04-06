using NordicGameJam.Audio;
using UnityEngine;

namespace NordicGameJam.GameLogic
{
    public class NoiseEmitter : MonoBehaviour
    {
        [SerializeField] private NoiseProps _noiseProps;
        
        public void EmitNoise()
        {
            SimpleAudioManager.Instance.PlayClip(_noiseProps.ClipToPlay, _noiseProps.Volume);
        }

        private void OnTriggerEnter(Collider other)
        {
            // TODO: check layers
            EmitNoise();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            // TODO: check layers
            EmitNoise();
        }
    }
}