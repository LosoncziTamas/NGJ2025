using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Microwave : MonoBehaviour
{
    private int Timer;

    private void Start()
    {
         Timer = 60;
        IEnumerator timerCo;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void timerStart()
    {
        gameObject.GetComponentInChildren<Canvas>().enabled = true;

       StartCoroutine(timerCo());
    }

    IEnumerator timerCo()
    {
        while(Timer != 0)
        {
            Timer--;

            gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = Timer.ToString();
            yield return new WaitForSeconds(1);
        }      
    }
}
