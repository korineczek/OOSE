using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	public int explodeTimer;

	void Start ()
	{
		Destroy (gameObject, explodeTimer);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
	//Destroy Cubes and Player on Collision
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player")
		{
			Destroy(col.gameObject);
		}
		if(col.gameObject.name == "DestructableCube")
		{
			Destroy(col.gameObject);
		}
	}
}
