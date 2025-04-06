using UnityEngine;

namespace NordicGameJam
{
    public class Cat : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void TransitionToRun()
        {
            // _animator.CrossFade();
        }

        public void TransitionToJump()
        {
            
        }
    }
}