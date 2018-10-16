using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerCollider : MonoBehaviour
{

    public static int theScore;
    private AudioSource containerAudio;
    public AudioClip win; //set this in ispector with audiofile
    public AudioClip loose;
    public Text ScoreText;
    private GameObject scoreChar;
    private GameObject myItem1;

    private void Start()
    {
        Debug.Log("Hello1");
        containerAudio = GetComponent<AudioSource>();
        theScore = 0;

        /*uncomment this for score*/

        //ScoreText = (Text)GameObject.Find("ScoreCanvas").GetComponent("Text");

        // Displaying "SCORE" as Prefabs in Scene
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

            /*uncomment this for score*/
            //Text score = (Text)ScoreText.GetComponent("Text");
            //score.text = theScore.ToString();

            //Debug.Log("New Score" + theScore);
            //ScoreText. = "Score: " + theScore.ToString();

            /**/

            // Displaying Score digits by extracting each

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ScoreDigit");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            string scoreString = theScore.ToString();
            float increment = 0f;

            // Extract each digit and get its prefab to be displayed.
            for (int i = 0; i < scoreString.Length; i++)
            {
                int scoreDigit = (int)(scoreString[i] - '0');

                Debug.Log("New Score Digit is:" + scoreDigit);

                myItem1 = (Instantiate(Resources.Load("Digit_" + scoreDigit)) as GameObject);
                myItem1.transform.position = new Vector3(15.86f, 5.5f, -8.00f - increment);
                myItem1.transform.localScale += new Vector3(2f, 2f, 2f);
                myItem1.tag = "ScoreDigit";
                Debug.Log("Score Digit is:" + myItem1);

                increment += 2f;
            }

            //Displaying Digits Ends here

            containerAudio.clip = win;
            containerAudio.Play();
            Debug.Log("Play Win");

            Transform solutionObject = gameObject.transform;

            Debug.Log("Child!");

            solutionObject.GetChild(5).gameObject.SetActive(true);
            Debug.Log("Count :" + solutionObject.childCount);

            //Debug.Log(gameObject.transform.GetChild(0));
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
        }
        else
        {
            Debug.Log("Play Loose");
            containerAudio.clip = loose;
            containerAudio.Play();
        }
    }
}