using UnityEngine;

namespace NordicGameJam.Character
{
    public class RagdollControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody _leftLeg;
        [SerializeField] private Rigidbody _rightLeg;
        [SerializeField] private Rigidbody _hip;

        private Vector3 _originalPosition;
        private Quaternion _originalOrientation;
        
        [SerializeField] private float _speed;

        private void Start()
        {
            _originalPosition = _hip.transform.localPosition;
            _originalOrientation = _hip.transform.localRotation;
        }
    }
}