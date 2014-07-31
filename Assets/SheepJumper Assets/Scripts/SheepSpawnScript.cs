using UnityEngine;
using System.Collections;

public class SheepSpawnScript : MonoBehaviour {

    public Transform sheepSpawnLoc;
    public GameObject sheepCopy;
    float spawnerCooldown = 0f;

    IndieQuiltCommunicator communicator;

    //change how many sheep can spawn based on difficulty
    float sheepSpawnEasy = 1f;
    float sheepSpawnMed = 2f;
    float sheepSpawnHard = 3f;
    float sheepSpawnMax;
    int sheepToSpawn;

	// Use this for initialization
	void Awake () 
    {
        communicator = GetComponentInParent<IndieQuiltCommunicator>();

        if (communicator.difficulty < 4)
        {
            sheepSpawnMax = sheepSpawnEasy;
        }
        else if (communicator.difficulty < 7)
        {
            sheepSpawnMax = sheepSpawnMed;
        }
        else
        {
            sheepSpawnMax = sheepSpawnHard;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (spawnerCooldown > 0)
        {
            spawnerCooldown -= Time.deltaTime;
        }
        else if (sheepToSpawn > 0)
        {
            SpawnSheep();
        }
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        //check if the colliding object is a sheep (even though nothing else should have a collider?
        if (other.tag.Equals("Player") && spawnerCooldown <= 0)
        {
            //determine how many sheep to spawn each time a sheep successfully jumps the fence
            sheepToSpawn = (int)Random.Range(1f, sheepSpawnMax);
            Debug.Log("spawning " + sheepToSpawn + " this time");

            //sheep has entered the collider, so spawn a new sheep behind it
            SpawnSheep();

            if (communicator.difficulty < 4)
            {
                spawnerCooldown = 3f;
            }
            else
                spawnerCooldown = .5f;
        }
    }

    void SpawnSheep()
    {
        Instantiate(sheepCopy, sheepSpawnLoc.position, sheepSpawnLoc.rotation);
        sheepToSpawn--;
    }
}
