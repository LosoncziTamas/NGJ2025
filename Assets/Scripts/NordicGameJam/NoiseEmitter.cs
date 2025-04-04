using UnityEngine;

namespace NordicGameJam
{
    [RequireComponent(typeof(AudioSource))]
    public class NoiseEmitter : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private NoiseProps _noiseProps;

        private void OnValidate()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void EmitNoise()
        {
            _audioSource.PlayOneShot(_noiseProps.ClipToPlay, _noiseProps.Volume);
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