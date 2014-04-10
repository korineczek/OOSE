using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IRChandler : MonoBehaviour
{

    // Variable declaration
    Job myJob;

    //public Movement playerControls;

    public string action;

    // Democracy mode
    float democracyStart;
    float democracyEnd;
    float democracyDuration;

   
    

    void Start()
    {

        

        // Define and start second thread containing the IRC bot.
        myJob = new Job();
        myJob.Start();
        
        // Set Democracy duration
        democracyDuration = 10.0f;

        // Start execution routine
        StartCoroutine("Execute");
    }

    // Update is called once per frame
    void Update()
    {
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

        // TEST - IN CLIENT TCP DISCONNECT
        if (Input.GetKeyUp("o"))
        {
            myJob.Abort();
            myJob.Start();
            myJob.Abort();
            StopAllCoroutines();
            Debug.Log("DISCONNECTED");
        }
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

    }

    IEnumerator Execute()
    {
        while (true)
        {
            if (myJob.action.Count > 0)
            {
               
                string debug = myJob.action[Random.Range(0, myJob.action.Count)];
                
                switch (debug)
                {
                    case "bomb":
                        Debug.Log("Bomb down");
                        
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
                for (int i = 0; i < myJob.action.Count; i++)
                {
                   // Debug.Log("clearing " + myJob.action[i]);
                    myJob.action.RemoveAt(i);
                    
                }
                myJob.command = null;
                myJob.temp = null;
            }
            yield return new WaitForSeconds(5.0f);
        }
    }


    // Democracy result function
    int calculateDemocracy(int[] data)
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

