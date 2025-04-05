using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void EnableGameOverScreen()
    {
        //disable player movement and enable UI
        Cursor.lockState = CursorLockMode.None;
        Player.SetActive(false);

        gameObject.GetComponent<NoiseManager>().enabled = false;
        gameObject.GetComponent<TaskManager>().enabled = false;

        gameObject.GetComponentInChildren<Canvas>().enabled = true;
    }

   
}
