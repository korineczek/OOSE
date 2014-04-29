using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IRChandler : MonoBehaviour
{

    // Variable declaration
    Job myJob;

    //public Movement playerControls;

    public string action;
    public int redplayers, blueplayers;

    // Democracy mode
    float democracyStart;
    float democracyEnd;
    float democracyDuration;

    // Turn Counter
    public int currentTurn;
    

    void Start()
    {

        

        // Define and start second thread containing the IRC bot.
        myJob = new Job();
        myJob.Start();
        
        // Set Democracy duration
        democracyDuration = 10.0f;

        // Start execution routine
        StartCoroutine("Execute");

        // Set turn count to 0
        currentTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        redplayers = myJob.numberofredplayers;
        blueplayers = myJob.numberofblueplayers;
        Debug.Log(myJob.numberofredplayers + " " + myJob.numberofblueplayers);
        //Debug.Log(myJob.rawData);
        //Debug.Log(myJob.name +" "+myJob.command);
        
        
        // Run democracy
        // Democracy startup sequence
        if (Input.GetKeyUp("p") && myJob.democracy == false)
        {
            // Stop executing command 
            StopCoroutine("Execute");

            // Start democracy
            myJob.democracy = true;
            democracyStart = Time.time;
            Debug.Log("Democracy Started");
            democracyEnd = democracyStart + democracyDuration;

            // Reset democracy option count
            for (int i = 0; i < 4; i++)
            {
                myJob.optionHistogram[i] = 0;
            }
        }

        // Democracy in progress - ONLY FOR DEBUGGING
        if (myJob.democracy == true)
        {
            Debug.Log("DEMOCRACY IN PROGRESS");
        }

        // Democracy quit sequence
        if (Time.time > democracyEnd && myJob.democracy == true)
        {
            Debug.Log("Democracy Ended");
            myJob.democracy = false;

            // Get results from democracy
            int result = calculateDemocracy(myJob.optionHistogram);
            Debug.Log("Winner is Option " + result);

            // Start executing commands again
            StartCoroutine("Execute");
        }

        // IN CLIENT TCP DISCONNECT
        if (Input.GetKeyUp("o"))
        {
            myJob.Abort();
            myJob.Start();
            myJob.Abort();
            StopAllCoroutines();
            Debug.Log("DISCONNECTED");
        }

        // P1 KEYBOARD
        if (Input.GetKeyUp("w"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player1").GetComponent<Movement>().moveUp();
        }
        if (Input.GetKeyUp("s"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player1").GetComponent<Movement>().moveDown();
        }
        if (Input.GetKeyUp("a"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player1").GetComponent<Movement>().moveLeft();
        }
        if (Input.GetKeyUp("d"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player1").GetComponent<Movement>().moveRight();
        }
        if (Input.GetKeyUp("space"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().triggerBomb();
        }
        //P2 KEYBOARD CONTROLS
        if (Input.GetKeyUp("i"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player2").GetComponent<Movement>().moveUp();
        }
        if (Input.GetKeyUp("k"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player2").GetComponent<Movement>().moveDown();
        }
        if (Input.GetKeyUp("j"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player2").GetComponent<Movement>().moveLeft();
        }
        if (Input.GetKeyUp("l"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player2").GetComponent<Movement>().moveRight();
        }
        if (Input.GetKeyUp("m"))
        {
            //Debug.Log("Moving Up");
            GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().triggerBomb();
        }


        if (Input.GetKeyUp("x"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator Execute()
    {
        while (true)
        {
            if (myJob.redAction.Count > 0)
            {
               
                string redAction = myJob.redAction[Random.Range(0, myJob.redAction.Count)];
                string blueAction = myJob.blueAction[Random.Range(0, myJob.redAction.Count)];
                
                // Red Action Command Execution
                switch (redAction)
                {
                    case "bomb":
                        Debug.Log("Bomb down");
                        GameObject.FindWithTag("Player1").GetComponent<characterBehaviour>().triggerBomb();
                        break;
                    case "up":
                        Debug.Log("Moved up");
                        GameObject.FindWithTag("Player1").GetComponent<Movement>().moveUp();
                        
                        break;
                    case "down":
                        Debug.Log("Moved down");
                        GameObject.FindWithTag("Player1").GetComponent<Movement>().moveDown();
                        
                        break;
                    case "left":
                        Debug.Log("Moved left");
                        GameObject.FindWithTag("Player1").GetComponent<Movement>().moveLeft();
                    
                        break;
                    case "right":
                        Debug.Log("Moved right");
                        GameObject.FindWithTag("Player1").GetComponent<Movement>().moveRight();
                        
                        break;
                    default:
                         // Debug.Log("NO INPUT");
                        break;
                }

                // Clear RedCommand Cache
                for (int i = 0; i < myJob.redAction.Count; i++)
                {
                   // Debug.Log("clearing " + myJob.action[i]);
                    myJob.redAction.RemoveAt(i);
                    
                }

                // MYJOB.COMMAND CAN POTENTALLY BE DELETED, NEED TESTING!
                myJob.command = null;
                myJob.redTemp = null;

            // Blue Action Command Execution
            switch (blueAction)
                {
                    case "bomb":
                        Debug.Log("Bomb down");
                        GameObject.FindWithTag("Player2").GetComponent<characterBehaviour>().triggerBomb();
                        break;
                    case "up":
                        Debug.Log("Moved up");
                        GameObject.FindWithTag("Player2").GetComponent<Movement>().moveUp();
                        
                        break;
                    case "down":
                        Debug.Log("Moved down");
                        GameObject.FindWithTag("Player2").GetComponent<Movement>().moveDown();
                        
                        break;
                    case "left":
                        Debug.Log("Moved left");
                        GameObject.FindWithTag("Player2").GetComponent<Movement>().moveLeft();
                    
                        break;
                    case "right":
                        Debug.Log("Moved right");
                        GameObject.FindWithTag("Player2").GetComponent<Movement>().moveRight();
                        
                        break;
                    default:
                         // Debug.Log("NO INPUT");
                        break;
                }
                for (int i = 0; i < myJob.blueAction.Count; i++)
                {
                   // Debug.Log("clearing " + myJob.action[i]);
                    myJob.blueAction.RemoveAt(i);
                    
                }
                myJob.command = null;
                myJob.blueTemp = null;
            }

            // Increment turn and wait 5s to end the turn
            currentTurn++;
            yield return new WaitForSeconds(1.0f);
        }
    }


    // Democracy result function
    public int calculateDemocracy(int[] data)
    {
        int temp = 0;
        int result = 0;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] > temp)
            {
                temp = data[i];
                result = i + 1;
            }
        }
        return result;
    }
}

