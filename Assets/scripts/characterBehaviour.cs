using UnityEngine;
using System.Collections;

public class characterBehaviour : MonoBehaviour {

    public int bombCount=1;
	public int rangeCount=2;
	public GameObject bombPrefab;
	
	void start()
	{

	}


	void Update()
	{
	}


	//Code for triggering spawn
	public void triggerBomb()
	{
			if (bombCount > 0)                                                                                  //if bombCount is above 0
		{
			
				StartCoroutine(currentBombs());                                                                 //The IEnumerator currentBombs is run
			
		}
	}

	//CODE FOR THE BOMB SPAWN AND THE AMOUNT AVAILABLE
	IEnumerator currentBombs()
	{
		GameObject bomb = Instantiate (bombPrefab, transform.position, Quaternion.identity) as GameObject;      //Spawns the bomb
        bomb.GetComponent<bombScript>().placer = gameObject.GetComponent<characterBehaviour>();                 //sets the placer of the spawned bomb equal to the characterBehaviour script (to be used in the bombScript)
		bombCount = bombCount -1;                                                                               //bombCount is subtracted by 1
		yield return new WaitForSeconds(12);                                                                    //waits 12 seconds which is the time before the bomb explodes
		bombCount = bombCount+1;                                                                                //sets the bombCount back up

	}

	//CODE FOR COLLISION WITH BUFFS
	void OnTriggerEnter(Collider other)                                                                         //Checks if a trigger is entered
	{
				if (other.gameObject.tag == "BombPickup")                                                       //If the collision is with a gameObject with the tag BombPickup
                {     
						Destroy (other.gameObject);                                                             //then the gameObject with that tag is destroyed
						bombCount = bombCount + 1;                                                              //and bombCount is increased by 1
				}
				if (other.gameObject.tag == "RangePickup")                                                      //If the collision is with a gameObject with the tag RangePickup
                {
						Destroy (other.gameObject);                                                             //then the gameObject with that tag is destroyed
						rangeCount = rangeCount + 1;                                                            //and the bombCount is increased by 1
				}
	}

}
