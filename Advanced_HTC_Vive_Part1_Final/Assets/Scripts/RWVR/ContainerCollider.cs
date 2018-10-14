using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerCollider : MonoBehaviour {
    public static int theScore;
    private AudioSource containerAudio;
    public AudioClip win; //set this in ispector with audiofile
    public AudioClip loose;
    public GameObject ScoreText;

    private void Start()
    {
        Debug.Log("Hello1");
        containerAudio = GetComponent<AudioSource>();
        theScore = 0;
<<<<<<< HEAD
        ScoreText=GameObject.Find("Score");
=======
        ScoreText = (Text)GameObject.Find("Score").GetComponent("Text");
>>>>>>> ea7fd3cb49840a11322e05b9acf5e3872cc4b80e
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");

        string collisionObject=collision.gameObject.name;
        string gameObjectTag = gameObject.tag;

        Debug.Log(collisionObject);
        Debug.Log(gameObjectTag);

        if (collisionObject.Equals(gameObjectTag))
        {
<<<<<<< HEAD
            Debug.Log("BC");
            theScore += 20;
            //ScoreText.text = "Score: " + theScore.ToString();
            //ScoreText.guiText="Score: " + theScore.ToString();
            Text score=(Text)ScoreText.GetComponent("Text");
            score.text = theScore.ToString();
=======
            theScore += 50;
            Debug.Log("New Score" + theScore);
            ScoreText.text = "Score: " + theScore.ToString();
>>>>>>> ea7fd3cb49840a11322e05b9acf5e3872cc4b80e

            containerAudio.clip = win;
            containerAudio.Play();
            Debug.Log("Play Win");

            Transform A = gameObject.transform;
            
            Debug.Log("Child!");
            A.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Count :" + A.childCount);

            //Debug.Log(gameObject.transform.GetChild(0));
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
       }
        else if(collision.gameObject.name== "ContainerBox(Clone)" && collision.gameObject.name != gameObject.tag){
            Debug.Log("Play Loose");
            containerAudio.clip = loose;
            containerAudio.Play();
        }

        containerAudio.Play();
    }
}
