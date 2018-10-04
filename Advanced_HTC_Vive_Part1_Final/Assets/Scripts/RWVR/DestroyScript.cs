using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

    private float destroyTime = 20.0f;
    //gameParametersContainer.gameParam.respawnTime;Debug.Log ;//+gameParametersContainer.gameParam.respawnTime);

   // private float rotateSpeed = 80.0f;

	// Use this for initialization
	void Start () {
        if(!(gameParametersContainer.gameParam==null))
            destroyTime = float.Parse(gameParametersContainer.gameParam.respawnTime);

        Destroy(gameObject, destroyTime);
        Debug.Log(destroyTime+"Destroy time");
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
      //  Destroy(gameObject, destroyTime);
    }
}
