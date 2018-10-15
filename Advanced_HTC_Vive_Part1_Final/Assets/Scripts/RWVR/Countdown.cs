﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    [SerializeField] private Text uiText;
    [SerializeField] private int mainTimer;
    GameObject myItem1;
    GameObject myItem2;
    GameObject myItem3;
    GameObject myItem4;

    GameObject scoreDigit;

    private int timer;
    private bool canCount = true;
    private bool doOnce = false;
    private int pseudoTimer = 100;
    GameObject dest1;
    GameObject dest2;
    GameObject dest3;
    GameObject dest4;

    void Start()
    {
        timer = mainTimer;

        scoreDigit = (Instantiate(Resources.Load("Digit_0")) as GameObject);
        scoreDigit.transform.position = new Vector3(4.66f, 8.62f, -13.00f);

        Vector3 temp = scoreDigit.transform.rotation.eulerAngles;
        temp.y = -183.96f;
        scoreDigit.transform.rotation = Quaternion.Euler(temp);

        //scoreDigit.transform.localScale += new Vector3(2f, 2f, 2f);
        scoreDigit.tag = "Scoredigit";


    }


    void Update()
    {
        if (pseudoTimer == 0)
        {
            HandleIt();
            pseudoTimer = 100;
        }
        pseudoTimer -= 1;
    }


    void HandleIt()
    {
        if (timer >= 0 && canCount)
        {
            //uiText.text = timer.ToString("F");
            //int decimalPart = (int)timer % 1;
            //Debug.Log(decimalPart);
            int modifiedTimer = timer + 1;
            //timer.ToString("F");
            if (timer != 9)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("digit");

                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
                //dest1 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                //Debug.Log("Destroy 1:" + dest1);
                //Destroy(dest1);

                //dest2 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                //Debug.Log("Destroy 2:" + dest2);
                //Destroy(dest2);

                //dest3 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                //Debug.Log("Destroy 3:" + dest3);
                //Destroy(dest3);

                //dest4 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                //Debug.Log("Destroy 4:" + dest4);
                //Destroy(dest4);

                //Debug.Log(dest);

            }
            Debug.Log(timer);
            myItem1 = (Instantiate(Resources.Load("Digit_" + timer)) as GameObject);
            myItem1.transform.position = new Vector3(0.15f, 9.67f, 13.92f);
            myItem1.transform.localScale+=new Vector3(2f,2f,2f);
            myItem1.tag = "digit";
            Debug.Log("Item1 is:" + myItem1);

            myItem2 = (Instantiate(Resources.Load("Digit_" + timer)) as GameObject);
            myItem2.transform.position = new Vector3(12.07f, 8.3f, 1.61f);
            Vector3 temp = myItem2.transform.rotation.eulerAngles;
            temp.y = 87.78f;
            myItem2.transform.rotation = Quaternion.Euler(temp);
            myItem2.transform.localScale += new Vector3(2f, 2f, 2f);

            myItem2.tag = "digit";

            Debug.Log("Item2 is:" + myItem2);

            myItem3 = (Instantiate(Resources.Load("Digit_" + timer)) as GameObject);
            myItem3.transform.position = new Vector3(0.15f, 9.67f, -11.71f);

            temp = myItem3.transform.rotation.eulerAngles;
            temp.y = 187.00f;
            myItem3.transform.rotation = Quaternion.Euler(temp);
            myItem3.transform.localScale += new Vector3(2f, 2f, 2f);

            myItem3.tag = "digit";

            Debug.Log("Item3 is:" + myItem3);

            myItem4 = (Instantiate(Resources.Load("Digit_" + timer)) as GameObject);
            myItem4.transform.position = new Vector3(-13.16f, 8.06f, 0.31f);

            temp = myItem4.transform.rotation.eulerAngles;
            temp.y = -90.78f;
            myItem4.transform.rotation = Quaternion.Euler(temp);
            myItem4.transform.localScale += new Vector3(2f, 2f, 2f);


            myItem4.tag = "digit";

            Debug.Log("Item4 is:" + myItem4);

            timer -= 1;

            //Debug.Log("Item is:"+myItem);
        }
        else if (timer <= 0 && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0";
            timer = 1;
        }
    }
    public void ResetBtn()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false;

    }

}