using UnityEngine;
using System.Collections;

public class BuffSpawn : MonoBehaviour {
	public Transform buff1;
	private float x;
	private float y;
	private float z;


	// Use this for initialization
	void Start () {

		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDestroy() {

		if(Random.Range(0,4)>=3){
			Instantiate(buff1, new Vector3(x,y,z), Quaternion.identity);
		}


	}
}
