using DG.Tweening;
using NordicGameJam.Audio;
using NordicGameJam.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NordicGameJam.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;
        [SerializeField] private DOTweenAnimation _animation;
        [SerializeField] private TextMeshProUGUI _title;

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
        
        public void Show(bool win)
        {
            _title.text = win ? "Nice Job!" : "Game Over";
            if (!win)
            {
                SimpleAudioManager.Instance.PlayOneShot(AudioClipType.AngryMan);
            }
            gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}