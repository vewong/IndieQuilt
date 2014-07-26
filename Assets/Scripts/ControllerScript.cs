using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    //int timeRemaining = 3000;
    bool timeElapsed = false;
    bool crashed = false;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	    //if time has run out, you win!
        if (timeElapsed)
        {
            //win!
        }
        if (crashed)
        {
            //lose :(
        }
	}

    void OnGUI()
    {
        //if time has run out, you win!
        if (timeElapsed)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "Win!");
        }
        if (crashed)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "Lose :(");
        }
    }

    //the timer will send a signal to the controller when time has elapsed
    void TimeHasElapsed()
    {
        timeElapsed = true;
    }

    //the fence sends a signal to the game controller on collision
    void CrashedIntoFence()
    {
        crashed = true;
    }
}
