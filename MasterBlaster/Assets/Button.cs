﻿using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    float timer = 3;
    float timerMax = 3;
    
        
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    //On click of the start button play the game
    public void OnClick()
    {
        Application.LoadLevel(1);
    }

    //on click of the exit button quit
    public void ClickExit()
    {
        Application.Quit();
    }
    public void BackMainMenu()
    {
        Application.LoadLevel(0);
    }
    public void toInstructions()
    {        
            
            Application.LoadLevel(2);
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
}
