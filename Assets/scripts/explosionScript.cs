using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	public int explodeTimer;
    public bool wallHit;
    
    
    //public float speed;
    //private Vector3 startPos;
    //private float distance;
 //   characterBehaviour player;

	public void Start ()
	{
       // startPos = transform.position;
		Destroy (gameObject, explodeTimer);
   //     player = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>();
  
	}

	
	// Update is called once per frame
   public  void Update()
    {
        
    
   }
	//Destroy Cubes and Player on Collision
	public void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player1")
		{
			Destroy(col.gameObject);
		}
        if (col.gameObject.tag == "DestructableCube")
        {
            Destroy(col.gameObject);
            Destroy(gameObject, explodeTimer);
        }

		if(col.gameObject.tag == "Wall")
		{
            wallHit = true;
			Destroy(gameObject);
		}
	}
 /*   public void explodeRight()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(2, 0, 0), Time.deltaTime * speed);
        distance =Vector3.Distance( transform.position, startPos);
        if (distance>player.rangeCount-1)
            Destroy(gameObject);
    }
   public void explodeLeft()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
       transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-2, 0, 0), Time.deltaTime * speed);
        distance = Vector3.Distance(startPos, transform.position);
        if (distance > player.rangeCount-1)
            Destroy(gameObject);
    }
    public void explodeUp()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, 2), Time.deltaTime * speed);
        distance = Vector3.Distance(transform.position, startPos);
        if (distance > player.rangeCount-1)
            Destroy(gameObject);
    }
    public void explodeDown()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, -2), Time.deltaTime * speed);
        distance = Vector3.Distance(startPos, transform.position);
        if (distance > player.rangeCount-1)
            Destroy(gameObject);
    }*/
}
