using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContainerCollider : MonoBehaviour {
    public static int theScore;
    private AudioSource containerAudio;
    public AudioClip win; //set this in ispector with audiofile
    public AudioClip loose;
    private Text scoreText;
    GameObject score;
    private void Start()
    {
        Debug.Log("In Conainer Collider");
        containerAudio = GetComponent<AudioSource>();
        theScore = 0;
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
        }

        //containerAudio.Play();
    }
}
