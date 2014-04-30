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

        rangeCount1 = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().rangeCount;              //gets the rangeCount from player1
        rangeCount2 = GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().rangeCount;              //gets the rangeCount from player2
        bombCount1 = GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().bombCount;                //gets the bombCount from player1
        bombCount2 = GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().bombCount;                //gets the bombCount from player2
        red = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().redplayers;                              //gets the amount of players on team red from the IRChandler
        blue = GameObject.FindWithTag("Handler").GetComponent<IRChandler>().blueplayers;                            //gets the amount of players on team blue from the IRChandler
        
        OnGUI();                                                                                                    //runs the OnGUI method

	}


    //FUNCTION FOR THE GUI
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Bombs: "+ bombCount1.ToString());                                     //displays the bombcount for player 1
        int actualRange1 = rangeCount1 - 1;                                                                         //sets the actual rangeCount
        GUI.Label(new Rect(10, 30, 100, 30), "Bomb Range: " + actualRange1.ToString());                             //displays the bombRange for player1
        GUI.Label(new Rect(10, 50, 200, 30), "Red Players: " + red.ToString());                                     //displayys the amount of players on team red


        GUI.Label(new Rect(1200, 10, 100, 20), "Bombs: " + bombCount2.ToString());                                  //displays the bombcount for player 2               
        int actualRange2 = rangeCount2 - 1;                                                                         //sets the actual rangeCount
        GUI.Label(new Rect(1200, 30, 100, 30), "Bomb Range: " + actualRange2.ToString());                           //displays the bombRange for player2
        GUI.Label(new Rect(1200, 50, 200, 30), "Blue Players: " + blue.ToString());                                 //displayys the amount of players on team blue

    }
}
