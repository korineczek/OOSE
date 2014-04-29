using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

    int rangeCount1;
    int bombCount1;
    int rangeCount2;
    int bombCount2;
    int red;
    int blue;

	// Use this for initialization
	void Start () {
 	}
	
	// Update is called once per frame
	void Update () {

        rangeCount1 = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().rangeCount;
        bombCount1 = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().bombCount;
        red = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().redplayers;
        blue = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().blueplayers;

        rangeCount2 = GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().rangeCount;
        bombCount2 = GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().bombCount;
        OnGUI();
       // RangeGUI();
                
	}


    //Functon for Bomb GUI
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Bombs: "+ bombCount1.ToString());
        int actualRange1 = rangeCount1 - 1;
        GUI.Label(new Rect(10, 30, 100, 30), "Bomb Range: " + actualRange1.ToString());
        GUI.Label(new Rect(10, 50, 200, 30), "Red Players: " + red.ToString());


        GUI.Label(new Rect(700, 10, 100, 20), "Bombs: " + bombCount2.ToString());
        int actualRange2 = rangeCount2 - 1;
        GUI.Label(new Rect(700, 30, 100, 30), "Bomb Range: " + actualRange2.ToString());
        GUI.Label(new Rect(700, 50, 200, 30), "Blue Players: " + blue.ToString());

    }
}
