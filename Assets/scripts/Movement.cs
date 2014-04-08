using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;

    public Vector3 lastPosition;
    public Vector3 endpos;
    public bool moving = false;
    

    void Start()
    {
        endpos = transform.position;
    }

    void Update()
    {

        if (moving && (transform.position == endpos))
            moving = false;


        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision other)
    {

        /*	if (other.gameObject.tag != "DestructableCube") 
                lastPosition = transform.position;
    */

        if (other.gameObject.tag == "DestructableCube")
            transform.position = endpos;
    }
   public void moveUp()
    {
        moving = true;
        endpos = transform.position + Vector3.forward;

    }
    public void moveDown()
    {
        moving = true;
        endpos = transform.position + Vector3.back;

    }
    public void moveLeft()
    {
        moving = true;
        endpos = transform.position + Vector3.left;

    }
    public void moveRight()
    {
        moving = true;
        endpos = transform.position + Vector3.right;

    }
}