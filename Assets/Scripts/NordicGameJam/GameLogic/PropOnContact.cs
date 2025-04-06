using UnityEngine;

namespace NordicGameJam.GameLogic
{
    public class PropOnContact : MonoBehaviour
    {
        public float SoundAmount;
        public GameObject GameManager;
        
        bool istouched = false;

        //whether object will break after 1st contact
        public bool isFragile;

        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log(collision.gameObject.tag);
            if (collision.gameObject.CompareTag("Player") && istouched == false)
            {
                GameManager.GetComponent<NoiseManager>().UpdateSlider(SoundAmount);

                PlaySound();

                if (isFragile)
                {
                    istouched = true;
                    KillObject();
                }
            }
        }

        void PlaySound()
        {

        }
    
        private void KillObject()
        {
            Destroy(gameObject, 5);
        }
    }
}
