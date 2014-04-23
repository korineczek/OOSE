using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour
{

    public int explosionTurn;
    int currentTurn;
    int turnsToExplosion = 2;
    public GameObject explosionPrefab;
    public bool up, up2, up3, down, down2, down3, left, left2, left3, right, right2, right3;
    RaycastHit hit;
    int range;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        checkCollision();
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn;
        explosionTurn = currentTurn + turnsToExplosion;
    }

    void Update()
    {
        
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn;
        range = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().rangeCount;
        Debug.Log(currentTurn + " " + explosionTurn);

        if (currentTurn == explosionTurn)
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        for (int i = 1; i < range; i++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, i), transform.rotation);
            if (up == true)
                i = range;

            if (i == 2 && up2 == true)
                i = range;

            if(i==3 && up3 == true)
                i=range;
        }

        for (int j = 1; j < range; j++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, -j), transform.rotation);
            if (down == true)
                j = range;

            if (j == 2 && down2 == true)
                j = range;

            if (j == 3 && down3 == true)
                j = range;
        }

        for (int k = 1; k < 3; k++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(k, 0, 0), transform.rotation);
            if (right == true)
                k = range;

            if (k == 2 && right2 == true)
                k = range;

            if (k == 3 && right3 == true)
                k = range;
        }

        for (int l = 1; l < 3; l++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(-l, 0, 0), transform.rotation);
            if (left == true)
                l = range;

            if (l == 2 && left2 == true)
                l = range;
                
            if (l == 3 && left3 == true)
                l = range;
        }
    }

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