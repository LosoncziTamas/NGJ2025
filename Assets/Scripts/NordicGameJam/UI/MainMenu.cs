using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NordicGameJam.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;

        private void OnEnable()
        {
            _start.onClick.AddListener(OnStartButtonClick);
            _exit.onClick.AddListener(OnExitButtonClick);
        }
        
        private void OnDisable()
        {
            _start.onClick.RemoveListener(OnStartButtonClick);
            _exit.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnStartButtonClick()
        {
            _start.interactable = _exit.interactable = false;
            SceneManager.LoadScene("Tutorial");
        }
        
        private void OnExitButtonClick()
        {
            _start.interactable = _exit.interactable = false;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
