using UnityEngine;
using System.Collections;

public class characterBehaviour : MonoBehaviour {

    public GameObject player;
    public int bombCount=1;
	public int rangeCount=2;
	public Vector3 tempPos;
    public bool p1 = false;
    public bool p2 = false;

	public GameObject bombPrefab;
	
	void start()
	{

	}


	void Update()
	{
       // Debug.Log(p1 + " " + p2);
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
        
		GameObject bomb = Instantiate (bombPrefab, transform.position, Quaternion.identity) as GameObject;
        Debug.Log(bomb);
        bomb.GetComponent<bombScript>().placer = gameObject.GetComponent<characterBehaviour>();
        if (player.tag == "Player1")
        {
            Debug.Log("Bomb Down p1");
            p1 = true;
            p2 = false;
        }
        else if (player.tag == "Player2")
        {
            Debug.Log("Bomb Down p2");
            p1 = false;
            p2 = true;
        }

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
