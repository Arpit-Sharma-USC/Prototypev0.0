using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class squat : MonoBehaviour {


	// Use this for initialization
	

    void OnTriggerEnter(Collider other)
    {
            
        GetComponent<AudioSource>().Play();
            Debug.Log("Object entered the Trigger");
            //GetComponent<AudioSource>().Play();


    }
}
