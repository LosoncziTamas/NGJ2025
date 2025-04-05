using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace NordicGameJam.Audio
{
    public class SimpleAudioManager : MonoBehaviour
    {
        public static SimpleAudioManager Instance;
        
        [SerializeField] private AudioSource _ambient;
        [SerializeField] private AudioSource _ui;
        [SerializeField] private AudioSource _oneShot;

        [SerializeField] private List<AudioClipEntry> _audioClips;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _ambient.DOFade(1.0f, 0.4f);
        }

        public void PlayOneShot(AudioClipTypes type)
        {
            var clipEntry = _audioClips.FirstOrDefault(entry => entry.Type == type);
            if (clipEntry != null)
            {
                _oneShot.PlayOneShot(clipEntry.Clip);
            }
        }

        public void PlayClick()
        {
            var clipEntry = _audioClips.FirstOrDefault(entry => entry.Type == AudioClipTypes.UIClick);
            _ui.clip = clipEntry.Clip;
            _ui.Play();
        }

        public void PlayHover()
        {
            var clipEntry = _audioClips.FirstOrDefault(entry => entry.Type == AudioClipTypes.UIHover);
            _ui.clip = clipEntry.Clip;
            _ui.Play();
        }
    }
}
