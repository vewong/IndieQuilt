using UnityEngine;
using System.Collections;

public class FenceCrashing : MonoBehaviour {

    ControllerScript comptroller;

	// Use this for initialization
	void Start () 
    {
        comptroller = (ControllerScript)FindObjectOfType<ControllerScript>();

        if (comptroller == null)
        {
            Debug.LogError("GameController not found! *sirens and fire*");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            comptroller.CrashedIntoFence();

            other.gameObject.BroadcastMessage("Die");
        }
    }
}
