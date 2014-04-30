using UnityEngine;
using System.Collections;

public class BuffScript : MonoBehaviour {

	//This scripts only purpose is to destroy the buffs when you quit the application, this might be supject to change and be on reset instead. 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnApplicationQuit(){//Runs when the application is quitting.

		Destroy(this.gameObject);//Destroy the gameobject.
	}
}
