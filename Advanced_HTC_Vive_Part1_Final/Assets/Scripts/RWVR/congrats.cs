using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class congrats : MonoBehaviour
{

    GameObject winChar;
    // Use this for initialization
    void Start()
    {
        Material newMat = Resources.Load("UA_Cover", typeof(Material)) as Material;

        string s = "Congratulations!!";
        float increment = 0f;

        for(int i = 0; i < s.Length; i++)
        {
            char letterNow = s[i];
            winChar = (Instantiate(Resources.Load("G0_"+i+"_"+letterNow)) as GameObject);
            winChar.transform.position = new Vector3(20.00f, 5.00f, 14.00f-increment);
            Vector3 temp = winChar.transform.rotation.eulerAngles;
            temp.y = 92.00f;
            winChar.transform.rotation = Quaternion.Euler(temp);
            winChar.transform.localScale += new Vector3(2f, 2f, 2f);
            winChar.tag = "winChar";
            winChar.GetComponent<Renderer>().material = newMat;
            increment += 1.75f;
        }
        /*
        winChar = (Instantiate(Resources.Load("G0_0_C")) as GameObject);
        winChar.transform.position = new Vector3(20.00f,5.00f,14.00f);
        //Vector3 temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_1_o")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 12.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_2_n")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 11.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_3_g")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 9.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_4_r")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 8.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_5_a")) as GameObject);
        winChar.transform.position = new Vector3(20.00f,5.00f,6.50f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_6_t")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 5.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_7_u")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 3.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_8_l")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 2.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_9_a")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, 0.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_10_t")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -1.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_11_i")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -2.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_12_o")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -4.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_13_n")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -5.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_14_s")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -7.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_15_!")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -8.50f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_16_!")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -10.00f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;

        winChar = (Instantiate(Resources.Load("G0_17_!")) as GameObject);
        winChar.transform.position = new Vector3(20.00f, 5.00f, -11.5f);
        //temp = winChar.transform.rotation.eulerAngles;
        //temp.y = 87.78f;
        //winChar.transform.rotation = Quaternion.Euler(temp);
        //winChar.transform.localScale += new Vector3(2f, 2f, 2f);
        winChar.tag = "winChar";
        winChar.GetComponent<Renderer>().material = newMat;
        */




    }

    // Update is called once per frame
    void Update()
    {

    }
}