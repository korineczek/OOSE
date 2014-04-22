using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {

	public int explosionTurn;
    int currentTurn;
    int turnsToExplosion = 2;

    void Awake() { 
    
    }

	// Use this for initialization
	void Start ()
	{   
		explosionTurn = currentTurn+turnsToExplosion;
	}

    void Update()
    {
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn; 
        Debug.Log(currentTurn + " " + explosionTurn);
       
        if (currentTurn == explosionTurn)
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        // EXPLOSION GOES HERE
    }
}


