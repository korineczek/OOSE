using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 lastPosition;
    public Vector3 endpos;
    public bool moving = false;
	private bool objectHitUp;
	private bool objectHitDown;
	private bool objectHitRight;
	private bool objectHitLeft;
	RaycastHit hit;
    

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

   public void moveUp()
    {
		rayCast ();
		if (objectHitUp == false) {
						moving = true;
						endpos = transform.position + Vector3.forward;
		}
	}
    public void moveDown()
    {
		
		rayCast ();
		if (objectHitDown == false) {
						moving = true;
						endpos = transform.position + Vector3.back;
				}
    }
    public void moveLeft()
    {
		rayCast ();
		if (objectHitLeft == false) {
						moving = true;
						endpos = transform.position + Vector3.left;
				}
    }
    public void moveRight()
    {
		
		rayCast ();
		if (objectHitRight == false) {
						moving = true;
						endpos = transform.position + Vector3.right;
				}
    }
	public void rayCast()
	{
		Vector3 up = transform.TransformDirection (Vector3.forward);
		Vector3 down = transform.TransformDirection (Vector3.back);
		Vector3 right = transform.TransformDirection (Vector3.right);
		Vector3 left = transform.TransformDirection (Vector3.left);
		
		if (Physics.Raycast (endpos, up, out hit)) {
			if (hit.collider.gameObject.tag == "Wall"&& hit.distance<1.0) {
				Debug.Log ("HitUp"+ hit.distance);
				objectHitUp = true;
			}
		} else
			noObjectHit ();
		
		if (Physics.Raycast (endpos, down, out hit)) {
			if (hit.collider.gameObject.tag == "Wall" && hit.distance<1.0) {
				Debug.Log ("HitDown" + hit.distance);
				objectHitDown = true;
			}
		} else
			noObjectHit ();
		
		if (Physics.Raycast (endpos, right, out hit)) {
			if (hit.collider.gameObject.tag == "Wall" && hit.distance<1.0) {
				Debug.Log ("HitRight"+ hit.distance);
				objectHitRight = true;
			}
		} else
			noObjectHit ();	
		
		if (Physics.Raycast (endpos, left, out hit)) {
			if (hit.collider.gameObject.tag == "Wall" && hit.distance<1.0) {
				Debug.Log ("HitLeft"+ hit.distance);
				objectHitLeft = true;
			}
		} else
			noObjectHit ();
	}
	public void noObjectHit(){
		objectHitUp = false;
		objectHitDown = false;
		objectHitLeft = false;
		objectHitRight = false;
		
	}
}