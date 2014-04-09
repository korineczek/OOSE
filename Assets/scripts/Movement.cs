using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    // Variable declaration
    public float speed = 1.0f;
    public Vector3 lastPosition;
    public Vector3 endpos;
    public bool moving = false;
    public bool up, down, left, right;
    RaycastHit hit;

    void Start()
    {
        endpos = transform.position;

    }

    void Update()
    {

        // Debug collisions in case of problems
        // Debug.Log(up + " " + down + " " + left + " " + right);

        // Check for collisions above
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

        // Check whether is the character moving
        if (moving && (transform.position == endpos))
            moving = false;

        // Update character's position
        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
    }


    // MOVEMENT FUNCTIONS, CALLED FROM IRChandler.cs
    public void moveUp()
    {
        if (up == true)
        {
            Debug.Log("cant move");
        }
        else
        {
            moving = true;
            endpos = transform.position + Vector3.forward;
        }
    }


    public void moveDown()
    {
        if (down == true)
        {
            Debug.Log("cant move");
        }
        else
        {

            moving = true;
            endpos = transform.position + Vector3.back;
        }
    }

    public void moveLeft()
    {
        if (left == true)
        {
            Debug.Log("cant move");
        }
        else
        {
            moving = true;
            endpos = transform.position + Vector3.left;
        }
    }
    public void moveRight()
    {
        if (right == true)
        {
            Debug.Log("cant move");
        }
        else
        {
            moving = true;
            endpos = transform.position + Vector3.right;
        }
    }
}