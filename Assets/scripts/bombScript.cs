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
    int range1;
    int range2;
	private bool Quitting;
    public bool p1, p2;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
		Quitting = false;
        checkCollision();
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn;
        explosionTurn = currentTurn + turnsToExplosion;
    }

    void Update()
    {   
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn;
        range1 = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().rangeCount;
        range2 = GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().rangeCount;
        p1 = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().p1;
        p2 = GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().p2;

        if (currentTurn == explosionTurn)
        {
            Destroy(gameObject);
        }
    }
	void OnApplicationQuit(){
		
		Quitting = true;
	}
    void OnDestroy()
    {
		if(Quitting == false){
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        spawnPlayer1();
            /*
            if (p1 == true)
            {
                Debug.Log("bomb player1");
                spawnPlayer1();

            }
            else if (p2 == true)
            {
                Debug.Log("bomb player2");
                spawnPlayer2();
            }
        */
        }
    }

    void spawnPlayer1()
    {
        for (int i = 1; i < placer.rangeCount; i++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, i), transform.rotation);
            if (up == true)
                i = placer.rangeCount;

            else if (i == 2 && up2 == true)
                i = placer.rangeCount;

            else if (i == 3 && up3 == true)
                i = placer.rangeCount;
        }

        for (int j = 1; j < placer.rangeCount; j++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, -j), transform.rotation);
            if (down == true)
                j = placer.rangeCount;

            else if (j == 2 && down2 == true)
                j = placer.rangeCount;

            else if (j == 3 && down3 == true)
                j = placer.rangeCount;
        }

        for (int k = 1; k < placer.rangeCount; k++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(k, 0, 0), transform.rotation);
            if (right == true)
                k = placer.rangeCount;

            else if (k == 2 && right2 == true)
                k = placer.rangeCount;

            else if (k == 3 && right3 == true)
                k = placer.rangeCount;
        }

        for (int l = 1; l < placer.rangeCount; l++)
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
    /*
    void spawnPlayer2()
    {
        for (int i = 1; i < range2; i++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, i), transform.rotation);
            if (up == true)
                i = range2;

            else if (i == 2 && up2 == true)
                i = range2;

            else if (i == 3 && up3 == true)
                i = range2;
        }

        for (int j = 1; j < range2; j++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, -j), transform.rotation);
            if (down == true)
                j = range2;

            else if (j == 2 && down2 == true)
                j = range2;

            else if (j == 3 && down3 == true)
                j = range2;
        }

        for (int k = 1; k < range2; k++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(k, 0, 0), transform.rotation);
            if (right == true)
                k = range2;

            else if (k == 2 && right2 == true)
                k = range2;

            else if (k == 3 && right3 == true)
                k = range2;
        }

        for (int l = 1; l < range2; l++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(-l, 0, 0), transform.rotation);
            if (left == true)
                l = range2;

            else if (l == 2 && left2 == true)
                l = range2;

            else if (l == 3 && left3 == true)
                l = range2;
        }
    }
*/
    void checkCollision()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 3.0f))
        {
            if (hit.distance < 1.0f)
            {
                up = true;
            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                up2 = true;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
                up3 = true;
            }
            else
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

        // Check for collisions below
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 3.0f))
        {
            if (hit.distance < 1.0f)
            {
                down = true;

            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                down2 = true;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
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

        // Check for collisions to the left
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1.0f))
        {
            if (hit.distance < 1.0f)
            {
                left = true;

            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                left2 = true;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
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

        // Check for collisions to the right
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1.0f))
        {
            if (hit.distance < 1.0f)
            {
                right = true;

            }
            else if (1.0f < hit.distance && hit.distance < 2.0f)
            {
                right2 = true;
            }
            else if (2.0f < hit.distance && hit.distance < 3.0f)
            {
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