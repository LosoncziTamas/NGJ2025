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

        private string text1 = "You really should think about cutting \n down on the late nights.";
        private string text2 = "But here you are again, it’s 4AM and\n your roommates are fast asleep for\n their early morning shifts.";
        private string text3 = "Are you quiet as a mouse? Or loud as a laptop running a AAA game?";
        private string text4 = "Master your unreliable, alcohol-soaked motor skills to stumble through your home and get yourself to bed.";
        private string text5 = "Just make sure not to wake your roommates (and beware the cat!) ";

        [SerializeField] private float _duration = 3.0f;
        [SerializeField] private float _waitDuration = 2.0f;
        [SerializeField] private float _reverseDuration = 1.5f;
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
            yield return AnimateTextWaitAndReverse(text4, duration, reverseDuration, waitTime);
            yield return AnimateTextWaitAndReverse(text5, duration, reverseDuration, waitTime);

            yield return new WaitForSeconds(1.0f);
        }
        
        private IEnumerator AnimateTextWaitAndReverse(string text, float duration, float reverseDuration, float waitTime)
        {
            var tween = _text.DOText(text, duration).SetEase(Ease.InOutSine).SetAutoKill(false);
            yield return tween.WaitForCompletion();
            yield return new WaitForSeconds(waitTime);
            tween.timeScale = duration / reverseDuration;
            tween.PlayBackwards();
            yield return new WaitForSeconds(reverseDuration);
        }
        
        private IEnumerator AnimateTextAndWaitForButtonClickBeforeReverse(string text, float duration, float reverseDuration)
        {
            var tween = _text.DOText(text, duration).SetEase(Ease.InOutSine).SetAutoKill(false);
            yield return tween.WaitForCompletion();
            tween.timeScale = duration / reverseDuration;
            tween.PlayBackwards();
            yield return new WaitForSeconds(reverseDuration);
        }

        private void GoToNextScene()
        {
            _skipButton.interactable = false;
            SceneManager.LoadScene("Movement");
        }
    }
}