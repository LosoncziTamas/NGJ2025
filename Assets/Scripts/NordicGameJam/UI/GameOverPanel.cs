using DG.Tweening;
using NordicGameJam.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            _backToMenu.interactable = false;
            SceneManager.LoadScene(SceneNames.MainMenu);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}