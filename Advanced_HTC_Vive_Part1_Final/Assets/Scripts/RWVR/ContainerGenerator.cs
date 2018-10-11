using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGenerator : MonoBehaviour {

    public GameObject container;
    public int length = 0;
    private int count = 0;
    //private SendInputString Obj;
    string inputChild;
    string myTag;

    public GameObject A;
    public GameObject B;
    public GameObject C;

    public void Start()
    {
        GameObject Parent = GameObject.Find("Parent");

        SendInputString ParentInputObject = Parent.GetComponent<SendInputString>();
        inputChild = ParentInputObject.input;
        Parent.SetActive(false);
        //SendInputString.input = "";

        length = inputChild.Length;
        Debug.Log("message recieved is"+inputChild);
        CreateContainers();
    }
    

    /// <summary>
    /// creates container boxes
    /// </summary>
    public void CreateContainers () {
        //update value of y for multiple words on the "space" letter
       while (length > count)
        {
            Vector3 temp = transform.position;
            Vector3 temp2 = transform.position;
            Quaternion rotat = transform.rotation;
            temp.z += 0.25f*(count+1);
            temp2 = temp;
            //temp.y = 2;
            myTag = inputChild[count].ToString();

            container.tag = this.myTag;
            Instantiate(container, temp, rotat);
            GameObject tempObj = null;
            int flag = 0;
            if (myTag == "A")
            {
                tempObj = A;
                flag = 1;
            }
            else if (myTag == "B")
            {
                tempObj = B;
                flag = 1;
            }
            else if (myTag == "C")
            {
                tempObj = C;
                flag = 1;
            }

            if (flag == 1)
            {
                tempObj.tag = myTag;
                tempObj.SetActive(true);
                temp2.x+= 0.198f-0.092f;
                temp2.y+= -0.121f+0.055f;
                temp2.z+= 0.242f-0.125f;
                Instantiate(tempObj, temp2, rotat);
                Debug.Log("position of child is " + tempObj.transform.position);
                Debug.Log("position is "+temp);
                tempObj.transform.parent = container.transform;
                tempObj.transform.position = container.transform.position;
                //tempObj.transform.localPosition = new Vector3(0, 0, 0);
               // Instantiate(tempObj, temp, rotat);
                tempObj = null;
            }
            count++;
        }
    }
}
