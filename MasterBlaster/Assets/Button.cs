using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

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
}
