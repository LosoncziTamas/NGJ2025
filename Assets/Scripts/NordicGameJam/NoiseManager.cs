using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoiseManager : MonoBehaviour
{
    public Slider SoundSlider;
    bool cooldownRunning;

    public float CooldownAmount;
    public int CooldownDelay;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Cooldown(CooldownDelay));
    }

    // Update is called once per frame
    void Update()
    {        
        //checks if metre filled
        if (SoundSlider.value >= SoundSlider.maxValue)
        {
            MetreFilled();
        }

    }

    IEnumerator Cooldown(int time)
    {
        cooldownRunning = true;

        //
        while(cooldownRunning == true)
        {
            UpdateSlider(CooldownAmount);
            yield return new WaitForSeconds(time);
        }
            
    }

    public void UpdateSlider(float newvalue)
    {
            //adds value to slider UI
        SoundSlider.value += newvalue;    
        SoundSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = 
            Color.Lerp(Color.green, Color.red, SoundSlider.value / 100);
        
    }
    void MetreFilled()
    {
        //send gameover
        Debug.Log("YOU LOSE!!!");

        gameObject.GetComponent<GameOver>().EnableGameOverScreen();
    }
}
