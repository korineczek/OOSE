using UnityEngine;
using System.Collections;

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
        myJob = new Job();
        myJob.Start();
        democracyDuration = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(myJob.democracy);

        if (myJob != null)
        {
            action = myJob.action;
        }
        // Run democracy

        // Democracy start sequence
        if (Input.GetKeyUp("p") && myJob.democracy == false)
        {
            myJob.democracy = true;
            democracyStart = Time.time;
            Debug.Log("Democracy Started");
            democracyEnd = democracyStart + democracyDuration;
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
            int result = calculateDemocracy(myJob.optionHistogram);
            Debug.Log("Winner is Option " + result);
        }


        if (Input.GetKeyUp("o"))
        {
        }


    }
    void OnDestroy()
    {
        myJob.commandFromOutside = "quit";
    }

    int calculateDemocracy(int [] data)
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

