using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay(Collider target) {
		
		if(target.gameObject.name == "Player"){
			collider.isTrigger = true;
		}
	}

	void OnTriggerExit(Collider target) {
		if(target.gameObject.name == "Player"){
			collider.isTrigger = false;
		}
	}
	
}
