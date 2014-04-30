using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour
{
    public characterBehaviour placer;
    public int explosionTurn;
    int currentTurn;
    int turnsToExplosion = 12;
    public GameObject explosionPrefab;
    public bool up, up2, up3, down, down2, down3, left, left2, left3, right, right2, right3;
    RaycastHit hit;
	private bool Quitting;
    
    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
		Quitting = false;
        checkCollision();                                                                                               //Runs this method at start
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn;                         //checks for the current turn in the IRChandler script
        explosionTurn = currentTurn + turnsToExplosion;                                                                 //sets the explosionTurn
    }

    void Update()
    {   
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn;                         //keeps on updating the current turn
    
        if (currentTurn == explosionTurn)                                                                               //checks if the current turn is equal to the explosionTurn
        {
            Destroy(gameObject);                                                                                        //if it is then the bomb is destroyed
        }
    }
	void OnApplicationQuit(){
		
		Quitting = true;                                                                                                //Quitting is set to try OnApplicationQuit
	}
    void OnDestroy()                                                                                                    //When the bomb is destroyed
    {
		if(Quitting == false){                                                                                          // And the applications isn't quitting
            spawnPlayer1();                                                                                             //It will instantiate the method for the explosion
        }
    }


    //FUNCTION FOR SPAWNING THE EXPLOSION
    void spawnPlayer1()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);                                           //Instantiates explosionPrefab on the position of the bomb
 
        for (int i = 1; i < placer.rangeCount; i++)                                                                     //for loop runs from i to rangeCount of the placer and spawn explosions
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, i), transform.rotation);                // instantiates explosionPrefab (0,0,i) away from the bomb center
            if (up == true)                                                                                             //checks if up is true, which is set in the checkCollision method
                i = placer.rangeCount;                                                                                  // if it is i is set to the rangeCount of the placer, thus ending the for loop

            else if (i == 2 && up2 == true)                                                                             //next it checks if i is 2 and up2 is true (up2 also set in checkCollision method)
                i = placer.rangeCount;                                                                                  // if it is i is set to the rangeCount of the placer, thus ending the for loop

            else if (i == 3 && up3 == true)                                                                             //next it checks if i is 3 and up3 is true (up3 also set in checkCollision method) 
                i = placer.rangeCount;
        }

        for (int j = 1; j < placer.rangeCount; j++)                                                                     //runs another for loop, same concept as the other one, but spawn explosions (0,0,-j) away from the bomb center
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, -j), transform.rotation);
            if (down == true)
                j = placer.rangeCount;

            else if (j == 2 && down2 == true)
                j = placer.rangeCount;

            else if (j == 3 && down3 == true)
                j = placer.rangeCount;
        }

        for (int k = 1; k < placer.rangeCount; k++)                                                                     //runs another for loop, same concept as the other one, but spawn explosions (k,0,0) away from the bomb center
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(k, 0, 0), transform.rotation);
            if (right == true)
                k = placer.rangeCount;

            else if (k == 2 && right2 == true)
                k = placer.rangeCount;

            else if (k == 3 && right3 == true)
                k = placer.rangeCount;
        }

        for (int l = 1; l < placer.rangeCount; l++)                                                                     //runs another for loop, same concept as the other one, but spawn explosions (-l,0,0) away from the bomb center
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(-l, 0, 0), transform.rotation);
            if (left == true)
                l = placer.rangeCount;

            else if (l == 2 && left2 == true)
                l = placer.rangeCount;

            else if (l == 3 && left3 == true)
                l = placer.rangeCount;
        }
    }
  
    //FUNCTION CHECKING THE COLLISION NEAR THE BOMB
    void checkCollision()
    {
        //checks for collision above
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 3.0f))                                         // cast a ray in forward direction of the length 3.0
        {
            if (hit.distance < 1.0f)                                                                                     // if hit.distance is less than 1.0
            {
                up = true;                                                                                               //up is set to true
                up2 = false;                                                                                             //up2 is set to false
                up3 = false;                                                                                             //up3 is set to false
            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)                                                         // if hit.distance is between 1.0 and 2.0
            {
                up = false;                                                                                              //up is set to false                                                                                               
                up2 = true;                                                                                              //up2 is set to true
                up3 = false;                                                                                             //up3 is set to false
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)                                                         // if hit.distance is between 2.0 and 3.0
            {
                up = false;                                                                                              //up is set to false
                up2 = false;                                                                                             //up2 is set to false
                up3 = true;                                                                                              //up3 is set to true
            }
            else                                                                                                         //else all are set to false
            {
                up = false;
                up2 = false;
                up3 = false;
            }

        }
        else
        {
            up = false;
            up2 = false;
            up3 = false;
        }

        // Check for collisions below. Same concept as above
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 3.0f))
        {
            if (hit.distance < 1.0f)
            {
                down = true;
                down2 = false;
                down3 = false;
            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                down = false;
                down2 = true;
                down3 = false;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
                down = false;
                down2 = false;
                down3 = true;
            }
            else
            {
                down = false;
                down2 = false;
                down3 = false;
            }
        }
        else
        {
            down = false;
            down2 = false;
            down3 = false;
        }

        // Check for collisions to the left. Same concept as above
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 3.0f))
        {
            if (hit.distance < 1.0f)
            {
                left = true;
                left2 = false;
                left3 = false;
            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                left = false;
                left2 = true;
                left3 = false;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
                left = false;
                left2 = false;
                left3 = true;
            }
            else
            {
                left = false;
                left2 = false;
                left3 = false;
            }
        }
        else
        {
            left = false;
            left2 = false;
            left3 = false;
        }

        // Check for collisions to the right. Same concept as above
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 3.0f))
        {
            if (hit.distance < 1.0f)
            {
                right = true;
                right2 = false;
                right3 = false;
            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                right = false;
                right2 = true;
                right3 = false;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
                right = false;
                right2 = false;
                right3 = true;
            }
            else
            {
                right = false;
                right2 = false;
                right3 = false;
            }
        }
        else
        {
            right = false;
            right2 = false;
            right3 = false;
        }   
    }
}