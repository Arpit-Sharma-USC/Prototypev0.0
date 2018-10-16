using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SendInputString : MonoBehaviour {

    public GameObject Parent;
    public Text PuzzleText;
    public string input = "";
    public Text HintText;
    public string inputForHint = "";
    public int[] bitMapSubString;
    public int No_of_blanks;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        ContainerGenerator obj = new ContainerGenerator();
    }

    public void ButtonPress() {
        input = PuzzleText.text;
        inputForHint = HintText.text;
        bitMapSubString = new int[input.Length];
        System.Random rnd = new System.Random();
        for (int i = 0; i < bitMapSubString.Length; i++)
        {
            bitMapSubString[i] = 1;

        }

        int rand_id;
        if (No_of_blanks >= input.Length - 2)
            No_of_blanks = input.Length / 2;
        while (No_of_blanks != 0)
        {
            rand_id = rnd.Next(1, input.Length - 1);
            if (bitMapSubString[rand_id] != 0)
            {
                bitMapSubString[rand_id] = 0;
                No_of_blanks--;

            }
        }
        SceneManager.LoadScene("Game");       
    }
}
