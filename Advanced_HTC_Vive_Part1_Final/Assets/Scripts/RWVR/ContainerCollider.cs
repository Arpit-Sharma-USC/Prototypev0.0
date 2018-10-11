using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == gameObject.tag)
        {
            Transform A = gameObject.transform;
            
            Debug.Log("Child!");
            A.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Count :" + A.childCount);

            //Debug.Log(gameObject.transform.GetChild(0));
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
       }
    }
}
