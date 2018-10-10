using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

    public float destroyTime = 5.0f;

   // private float rotateSpeed = 80.0f;

	// Use this for initialization
	void Start () {
     Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
      //  Destroy(gameObject, destroyTime);
    }
}
