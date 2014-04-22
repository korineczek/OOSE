using UnityEngine;
using System.Collections;

public class bombScript : MonoBehaviour {

	public int explosionTurn;
    int currentTurn;
    int turnsToExplosion = 3;

    void Awake() { 
    
    }

	// Use this for initialization
	void Start ()
	{
        currentTurn = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().currentTurn; 
		explosionTurn = currentTurn+turnsToExplosion;
        Debug.Log(explosionTurn);
	}
    void Update()
    {
		StartCoroutine(destroy());
      /*  if (currentTurn == explosionTurn)
        {
            Destroy(gameObject);
        }*/
    }
	IEnumerator destroy()
	{
		if (currentTurn == explosionTurn)
		{
			yield return new WaitForSeconds(3);
			Destroy(gameObject);
		}
	}
}


