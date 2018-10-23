using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGenerator : MonoBehaviour {

    public GameObject container;
<<<<<<< HEAD
    public int length = 0;
    private int count = 0;
=======
    public GameObject parentContainer;
    public int[] bitMapSubString;
    public int length = 0;
    private int count = 0;

  //  public int No_of_blanks;


    String SubStringQuestion;

    //System.Random rnd = new System.Random();

>>>>>>> 366a4321704ce7c02f4dd1da419aa009951f5488
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
<<<<<<< HEAD
=======

        /*
         * if(dificulty.value=="easy")
         *      No_of_blanks=seteasy();
         *  else if(dificulty.value=="medium").
         *      No_of_blanks=setmedium();
         *  else
         *      No_of_blanks=sethard();


         */
        //if (No_of_blanks >= length - 2)
        //    No_of_blanks = length / 2;

        //Debug.Log("No Blanks:" + No_of_blanks);
        //ContainerCollider.setBlanks(No_of_blanks);
        //Countdown.setBlanksInCountdown(No_of_blanks);


        //Debug.Log("No Blanks:" + No_of_blanks);
        //SubStringQuestion = inputChild.Substring(1, length - 2);

        bitMapSubString = ParentInputObject.bitMapSubString;

        //for (int i = 0; i < bitMapSubString.Length ; i++)
        //{
        //    bitMapSubString[i] = 1;

        //}

        //int rand_id;

        //while (No_of_blanks!=0)
        //{
        //    rand_id = rnd.Next(1, length - 1);
        //    if (bitMapSubString[rand_id] != 0)
        //    {
        //        bitMapSubString[rand_id] = 0;
        //        No_of_blanks--;

        //    }
        //}





        SetContainerPhysics();
>>>>>>> 366a4321704ce7c02f4dd1da419aa009951f5488
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
                tempObj.transform.parent = container.transform;
                tempObj.transform.position = container.transform.position;

                Instantiate(tempObj, temp2, rotat);

              //  container.transform.GetChild(0).gameObject.SetActive(true);
                //Debug.Log("Child"+container.transform.GetChild(0));

           
              
                tempObj = null;
            }
            count++;
        }
    }
}
