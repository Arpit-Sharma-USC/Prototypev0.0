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

    private void Start()
    {
        theScore = 0;
        ScoreText.text = "Score" + theScore.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == gameObject.tag)
        {
            theScore += 50;
            ScoreText.text = "Score: " + theScore.ToString();

            containerAudio.clip = win;

            Transform A = gameObject.transform;
            
            Debug.Log("Child!");
            A.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Count :" + A.childCount);

            //Debug.Log(gameObject.transform.GetChild(0));
            Destroy(collision.gameObject);
            Debug.Log("Destroying after touch");
       }
        else if(gameObject.name=="ContainerBoxParent(Clone)" && collision.gameObject.name != gameObject.tag){
            containerAudio.clip = loose;   
        }

        containerAudio.Play();
    }
}
