using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace NordicGameJam.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;
        [SerializeField] private DOTweenAnimation _animation;

        private void OnEnable()
        {
            _backToMenu.onClick.AddListener(OnBackToMenuButtonClick);
        }
        
        private void OnDisable()
        {
            _backToMenu.onClick.RemoveListener(OnBackToMenuButtonClick);
        }

        private void OnBackToMenuButtonClick()
        {
            
        }


        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}