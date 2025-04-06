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
        private bool _cooldownRunning;

        private void Start()
        {
            _gameOverPanel = FindObjectOfType<GameOverPanel>(includeInactive: true);
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
            if (GUILayout.Button(""))
            {
                
            }
            if (GUILayout.Button(""))
            {
                
            }
        }

        public void UpdateSlider(float newValue)
        {
            SoundSlider.value += newValue;
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