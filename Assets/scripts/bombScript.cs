using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour
{

    public int explosionTurn;
    int currentTurn;
    int turnsToExplosion = 2;
    public GameObject explosionPrefab;
    public bool up, down, left, right;
    RaycastHit hit;

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
        Debug.Log(currentTurn + " " + explosionTurn);

        if (currentTurn == explosionTurn)
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        for (int i = 1; i < 3; i++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, i), transform.rotation);
            if (up == true)
                i = 3;
        }

        for (int j = 1; j < 3; j++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, -j), transform.rotation);
            if (down == true)
                j = 3;        
        }

        for (int k = 1; k < 3; k++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(k, 0, 0), transform.rotation);
            if (right == true)
                k = 3;
        }

        for (int l = 1; l < 3; l++)
        {
            Instantiate(explosionPrefab, transform.position + new Vector3(-l, 0, 0), transform.rotation);
            if (left == true)
                l = 3;
        }
    }

    void checkCollision()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1.0f))
        {
            if (hit.distance < 1.0f)
            {
                up = true;
            }
            else
            {
                up = false;
            }

        }
        else
        {
            up = false;
        }

        // Check for collisions below
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1.0f))
        {
            if (hit.distance < 1.0f)
            {
                down = true;

            }
            else
            {
                down = false;
            }
        }
        else
        {
            down = false;
        }

        // Check for collisions to the left
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1.0f))
        {
            if (hit.distance < 1.0f)
            {
                left = true;

            }
            else
            {
                left = false;
            }
        }
        else
        {
            left = false;
        }

        // Check for collisions to the right
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1.0f))
        {
            if (hit.distance < 1.0f)
            {
                right = true;

            }
            else
            {
                right = false;
            }
        }
        else
        {
            right = false;
        }
    }
}