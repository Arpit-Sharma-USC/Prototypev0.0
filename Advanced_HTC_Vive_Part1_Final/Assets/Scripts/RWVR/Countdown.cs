using System.Collections;
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
    GameObject totalDigit;

    GameObject scoreDigit;

    private int timer;
    private bool canCount = true;
    private bool doOnce = false;
    private int pseudoTimer = 100;
    GameObject dest1;
    GameObject dest2;
    GameObject dest3;
    GameObject dest4;

    public static int blanks;

    GameObject scoreChar;

    void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ScoreDigit");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        timer = mainTimer;

        //scoreDigit = (Instantiate(Resources.Load("Digit_0")) as GameObject);
        //scoreDigit.transform.position = new Vector3(4.66f, 8.62f, -13.00f);

        //Vector3 temp = scoreDigit.transform.rotation.eulerAngles;
        //temp.y = -183.96f;
        //scoreDigit.transform.rotation = Quaternion.Euler(temp);

        ////scoreDigit.transform.localScale += new Vector3(2f, 2f, 2f);
        //scoreDigit.tag = "Scoredigit";
        scoreChar = (Instantiate(Resources.Load("Letter_S")) as GameObject);
        scoreChar.transform.position = new Vector3(20.00f, 5.00f, 5.00f);
        Vector3 temp = scoreChar.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreChar.transform.rotation = Quaternion.Euler(temp);
        scoreChar.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreChar.tag = "ScoreChar";

        scoreChar = (Instantiate(Resources.Load("Letter_C")) as GameObject);
        scoreChar.transform.position = new Vector3(20.00f, 5.00f, 3.00f);
        temp = scoreChar.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreChar.transform.rotation = Quaternion.Euler(temp);
        scoreChar.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreChar.tag = "ScoreChar";

        scoreChar = (Instantiate(Resources.Load("Letter_O")) as GameObject);
        scoreChar.transform.position = new Vector3(20.00f, 5.00f, 1.00f);
        temp = scoreChar.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreChar.transform.rotation = Quaternion.Euler(temp);
        scoreChar.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreChar.tag = "ScoreChar";

        scoreChar = (Instantiate(Resources.Load("Letter_R")) as GameObject);
        scoreChar.transform.position = new Vector3(20.00f, 5.00f, -1.00f);
        temp = scoreChar.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreChar.transform.rotation = Quaternion.Euler(temp);
        scoreChar.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreChar.tag = "ScoreChar";

        scoreChar = (Instantiate(Resources.Load("Letter_E")) as GameObject);
        scoreChar.transform.position = new Vector3(20.00f, 5.00f, -3.00f);
        temp = scoreChar.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreChar.transform.rotation = Quaternion.Euler(temp);
        scoreChar.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreChar.tag = "ScoreChar";

        scoreChar = (Instantiate(Resources.Load("Colon_")) as GameObject);
        scoreChar.transform.position = new Vector3(20.00f, 5.00f, -5.00f);
        temp = scoreChar.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreChar.transform.rotation = Quaternion.Euler(temp);
        scoreChar.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreChar.tag = "ScoreChar";

        scoreDigit = (Instantiate(Resources.Load("Digit_0")) as GameObject);
        scoreDigit.transform.position = new Vector3(20.00f, 5.00f, -8.00f);
        temp = scoreDigit.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreDigit.transform.rotation = Quaternion.Euler(temp);
        scoreDigit.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreDigit.tag = "ScoreDigit";

        scoreDigit = (Instantiate(Resources.Load("Letter_Slash")) as GameObject);
        scoreDigit.transform.position = new Vector3(20.00f, 4.49f, -9.47f);
        temp = scoreDigit.transform.rotation.eulerAngles;
        temp.y = 87.78f;
        scoreDigit.transform.rotation = Quaternion.Euler(temp);
        scoreDigit.transform.localScale += new Vector3(1f, 1f, 1f);
        scoreDigit.tag = "ScoreDigit";

        Debug.Log("In Start blanks" + blanks);

        int totalScore = blanks * 10;

        string scoreString = totalScore.ToString();
        float increment = 0f;

        // Extract each digit and get its prefab to be displayed.
        for (int i = 0; i < scoreString.Length; i++)
        {
            int scoreDigit = (int)(scoreString[i] - '0');

            //Debug.Log("New Score Digit is:" + scoreDigit);

            totalDigit = (Instantiate(Resources.Load("Digit_"+scoreDigit)) as GameObject);
            totalDigit.transform.position = new Vector3(20.00f, 5.00f, -11.50f - increment);
            Vector3 tempVector = totalDigit.transform.rotation.eulerAngles;
            tempVector.y = 87.78f;
            totalDigit.transform.rotation = Quaternion.Euler(tempVector);
            totalDigit.transform.localScale += new Vector3(1f, 1f, 1f);
            totalDigit.tag = "ScoreDigit";

            increment += 1.5f;

        
        }


    }

    public static void setBlanksInCountdown(int val)
    {
        blanks = val;
        Debug.Log("blanks " + blanks);
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
            ////Debug.Log(decimalPart);
            int modifiedTimer = timer + 1;
            //timer.ToString("F");
            if (timer != mainTimer)
            {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("digit");

                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
                //dest1 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                ////Debug.Log("Destroy 1:" + dest1);
                //Destroy(dest1);

                //dest2 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                ////Debug.Log("Destroy 2:" + dest2);
                //Destroy(dest2);

                //dest3 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                ////Debug.Log("Destroy 3:" + dest3);
                //Destroy(dest3);

                //dest4 = GameObject.Find("Digit_" + (modifiedTimer) + "(Clone)");
                ////Debug.Log("Destroy 4:" + dest4);
                //Destroy(dest4);

                ////Debug.Log(dest);

            }
            //Debug.Log(timer);
            string timerString = timer.ToString();
            float increment = 0f;

            // Extract each digit and get its prefab to be displayed.
            for (int i = 0; i < timerString.Length; i++)
            {
                int newTimer = (int)(timerString[i] - '0');

                //Debug.Log("New Timer is:" + newTimer);

                myItem1 = (Instantiate(Resources.Load("Digit_" + newTimer)) as GameObject);
                myItem1.transform.position = new Vector3(0.15f + increment, 11.00f, 19.92f);
                myItem1.transform.localScale += new Vector3(2f, 2f, 2f);
                myItem1.tag = "digit";
                //Debug.Log("Item1 is:" + myItem1);

                myItem2 = (Instantiate(Resources.Load("Digit_" + newTimer)) as GameObject);
                myItem2.transform.position = new Vector3(20.00f, 13.00f, 0.00f - increment);
                Vector3 temp = myItem2.transform.rotation.eulerAngles;
                temp.y = 87.78f;
                myItem2.transform.rotation = Quaternion.Euler(temp);
                myItem2.transform.localScale += new Vector3(2f, 2f, 2f);

                myItem2.tag = "digit";

                //Debug.Log("Item2 is:" + myItem2);

                myItem3 = (Instantiate(Resources.Load("Digit_" + newTimer)) as GameObject);
                myItem3.transform.position = new Vector3(0.15f - increment, 11.00f, -18.00f);

                temp = myItem3.transform.rotation.eulerAngles;
                temp.y = 187.00f;
                myItem3.transform.rotation = Quaternion.Euler(temp);
                myItem3.transform.localScale += new Vector3(2f, 2f, 2f);

                myItem3.tag = "digit";

                //Debug.Log("Item3 is:" + myItem3);

                myItem4 = (Instantiate(Resources.Load("Digit_" + newTimer)) as GameObject);
                myItem4.transform.position = new Vector3(-19.00f, 11.00f, 0.31f + increment);

                temp = myItem4.transform.rotation.eulerAngles;
                temp.y = -90.78f;
                myItem4.transform.rotation = Quaternion.Euler(temp);
                myItem4.transform.localScale += new Vector3(2f, 2f, 2f);

                increment += 2f;

                myItem4.tag = "digit";

                //Debug.Log("Item4 is:" + myItem4);
            }

            timer -= 1;

            ////Debug.Log("Item is:"+myItem);
        }
        else if (timer <= 0 && !doOnce)
        {
            canCount = false;
            doOnce = true;
          //  uiText.text = "0";
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