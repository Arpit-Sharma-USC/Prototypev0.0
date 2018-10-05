using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGenerator : MonoBehaviour {

    public GameObject container;
    public int length = 5;
    private int count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        while (length > count)
        {
            Vector3 temp = transform.position;
            Quaternion rotat = transform.rotation;
            temp.z += 0.2f*(count+1);
            //temp.y = 2;
            Instantiate(container, temp, rotat);
            container.transform.parent = gameObject.transform;
            count++;
        }
    }
}
