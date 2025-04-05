using DG.Tweening;
using UnityEngine;

namespace NordicGameJam.UI
{
    public class BlurryVision : MonoBehaviour
    {
        private static readonly int BlurSizeProperty = Shader.PropertyToID("_Size");
        
        [SerializeField] private Material _blurMaterial;
        [SerializeField] private float _maxBlur;
        [SerializeField] private float _time;
        [SerializeField] private Ease _ease;

        private Tweener _blurTweener;

        private void OnDisable()
        {
            _blurTweener?.Kill();
        }

        private void OnEnable()
        {
            LoopBlur();
        }

        public void LoopBlur()
        {
            _blurTweener = DOVirtual.Float(0.0f, _maxBlur, _time, OnBlurUpdate)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(_ease);
        }

        private void OnBlurUpdate(float value)
        {
            _blurMaterial.SetFloat(BlurSizeProperty, value);
        }
    }
}
