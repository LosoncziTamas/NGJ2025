using DG.Tweening;
using NordicGameJam.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NordicGameJam.UI
{
    [RequireComponent(typeof(Button))]
    public class GameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Button _button;

        [Header("Anim properties")] 
        [SerializeField] private float _scale = 1.2f;
        [SerializeField] private float _duration = 0.4f;
        [SerializeField] private Ease _ease = Ease.InOutSine;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
        
        private void OnButtonClick()
        {
            SimpleAudioManager.Instance.PlayClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _button.transform.DOScale(Vector3.one * _scale, _duration).SetEase(_ease);
            SimpleAudioManager.Instance.PlayHover();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _button.transform.DOScale(Vector3.one, _duration).SetEase(_ease);
        }
    }
}