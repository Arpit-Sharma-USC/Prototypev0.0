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
    public Toggle Spin ;
    public Toggle MissingLettersOnly ;
    public bool valueOfSpinToggle = false;
    public bool valueOfMissingLettersOnlyToggle = false;
    public Text No_Of_Blank_Text;



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        ContainerGenerator obj = new ContainerGenerator();
    }

  
    public void ButtonPress() {
        input = PuzzleText.text;
        inputForHint = HintText.text;
   
        No_of_blanks = int.Parse(No_Of_Blank_Text.text);

        bitMapSubString = new int[input.Length];
        System.Random rnd = new System.Random();
        for (int i = 0; i < bitMapSubString.Length; i++)
        {
            bitMapSubString[i] = 1;

        }
       

      
        int rand_id;
        if (No_of_blanks >= input.Length - 2)
            No_of_blanks = input.Length / 2;

        Debug.Log("No Blanks:" + No_of_blanks);
        ContainerCollider.setBlanks(No_of_blanks);
        Countdown.setBlanksInCountdown(No_of_blanks);

        while (No_of_blanks != 0)
        {
            rand_id = rnd.Next(1, input.Length - 1);
            if (bitMapSubString[rand_id] != 0)
            {
                bitMapSubString[rand_id] = 0;
                No_of_blanks--;

            }
        }

        valueOfSpinToggle = Spin.isOn;
        valueOfMissingLettersOnlyToggle = MissingLettersOnly.isOn;
        


        SceneManager.LoadScene("Game");       
    }
}
