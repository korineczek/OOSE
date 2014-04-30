using UnityEngine;
using System.Collections;

public class generateBOXESlol : MonoBehaviour
{
	//Variables
	public Transform floor;
	public Transform camera;
	public Transform crate;
	public Transform wall;
	public Transform player1;
	public Transform player2;
	public int maxw = 10;
	public int maxh = 10;
	private int[,] x;
	private int y = 0;
	public int numbercrate = 10;
	private int number, spawnnumber;
	
	
	
	// Use this for initialization
	void Awake()
	{
		//Spawn Floor
		Transform Floor = (Transform)Instantiate(floor, new Vector3(maxw / 2, 0, maxh / 2), Quaternion.identity); //Instatiates the floor on the scene.
		Floor.transform.localScale = new Vector3(maxw, 1, maxh); //Scales the instatiated floor to the be maxw wide and maxh long. maxw and maxh can be changed in the inspector.
		Floor.renderer.material.mainTextureScale = new Vector2(maxh, maxw); //Scales the material to fit the scaled floor.
		
		//Spawn Walls
		//The Following four lines Instatiates four walls on the scene
		Transform Wall1 = (Transform)Instantiate(wall, new Vector3(maxw, 1, maxh / 2), Quaternion.identity);
		Transform Wall2 = (Transform)Instantiate(wall, new Vector3(0, 1, maxh / 2), Quaternion.identity);
		Transform Wall3 = (Transform)Instantiate(wall, new Vector3(maxw/2, 1, maxh), Quaternion.identity);
		Transform Wall4 = (Transform)Instantiate(wall, new Vector3(maxw / 2, 1, 0), Quaternion.identity);

		//The Following four lines scales the instatiated walls to fit with the floor.
		Wall1.transform.localScale = new Vector3(1, 1, maxh-1);
		Wall2.transform.localScale = new Vector3(1, 1, maxh-1);
		Wall3.transform.localScale = new Vector3(maxw+1, 1, 1);
		Wall4.transform.localScale = new Vector3(maxw+1, 1, 1);

		//The following four lines scales the material to fit the scaled walls.
		Wall1.renderer.material.mainTextureScale = new Vector2(1, maxh-1);
		Wall2.renderer.material.mainTextureScale = new Vector2(1, maxh-1);
		Wall3.renderer.material.mainTextureScale = new Vector2(maxw-1, 1);
		Wall4.renderer.material.mainTextureScale = new Vector2(maxw-1, 1);
		
		//Generate seed value to determine the spawn of the players
		spawnnumber = Random.Range(0, 4); //Sets spawnnumber to be a number between 0 and 3.
		
		switch (spawnnumber) //In this switch we choose where to instatiate player 1 and player 2
		{
		case 0:
			Instantiate(player1, new Vector3(1, 1, 1), Quaternion.Euler(0, 180, 0)); //player1 in bottom left corner
			Instantiate(player2, new Vector3(maxh - 1, 1, maxw - 1), Quaternion.Euler(0, 180, 0)); //player2 in top right cornor
			break;
		case 1:
			Instantiate(player1, new Vector3(maxh - 1, 1, 1), Quaternion.Euler(0, 180, 0)); //player1 in top left cornor
			Instantiate(player2, new Vector3(1, 1, maxw - 1), Quaternion.Euler(0, 180, 0)); //player2 bottom right cornor
			break;
		case 2:
			Instantiate(player1, new Vector3(1, 1, maxw - 1), Quaternion.Euler(0, 180, 0)); //player1 bottom right cornor
			Instantiate(player2, new Vector3(maxh - 1, 1, 1), Quaternion.Euler(0, 180, 0)); //player2 in top left cornor
			break;
		case 3:
			Instantiate(player2, new Vector3(1, 1, 1), Quaternion.Euler(0, 180, 0)); //player2 in bottom left cornor
			Instantiate(player1, new Vector3(maxh - 1, 1, maxw - 1), Quaternion.Euler(0, 180, 0)); //player1 in top right cornor 
			break;
		default:
			break;
		}
		
		//Camera moves accordingly with field size to compensate for bigger areas
		camera.transform.position = new Vector3(maxh / 2, maxh + 5, maxw / 2);
		
		
		//LEVEL GENERATION
		x = new int[maxh, maxw]; //We set the size of our array x
		/*for (int i = 0; i <= maxh - 1; i++) //This code is not used anymore
			for (int k = 0; k <= maxw - 1; k++)
		{
			if (i == 0 || k == 0 || i == maxh - 1 || k == maxw - 1)
			{
				//x[i, k] = 1;
			}
			else
			{
				//x[i, k] = 0;
			}			
		}*/ 
		for (int i = 0; i < maxh; i = i + 2)
			for (int k = 0; k < maxw; k = k + 2) //We run through the array to determine where to place walls inside the walls.
		{
			if (y == 0)
			{
				x[i, k] = 1;
				y = 1;
			}
			else
			{
				y--;
			}
			
		}/*
		for (int i = 0; i <= maxh - 1; i++) //Code is not used anymore
			for (int k = 0; k <= maxw - 1; k++)
		{
			if (x[i, k] != 0 && x[i, k] != 1)
			{
				if (Random.Range(0, 2) == 1)
				{
					x[i, k] = 2;
				}
				
				
			}
			
			
			
		}*/
		//Spawn boxes loop
		for (int i = 1; i <= maxh - 1; i++)
			for (int k = 1; k <= maxw - 1; k++) //We run through the level to instatiate crates and walls.
		{
			
			
			switch (x[i, k])
			{
				
			case 0: //Case 0 will place crates, but still allow the players to have a safe zone in all the cornors. by safe zone is meant that the player can place a bomb and still avoid being hit by the explosion. The following long if statement is coordinates for where not to place a bomb.
				if (((k == 1 && i == 1) || (k == 2 && i == 1) || (k == 1 && i == 2)) || ((k == maxw - 1 && i == maxh - 1) || (k == maxw - 2 && i == maxh - 1) || (k == maxw - 1 && i == maxh - 2)) || ((k == maxw - 1 && i == 1) || (k == maxw - 2 && i == 1) || (k == maxw - 1 && i == 2)) || ((k == 1 && i == maxh - 1) || (k == 2 && i == maxh - 1) || (k == 1 && i == maxh - 2)))
				{
					break;
				}
				else
				{
					//60% chance to spawn a destructible block on top of the floor 
					if (Random.Range(0, 3) >= 1) //This takes a random number between 0 and 2 and if this is 1 or higher, it will instatiate a crate.
					{
						Instantiate(crate, new Vector3(i, 1, k), Quaternion.identity);
					}
				}
				break;
			case 1:
				Instantiate(wall, new Vector3(i, 1, k), Quaternion.identity); //Instatiates the walls.
				break;
			/*case 2:
				Instantiate(crate, new Vector3(i, 1, k), Quaternion.identity);
				break;*/
			default:
				break;
			}
		}
	}
}


