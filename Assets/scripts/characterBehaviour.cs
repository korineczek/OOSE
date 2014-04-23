using UnityEngine;
using System.Collections;

public class characterBehaviour : MonoBehaviour {

	public GUIText bombCountText;
	public int bombCount=1;
	public GUIText rangeCounterText;
	public int rangeCount=2;
	public Vector3 tempPos;
	public bool test1;

	public Rigidbody bombPrefab;
	//public GameObject explosionPrefab;
  //  private GameObject cloneUp, cloneDown, cloneRight, cloneLeft;
   // private bool test, test1, test2, test3;

	void start()
	{

	}


	void Update()
	{
		//triggerBomb ();
		/*cloneDown.GetComponent<explosionScript>().explodeDown();
		cloneUp.GetComponent<explosionScript>().explodeUp();
		cloneRight.GetComponent<explosionScript>().explodeRight();
		cloneLeft.GetComponent<explosionScript>().explodeLeft();
        */
	
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
		SetBombCountText();
		yield return new WaitForSeconds(3);
		/*cloneUp = Instantiate (explosionPrefab, tempPos + new Vector3 (0, 0, 1), bombPrefab.rotation) as GameObject;
		cloneDown = Instantiate (explosionPrefab, tempPos + new Vector3 (0, 0, -1), bombPrefab.rotation) as GameObject;
		cloneRight = Instantiate (explosionPrefab, tempPos + new Vector3 (1, 0, 0), bombPrefab.rotation) as GameObject;
		cloneLeft = Instantiate (explosionPrefab, tempPos + new Vector3 (-1, 0, 0), bombPrefab.rotation) as GameObject;*/
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

	void test()
	{
						
						
			
		}

	//Functon for Bomb GUI
	void SetBombCountText()
	{
		Debug.Log("called");
		bombCountText.text = "Bombs: " + bombCount.ToString();
	}

	//Functoin for Range GUI
	void SetRangeCountText()
	{
		int actualRange = rangeCount - 1;
		rangeCounterText.text = "Bomb Range: " + actualRange.ToString();
	}
	void OnGUI(){
		bombCountText.text = "Bombs: " + bombCount.ToString();
		SetRangeCountText();
	}

}
