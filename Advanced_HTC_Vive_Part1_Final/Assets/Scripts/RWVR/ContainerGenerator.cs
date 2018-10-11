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
            Quaternion rotat = transform.rotation;
            temp.z += 0.25f*(count+1);
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

                Instantiate(tempObj, temp, rotat);
                tempObj.transform.parent = container.transform;

                tempObj = null;
            }
            count++;
        }
    }
  
}
