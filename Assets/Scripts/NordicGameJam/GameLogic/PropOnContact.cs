using NordicGameJam.Audio;
using UnityEngine;

namespace NordicGameJam.GameLogic
{
    public class PropOnContact : MonoBehaviour
    {
        private const int KillDelay = 5;
        
        [SerializeField] private NoiseProps _noiseProps;
        
        private bool _isTouched = false;
        
        public bool isFragile;

        private NoiseManager _noiseManager;

        private void Awake()
        {
            _noiseManager = FindObjectOfType<NoiseManager>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.CompareTag("Player") && _isTouched == false)
            {
                _noiseManager.UpdateSlider(_noiseProps.NoiseLevel);
                PlaySound();
                if (isFragile)
                {
                    _isTouched = true;
                    KillObject();
                }
            }
        }

        private void PlaySound()
        {
            SimpleAudioManager.Instance.PlayClip(_noiseProps.ClipToPlay, _noiseProps.Volume);
        }
    
        private void KillObject()
        {
            Destroy(gameObject, KillDelay);
        }
    }
}
