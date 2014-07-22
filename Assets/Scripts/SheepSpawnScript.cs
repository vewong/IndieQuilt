using UnityEngine;
using System.Collections;

public class SheepSpawnScript : MonoBehaviour {

    public Transform sheepSpawnLoc;
    public GameObject sheepCopy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        //check if the colliding object is a sheep (even though nothing else should have a collider?
        if (other.tag.Equals("Player"))
        {
            //sheep has entered the collider, so spawn a new sheep behind it
            Instantiate(sheepCopy, sheepSpawnLoc.position, sheepSpawnLoc.rotation);
        }
    }
}
