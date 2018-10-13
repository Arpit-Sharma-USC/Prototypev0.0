using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        char match_first = (collision.gameObject.name)[0];
        string temp_str = match_first.ToString();

        if (temp_str == gameObject.tag)
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
