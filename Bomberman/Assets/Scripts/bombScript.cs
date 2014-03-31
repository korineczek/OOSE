using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {

	public int explodeTimer;


	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, explodeTimer);
	}
}




	