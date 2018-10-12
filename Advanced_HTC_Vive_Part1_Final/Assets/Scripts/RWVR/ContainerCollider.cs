using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == gameObject.tag)
        {
            Transform solutionObject = gameObject.transform;
            
            Debug.Log("Child!");

            solutionObject.GetChild(5).gameObject.SetActive(true);
            Debug.Log("Count :" + solutionObject.childCount);

            //Debug.Log(gameObject.transform.GetChild(0));
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
       }
    }
}
