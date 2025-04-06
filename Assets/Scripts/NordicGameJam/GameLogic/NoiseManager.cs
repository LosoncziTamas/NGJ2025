using System;
using System.Collections;
using NordicGameJam.UI;
using UnityEngine;
using UnityEngine.UI;

namespace NordicGameJam.GameLogic
{
    public class NoiseManager : MonoBehaviour
    {
        public Slider SoundSlider;

        public float CooldownAmount;
        public int CooldownDelay;
        
        private GameOverPanel _gameOverPanel;
        private TakeDamageOverlay _takeDamageOverlay;
        private bool _cooldownRunning;

        private void Start()
        {
            _gameOverPanel = FindObjectOfType<GameOverPanel>(includeInactive: true);
            _takeDamageOverlay = FindObjectOfType<TakeDamageOverlay>();
            StartCoroutine(Cooldown(CooldownDelay));
        }

        private void Update()
        {
            if (SoundSlider.value >= SoundSlider.maxValue)
            {
                MetreFilled();
            }
        }

        private IEnumerator Cooldown(int time)
        {
            _cooldownRunning = true;
            while (_cooldownRunning)
            {
                UpdateSlider(CooldownAmount);
                yield return new WaitForSeconds(time);
            }
        }

        private void OnGUI()
        {
            GUILayout.Space(100);
            if (GUILayout.Button("UpdateSlider"))
            {
                UpdateSlider(10);
            }
        }

        public void UpdateSlider(float valueToAdd)
        {
            if (valueToAdd > 0)
            {
                _takeDamageOverlay.OnDamage();
            }
            SoundSlider.value += valueToAdd;
            SoundSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =
                Color.Lerp(Color.green, Color.red, SoundSlider.value / 100);
        }

        private void MetreFilled()
        {
            _cooldownRunning = false;
            _gameOverPanel.Show();
        }
    }
}