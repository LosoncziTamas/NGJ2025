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

    //whether object will break after 1st contact
    public bool isFragile;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);

        //send score to sound metre
        if (collision.gameObject.tag == "Player" && istouched == false)
        {
            GameManager.GetComponent<NoiseManager>().UpdateSlider(SoundAmount);

            PlaySound();

            if (isFragile == true)
            {
                istouched = true;
                StartCoroutine(KillObject());
            }
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
