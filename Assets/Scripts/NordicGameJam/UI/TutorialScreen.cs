using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NordicGameJam.UI
{
    public class TutorialScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private string text1 = "You really should cut down on the late nights.";
        private string text2 = "But here you are again. 4AM, and your roommates are fast asleep.";
        private string text3 = "Better not wake them. So don’t stumble, and keep it quiet!";

        [SerializeField] private float _duration = 3.0f;
        [SerializeField] private float _waitDuration = 2.0f;
        [SerializeField] private float _reverseDuration = 0.4f;
        [SerializeField] private Button _skipButton;
        
        private IEnumerator Start()
        {
            yield return AnimateNewWelcomeText();
            GoToNextScene();
        }

        private void OnEnable()
        {
            _skipButton.onClick.AddListener(OnSkipButtonClick);
        }
        
        private void OnDisable()
        {
            _skipButton.onClick.RemoveListener(OnSkipButtonClick);
        }
        
        private void OnSkipButtonClick()
        {
            GoToNextScene();
        }
        
        private IEnumerator AnimateNewWelcomeText()
        {
            var duration = _duration;
            var reverseDuration = _reverseDuration;
            var waitTime = _waitDuration;
            
            yield return AnimateTextWaitAndReverse(text1, duration, reverseDuration, waitTime);
            yield return AnimateTextWaitAndReverse(text2, duration, reverseDuration, waitTime);
            yield return AnimateTextWaitAndReverse(text3, duration, reverseDuration, waitTime);
        }
        
        private IEnumerator AnimateTextWaitAndReverse(string text, float duration, float reverseDuration, float waitTime)
        {
            _text.DOFade(1.0f, 0.0f);
            var tween = _text.DOText(text, duration).SetEase(Ease.InOutSine).SetAutoKill(true);
            yield return tween.WaitForCompletion();
            yield return new WaitForSeconds(waitTime);
            yield return _text.DOFade(0.0f, reverseDuration).WaitForCompletion();
            _text.text = string.Empty;
        }
        
        private IEnumerator AnimateTextAndWaitForButtonClickBeforeReverse(string text, float duration, float reverseDuration)
        {
            _text.DOFade(1.0f, 0.0f);
            var tween = _text.DOText(text, duration).SetEase(Ease.InOutSine);
            yield return tween.WaitForCompletion();
            tween.timeScale = duration / reverseDuration;
            yield return _text.DOFade(0.0f, reverseDuration).WaitForCompletion();;
            _text.text = string.Empty;
        }

        private void GoToNextScene()
        {
            _skipButton.interactable = false;
            SceneManager.LoadScene("Movement");
        }
    }
}