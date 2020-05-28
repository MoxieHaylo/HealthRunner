using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int healthMax = 100;
    private int healthCurrent;
    private int healthBoxHit;
    private int healthBoxHeal;
    public bool isAlive;
    public Text countdownText;
    AudioSource audioData;
    public ParticleSystem particleHurt;
    public ParticleSystem particleHeal;


    // put health functions into state machine at some point

    void Start()
    {
        isAlive = true;
        healthCurrent = healthMax;
        audioData = GetComponent<AudioSource>();
        StartCoroutine("LoseHealth");
    }


    void Update()
    {
        countdownText.text = ("Health" + healthCurrent);

        healthBoxHit = healthCurrent / 5;
        healthBoxHeal = healthMax / 2;
        healthBoxHeal = healthBoxHeal++;

        if (healthCurrent <= 0)
        {
            isAlive = false;
            StopCoroutine("LoseHealth");
            countdownText.text = "You Died";
        }

        //prevents the health bar from growing infinitely
        if (healthCurrent >= healthMax)
        {
            healthCurrent = healthMax;
        }
    }     

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HealthBox")
        {
            StartCoroutine("DoHealthBox");
        }
    }

    IEnumerator LoseHealth()
    {
        while (true)
        {
            //removes one point per second
            yield return new WaitForSeconds(1);
            healthCurrent--;
        }
    }

    IEnumerator DoHealthBox()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            print("Doing HealthBox");
            healthCurrent = healthCurrent - healthBoxHit; //calculates how much damage to do
            particleHurt.Play();
            yield return new WaitForSeconds(15);
            audioData.Play(0);
            particleHeal.Play();
            healthCurrent = healthCurrent + healthBoxHeal; //restores health
            yield break;
        }
    }
}
