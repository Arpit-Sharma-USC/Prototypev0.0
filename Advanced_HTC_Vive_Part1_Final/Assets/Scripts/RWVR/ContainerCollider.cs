using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ContainerCollider : MonoBehaviour {
    public static int theScore;
    private AudioSource containerAudio;
    public AudioClip win; //set this in ispector with audiofile
    public AudioClip loose;
<<<<<<< HEAD
    private Text scoreText;
    GameObject score;
=======
    public Text ScoreText;
    private GameObject scoreDigit;

    /// <summary>
    /// RAHUL ABHISHEK
    ///
    public AudioClip levelComplete;
    private GameObject scoreChar;
    private GameObject myItem1;
    public static int count;
    GameObject thePlayer;
    ContainerGenerator playerScript;
    public static int temp1;
    GameObject scoreDigitObj;
    /// </summary>

>>>>>>> 366a4321704ce7c02f4dd1da419aa009951f5488
    private void Start()
    {
        Debug.Log("In Conainer Collider");
        containerAudio = GetComponent<AudioSource>();
        theScore = 0;
<<<<<<< HEAD
        //ScoreText.text = "Score" + theScore.ToString();
        score = GameObject.Find("Score");
        scoreText=score.GetComponent<Text>();
        scoreText.text = "Dude Man";
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");

        string gameObj = collision.gameObject.name;
        string collisionObj = gameObject.tag;

        Debug.Log(gameObj);
        Debug.Log(collisionObj);

        if (gameObj.Equals(collisionObj))
        {
            Debug.Log("EQUAL PASSED");
            theScore += 50;
            scoreText.text = "Score: " + theScore.ToString();

=======
        //count = 0;

        thePlayer = GameObject.Find("ContainerBoxParent");
        playerScript = thePlayer.GetComponent<ContainerGenerator>();
        //temp1 = 0;

        /*uncomment this for score*/

        ScoreText = (Text)GameObject.Find("ScoreCanvas").GetComponent("Text");
    }

    public static void setBlanks(int val)
    {
        temp1 = val;
        Debug.Log("temp " + temp1);
    }

    private void OnCollisionEnter(Collision collision)
        {
        char match_first = (collision.gameObject.name)[0];
        string temp_str = match_first.ToString();


        string collisionObject = temp_str;
        string gameObjectTag = gameObject.tag;

        Debug.Log(collisionObject);
        Debug.Log(gameObjectTag);
        if (collisionObject.Equals(gameObjectTag))
        {
            theScore += 10;
            count++;
            /*uncomment this for score*/
            //Text score = (Text)ScoreText.GetComponent("Text");
            //score.text = theScore.ToString();

            //Debug.Log("New Score" + theScore);
            //ScoreText. = "Score: " + theScore.ToString();

            /**/

            // Displaying Score digits by extracting each
            Debug.Log("No of blanks " + temp1);
            Debug.Log("count1 " + count);

            if (temp1 == count)
            {
                Debug.Log("Win Scene");
                SceneManager.LoadScene("Showcase");
                containerAudio.clip = levelComplete;
                containerAudio.Play();
                //count = 0;
            }
            //count++;

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ScoreDigit");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            string scoreString = theScore.ToString();
            float increment = 0f;
            float locationNow = 0f;

            // Extract each digit and get its prefab to be displayed.
            for (int i = 0; i < scoreString.Length; i++)
            {
                int scoreDigit = (int)(scoreString[i] - '0');

                Debug.Log("New Score Digit is:" + scoreDigit);

                myItem1 = (Instantiate(Resources.Load("Digit_" + scoreDigit)) as GameObject);
                myItem1.transform.position = new Vector3(20.00f, 5.00f, -8.00f - increment);
                Vector3 temp = myItem1.transform.rotation.eulerAngles;
                temp.y = 87.78f;
                myItem1.transform.rotation = Quaternion.Euler(temp);
                myItem1.transform.localScale += new Vector3(1f, 1f, 1f);
                myItem1.tag = "ScoreDigit";

                increment += 2f;
                locationNow = -8.00f - increment;

            }

            scoreDigitObj = (Instantiate(Resources.Load("Letter_Slash")) as GameObject);
            scoreDigitObj.transform.position = new Vector3(20.00f, 5.00f, locationNow);
            Vector3 tempV = scoreDigitObj.transform.rotation.eulerAngles;
            tempV.y = 87.78f;
            scoreDigitObj.transform.rotation = Quaternion.Euler(tempV);
            scoreDigitObj.transform.localScale += new Vector3(1f, 1f, 1f);
            scoreDigitObj.tag = "ScoreDigit";

            //Debug.Log("In Start blanks" + blanks);

            int totalScore = temp1 * 10;

            scoreString = totalScore.ToString();
            locationNow -= 2f;
            increment = 0f;
            // Extract each digit and get its prefab to be displayed.
            for (int i = 0; i < scoreString.Length; i++)
            {
                int scoreDigit = (int)(scoreString[i] - '0');

                //Debug.Log("New Score Digit is:" + scoreDigit);

                GameObject totalDigit = (Instantiate(Resources.Load("Digit_" + scoreDigit)) as GameObject);
                totalDigit.transform.position = new Vector3(20.00f, 5.00f, locationNow - increment);
                Vector3 tempVector = totalDigit.transform.rotation.eulerAngles;
                tempVector.y = 87.78f;
                totalDigit.transform.rotation = Quaternion.Euler(tempVector);
                totalDigit.transform.localScale += new Vector3(1f, 1f, 1f);
                totalDigit.tag = "ScoreDigit";

                increment += 1.5f;


            }

            //Displaying Digits Ends here

>>>>>>> 366a4321704ce7c02f4dd1da419aa009951f5488
            containerAudio.clip = win;
            containerAudio.Play();
            Debug.Log("Play Win");

<<<<<<< HEAD
            Transform A = gameObject.transform;
            
=======
            Transform solutionObject = gameObject.transform;

>>>>>>> 366a4321704ce7c02f4dd1da419aa009951f5488
            Debug.Log("Child!");
            A.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Count :" + A.childCount);

            //Debug.Log(gameObject.transform.GetChild(0));
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
<<<<<<< HEAD
       }
        else if(collision.gameObject.name== "ContainerBox(Clone)" && collision.gameObject.name != gameObject.tag){
=======
        }
        else
        {
>>>>>>> 366a4321704ce7c02f4dd1da419aa009951f5488
            Debug.Log("Play Loose");
            containerAudio.clip = loose;   
        }

        //containerAudio.Play();
    }
}
