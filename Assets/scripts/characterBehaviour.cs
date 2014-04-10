using UnityEngine;
using System.Collections;

public class characterBehaviour : MonoBehaviour {

	public GUIText bombCountText;
	private int bombCount=1;
	public GUIText rangeCounterText;
	private int rangeCount=2;

	public Rigidbody bombPrefab;
	public Transform playerCenter;
	public GameObject explosionPrefab;



	void start()
	{
		SetBombCountText();
		SetRangeCountText ();

	}


	void Update()
	{
		//triggerBomb ();
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
		Vector3 tempPos = transform.position;
		bombCount = bombCount -1;
		SetBombCountText();
		yield return new WaitForSeconds(3);
		Instantiate (explosionPrefab,tempPos,bombPrefab.rotation);
		for (int i = 0; i<rangeCount; i++) 
		{
			Instantiate (explosionPrefab,tempPos + new Vector3(0,0,i),bombPrefab.rotation);
			Instantiate (explosionPrefab,tempPos - new Vector3(0,0,i),bombPrefab.rotation);
			Instantiate (explosionPrefab,tempPos + new Vector3(i,0,0),bombPrefab.rotation);
			Instantiate (explosionPrefab,tempPos - new Vector3(i,0,0),bombPrefab.rotation);
		}
		bombCount = bombCount+1;
		SetBombCountText();

	}

	//Code for collision with BombPickup
	void OnTriggerEnter(Collider other)
	{
				if (other.gameObject.tag == "BombPickup") {
						Destroy (other.gameObject);
						bombCount = bombCount + 1;
						SetBombCountText ();
				}
				if (other.gameObject.tag == "RangePickup") {
						Destroy (other.gameObject);
						rangeCount = rangeCount + 1;
						SetRangeCountText ();
				}
	}
	//Functon for Bomb GUI
	void SetBombCountText ()
	{
		bombCountText.text = "Bombs: " + bombCount.ToString ();
	}

	//Functoin for Range GUI
	void SetRangeCountText ()
	{
		int actualRange = rangeCount - 1;
		rangeCounterText.text = "Bomb Range: " + actualRange.ToString ();
	}

}
