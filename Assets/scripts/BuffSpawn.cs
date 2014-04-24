using UnityEngine;
using System.Collections;

public class BuffSpawn : MonoBehaviour {
	public Transform buff1;
	public Transform buff2;
	private float x;
	private float y;
	private float z;
	private bool Quitting;
	private int number;


	// Use this for initialization
	void Start () {

		Quitting = false;
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnApplicationQuit(){

		Quitting = true;
	}

	void OnDestroy() {
		if(Quitting == false){
		if(Random.Range(0,4)>=3){
			number = Random.Range(0,2);
			switch (number)
				       {
					case 0:
						Instantiate(buff1, new Vector3(x,y,z), Quaternion.identity);
						break;
					case 1:
						Instantiate(buff2, new Vector3(x,y,z), Quaternion.identity);
						break;
					default:
						break;					
				
				}
			}
		}

	}
}
