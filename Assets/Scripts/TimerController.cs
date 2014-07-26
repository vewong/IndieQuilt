using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour {

    float timeRemaining = 30f;

	// Use this for initialization
	void Start () 
    {
        //InvokeRepeating("decreaseRemainingTime", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //first check if the game is over, then subtract the time passed since last update if the game isn't over
	    if (timeRemaining <= 0)
        {
            SendMessageUpwards("TimeHasElapsed");
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }
	}

    void OnGUI()
    {
        if (timeRemaining > 10)
        {
            GUI.Box(new Rect(10, 0, 50, 50), ":" + (int)timeRemaining);
        }
        else
        {
            GUI.Box(new Rect(10, 0, 50, 50), ":0" + (int)timeRemaining);
        }
    }
}
