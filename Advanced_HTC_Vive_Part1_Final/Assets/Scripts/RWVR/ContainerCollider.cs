using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == gameObject.tag)
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
       }
    }
}
