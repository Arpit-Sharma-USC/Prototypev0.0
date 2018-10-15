using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerCollider : MonoBehaviour {

    public static int theScore;
    private AudioSource containerAudio;
    public AudioClip win; //set this in ispector with audiofile
    public AudioClip loose;
    public Text ScoreText;
    private GameObject scoreDigit;

    private void Start()
    {
        Debug.Log("Hello1");
        containerAudio = GetComponent<AudioSource>();
        theScore = 0;
       
        /*uncomment this for score*/

         ScoreText = (Text)GameObject.Find("ScoreCanvas").GetComponent("Text");
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
theScore += 50;
/*uncomment this for score*/
//Text score = (Text)ScoreText.GetComponent("Text");
//score.text = theScore.ToString();

//Debug.Log("New Score" + theScore);
//ScoreText. = "Score: " + theScore.ToString();

/**/
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
