using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    AudioSource audioData;
    //ParticleSystem particleSystem;
    
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        //particleSystem.GetComponent<ParticleSystem>().enableEmission = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("DoDestroyBox");
        }
    }

    IEnumerator DoDestroyBox()
    {
        while (true)
        {
            
            print("box hit");
            audioData.Play(0);
            Debug.Log("Beep");
            yield return new WaitForSeconds(0.5f);
            //this.transform.localScale = new Vector3(0f, 0f, 0f);
            //particleSystem.GetComponent<ParticleSystem>().enableEmission = true; //particle effect
            //transform mesh & collider
            Destroy(this.gameObject);
            //destroy self
            yield break;
        }
    }
    
}
