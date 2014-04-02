using UnityEngine;
using System.Collections;

public class IRChandler : MonoBehaviour {


    Job myJob;
    public string action;
    // Use this for initialization
	void Start () {
        myJob = new Job();
        myJob.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if (myJob != null)
        {
            action = myJob.action;
        }
        
        Debug.Log(action);

	}
    void OnDestroy()
    {
        myJob.commandFromOutside = "quit";
    }
}
