using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	public int explodeTimer;
    
	public void Start ()
	{
		Destroy (gameObject, explodeTimer);                                                         //Destroys gameObject after a certain amount of time after the start of the function. This is determined by the public variable explodeTimer  
	}

	
	// Update is called once per frame
   public  void Update()
    {
   }

	//DESTROY BOMBS ON COLLISION
   public void OnTriggerEnter(Collider col)                                                         // Checks if there is a collision with a trigger
   {
       if (col.gameObject.tag == "bomb")                                                            //if the trigger got the tag bomb
       {
           Destroy(col.gameObject);                                                                 //then the trigger is destroyed
       }
   }

    //DESTROY PLAYERS, CUBES AND EXPLOSIONS
	public void OnCollisionEnter (Collision col)                                                    //Checks for collision
	{
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")                     //if it collides with another gameObject with the tag Player1 or Player2
		{
        	Destroy(col.gameObject);                                                                //then the other gameObject is destroyed
            GameObject.FindWithTag("Handler").GetComponent<IRChandler>().gameOver = true;           //and gameOcer is set to tru in the IRCHandler
		}
        if (col.gameObject.tag == "DestructableCube")                                               //if it collides with another gameObject with the tag DestructableCube
        {
            Destroy(col.gameObject);                                                                //then the other gameObject is destroyed
            Destroy(gameObject, explodeTimer);  
        }

		if(col.gameObject.tag == "Wall")                                                            //if it collides with another gameObject with the tag Wall                                                
		{
        	Destroy(gameObject);                                                                    //then it destroys the gameobject
		}
	}
}
