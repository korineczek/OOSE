using UnityEngine;
using System.Collections;

public class characterBehaviour : MonoBehaviour {

	//public GUIText bombCountText;
	public int bombCount=1;
	//public GUIText rangeCounterText;
	public int rangeCount=2;
	public Vector3 tempPos;
	public bool test1;

	public Rigidbody bombPrefab;
	
	void start()
	{

	}


	void Update()
	{
	}


	//Code for triggering spawn
	public void triggerBomb()
	{
			if (bombCount > 0)
		{
			
				StartCoroutine(currentBombs());
			
		}
	}

	//Code for the bomb spawn and the amount available
	IEnumerator currentBombs()
	{
		Instantiate (bombPrefab, transform.position, transform.rotation);
		tempPos = transform.position;
		bombCount = bombCount -1;
		//SetBombCountText();
		yield return new WaitForSeconds(12);
		bombCount = bombCount+1;
		//SetBombCountText();

	}

	//Code for collision with BombPickup
	void OnTriggerEnter(Collider other)
	{
				if (other.gameObject.tag == "BombPickup") {
						Destroy (other.gameObject);
						bombCount = bombCount + 1;
						//SetBombCountText ();
				}
				if (other.gameObject.tag == "RangePickup") {
						Destroy (other.gameObject);
						rangeCount = rangeCount + 1;
						//SetRangeCountText ();
				}
	}

}
