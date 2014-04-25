using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

    int rangeCount;
    int bombCount;

	// Use this for initialization
	void Start () {
 	}
	
	// Update is called once per frame
	void Update () {

        rangeCount = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().rangeCount;
        bombCount = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().bombCount;

        OnGUI();
       // RangeGUI();
                
	}


    //Functon for Bomb GUI
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Bombs: "+ bombCount.ToString());
        int actualRange = rangeCount - 1;
        GUI.Label(new Rect(10, 30, 100, 30), "Bomb Range: " + actualRange.ToString());
    }
}
