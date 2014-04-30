using UnityEngine;
using System.Collections;

public class BuffSpawn : MonoBehaviour {
	public Transform buff1;
	public Transform buff2;
	private float x;
	private float y;
	private float z;
	private bool Quitting;
	private int number;


	// Use this for initialization
	void Start () {

		Quitting = false; //Setting the viariable Quitting to false, this is done to avoid spawning buffs on the scene when we closed the game.
		x = transform.position.x; //x,y,z are set as the position of the object the script is on.
		y = transform.position.y;
		z = transform.position.z;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnApplicationQuit(){ //If the application is quitting, the quitting variable is set to true and will not spawn additional buffs..

		Quitting = true;
	}

	void OnDestroy() { //Runs when the object destroys.
		if(Quitting == false){ //Seeing if Quitting is false.
		if(Random.Range(0,4)==3){//Gets a random number between 0 and 3. If this is 3 it will spawn on of the buff. gives a 25% chance of a buff.
			number = Random.Range(0,2); //Sets number to be between 0 and 1.
			switch (number)
				       {
					case 0://Instatiates buff1, on the location of the destoyed object.
						Instantiate(buff1, new Vector3(x,y,z), Quaternion.identity);
						break;
					case 1://Instatiates buff2, on the location of the destoyed object.
						Instantiate(buff2, new Vector3(x,y,z), Quaternion.identity);
						break;
					default:
						break;					
				
				}
			}
		}

	}
}
