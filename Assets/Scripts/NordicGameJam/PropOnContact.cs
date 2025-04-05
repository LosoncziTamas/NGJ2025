using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropOnContact : MonoBehaviour
{
    public GameObject objectCollider;

    public float SoundAmount;

    public GameObject GameManager;

    public GameObject Player;

    bool istouched = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        //send score to sound metre
        if(collision.gameObject.tag =="Player" && istouched == false)
        {
            istouched = true;
            Debug.Log("Player touched Object");

            GameManager.GetComponent<NoiseManager>().UpdateSlider(SoundAmount);

            PlaySound();           

            StartCoroutine(KillObject());            
        }        
    }

    void PlaySound()
    {

    }


    IEnumerator KillObject()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
}
