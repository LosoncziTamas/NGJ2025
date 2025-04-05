using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropTask : MonoBehaviour
{
    public Canvas TaskCanvas;
    bool inTrigger;
    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        TaskCanvas.enabled = false;
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                FinishPropTask();
            }
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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
        HidePropUI();
        PlayPropEffect();        
        inTrigger = false;

        //increment Total Tasks Done
        GameManager.GetComponent<TaskManager>().UpdateTaskCounter();
    }
}
