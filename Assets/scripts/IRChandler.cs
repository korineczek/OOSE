using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IRChandler : MonoBehaviour
{

    // Variable declaration
    Job myJob;
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

        Debug.Log(myJob.democracy);

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

    }

    IEnumerator Execute()
    {
        while (true)
        {
            if (myJob.action.Count > 0)
            {
                switch (myJob.action[Random.Range(0, myJob.action.Count)])
                {
                    case "bomb":
                        Debug.Log("Bomb down");

                        break;
                    case "up":
                        Debug.Log("Moved up");

                        break;
                    case "down":
                        Debug.Log("Moved down");

                        break;
                    case "left":
                        Debug.Log("Moved left");

                        break;
                    case "right":
                        Debug.Log("Moved right");
                        break;
                    default:
                        Debug.Log("NO INPUT");
                        break;
                }
            }
            myJob.action = new List<string>();
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

