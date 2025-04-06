using NordicGameJam.Audio;
using NordicGameJam.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace NordicGameJam.GameLogic
{
    public class PropTask : MonoBehaviour
    {
        public Canvas TaskCanvas;
        bool inTrigger;
        bool iscomplete;
        public GameObject GameManager;
        public bool isFinalTask = false;
        private GameOverPanel g;

        // Start is called before the first frame update
        void Start()
        {
            bool iscomplete = false;
            TaskCanvas.enabled = false;
            inTrigger = false;
            g = FindObjectOfType<GameOverPanel>(true);
        }

        // Update is called once per frame
        void Update()
        {
            if(inTrigger && iscomplete ==false)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    FinishPropTask();

                    if(isFinalTask == true)
                    {
                        g.Show(true);
                    }
                }
            
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.gameObject.tag == "Player" && iscomplete == false)
            {
                inTrigger = true;
                DisplayPropUI();
            }      
        }

        private void OnTriggerExit(Collider collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                inTrigger = false;
                HidePropUI();
            }
        }
        void DisplayPropUI()
        {
            TaskCanvas.enabled = true;
        }

        void HidePropUI()
        {
            TaskCanvas.enabled = false;
        }

        void PlayPropEffect()
        {

        }

        void FinishPropTask()
        {

            SimpleAudioManager.Instance.PlayOneShot(AudioClipType.UIClick);
            HidePropUI();
            PlayPropEffect();        
            inTrigger = true;

            iscomplete = true;
            //increment Total Tasks Done
            GameManager.GetComponent<TaskManager>().UpdateTaskCounter();
        }
    }
}
