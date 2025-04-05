using System;
using DG.Tweening;
using NordicGameJam.Audio;
using UnityEngine;

namespace NordicGameJam.UI
{
    public class TakeDamageOverlay : MonoBehaviour
    {
        [SerializeField] private DOTweenAnimation _animation;
        [SerializeField] private bool _debug;

        public void OnDamage()
        {
            _animation.DORestart();
            _animation.DOPlay();
            SimpleAudioManager.Instance.PlayOneShot(AudioClipType.Hiccup);
        }

        private void OnGUI()
        {
            if (!_debug)
            {
                return;
            }
            if (GUILayout.Button("Take damage"))
            {
                OnDamage();
            }
        }
    }
}
