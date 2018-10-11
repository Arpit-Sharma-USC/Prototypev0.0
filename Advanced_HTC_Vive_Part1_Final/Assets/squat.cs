using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class squat : MonoBehaviour {

    public AudioClip theAudioClipName;
    private int playOnce = 0;
    // Use this for initialization


    void OnTriggerEnter(Collider other)
    {
        
        //GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().playOnAwake = false;
        
        if(++playOnce<2)
            GetComponent<AudioSource>().PlayOneShot(theAudioClipName,0.7f);//(theAudioClipName, transform.position);
           
        //GetComponent<AudioSource>().Play();
      //  playOnce = false;



    }
}
