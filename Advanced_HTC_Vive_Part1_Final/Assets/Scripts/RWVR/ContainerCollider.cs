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
        ScoreText=(Text)GameObject.Find("Score").GetComponent("Text");
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
            theScore += 50;

            Text score=(Text)ScoreText.GetComponent("Text");
            score.text = theScore.ToString();

            Debug.Log("New Score" + theScore);
            //ScoreText. = "Score: " + theScore.ToString();


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
