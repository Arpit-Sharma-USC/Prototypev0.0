﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SendInputString : MonoBehaviour {

    public GameObject Parent;
    public Text PuzzleText;
    public string input = "";
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        ContainerGenerator obj = new ContainerGenerator();
    }

    public void ButtonPress() {
        input = PuzzleText.text;
        SceneManager.LoadScene("Game");       
    }
}
