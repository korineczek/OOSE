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
        endpos = transform.position;                                                                                                        //sets the endpos equal to the transform.positoin

    }

    void Update()
    {
        //Checks for collision above
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1.0f))                                                            //casts a ray forward with the length of 1.0
        {
			if (hit.distance < 1.0f && (hit.transform.gameObject.tag != "BombPickup" && hit.transform.gameObject.tag != "RangePickup")){    //if the hit.distance is less than 1 and it doesn't hit BombPickup or RangePickup
			    up = true;                                                                                                                  //then up is true
				}
            else
            {
                up = false;                                                                                                                 //else it is false
            }

        }
        else
        {
            up = false;                                                                                                                     //if ray hits nothing up is false
        }

        // Check for collisions below, same concept as above but in different direction
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1.0f))
        {
			if (hit.distance < 1.0f && (hit.transform.gameObject.tag != "BombPickup" && hit.transform.gameObject.tag != "RangePickup"))
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

        // Check for collisions to the left, same as above but in different direction
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1.0f))
        {
				if (hit.distance < 1.0f && (hit.transform.gameObject.tag != "BombPickup" && hit.transform.gameObject.tag != "RangePickup"))
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

        // Check for collisions to the right, same as above but in different direction
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1.0f))
        {
			if (hit.distance < 1.0f && (hit.transform.gameObject.tag != "BombPickup" && hit.transform.gameObject.tag != "RangePickup"))
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
        if (moving && (transform.position == endpos))                                                                                      //if the object is moving and its transform.position is equal to endpos         
            moving = false;                                                                                                                //then moving is set to false

        // Update character's position
        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);                                      //Moves the character based on the endpos, which is updated in methods below
    }


    // MOVEMENT FUNCTIONS, CALLED FROM IRChandler.cs
    public void moveUp()
    {
        if (up == true)                                                                                                                     //if the raycast detects a collision above
        {
            Debug.Log("cant move");                                                                                                         //it debugs can't move
        }
        else
        {
            moving = true;                                                                                                                  //else moving is set to true
            endpos = transform.position + Vector3.forward;                                                                                  //and endpos is changed, such that the character will move forward
        }
    }

    //Same concept as moving up, but in a different direction
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

    //Same concept as moving up, but in a different direction
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

    //Same concept as moving up, but in a different direction
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