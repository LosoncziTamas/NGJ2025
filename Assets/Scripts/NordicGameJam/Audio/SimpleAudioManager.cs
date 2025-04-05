using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NordicGameJam.Audio
{
    public class SimpleAudioManager : MonoBehaviour
    {
        private const string SceneWithAmbientAudio = "Tutorial";
        public static SimpleAudioManager Instance { get; private set; }
        
        [SerializeField] private AudioSource _ambient;
        [SerializeField] private AudioSource _ui;
        [SerializeField] private AudioSource _oneShot;

        [SerializeField] private List<AudioClipEntry> _audioClips;

        private void Awake()
        {
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode args)
        {
            if (string.Equals(scene.name, SceneWithAmbientAudio))
            {
                _ambient.DOFade(1.0f, 0.4f);
            }
        }

        public void PlayClip(AudioClip audioClip, float volume = 1.0f)
        {
            _oneShot.PlayOneShot(audioClip, volume);
        }
        
        public void PlayOneShot(AudioClipType type)
        {
            var clipEntry = _audioClips.FirstOrDefault(entry => entry.Type == type);
            if (clipEntry != null)
            {
                _oneShot.PlayOneShot(clipEntry.Clip);
            }
        }

        public void PlayClick()
        {
            var clipEntry = _audioClips.FirstOrDefault(entry => entry.Type == AudioClipType.UIClick);
            _ui.clip = clipEntry.Clip;
            _ui.Play();
        }
        
        public void PlayHover()
        {
            var clipEntry = _audioClips.FirstOrDefault(entry => entry.Type == AudioClipType.UIHover);
            _ui.clip = clipEntry.Clip;
            _ui.Play();
        }
    }
}
