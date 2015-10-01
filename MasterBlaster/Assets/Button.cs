using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().bounds.Encapsulate(GetComponentInChildren<Renderer>().bounds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Application.LoadLevel(1);
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
