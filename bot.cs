using UnityEngine;
using System.Collections;
using System;

public class bot : MonoBehaviour {
        int port;
        string buf, nick, owner, server, chan, pass, command;
        char[] splitter = { ':' };
        System.Net.Sockets.TcpClient sock = new System.Net.Sockets.TcpClient();
        System.IO.TextReader input;
        System.IO.TextWriter output;

       
	// Use this for initialization
	void Awake () {
       
        //Get nick, owner, server, port, and channel from user
        pass = "";
        nick = "lightzors";
        owner = "lightzors";
        server = "irc.twitch.tv";
        port = 6667;
        chan = "#fifaralle";

        //Connect to irc server and get input and output text streams from TcpClient.
        sock.Connect(server, port);
        if (!sock.Connected)
        {
            Debug.Log("Failed to connect!");
        }
        else
        {
            input = new System.IO.StreamReader(sock.GetStream());
            output = new System.IO.StreamWriter(sock.GetStream());
            output.Write(
              "PASS " + pass + "\r\n" + "USER " + nick + " 0 * :" + owner + "\r\n" +
              "NICK " + nick + "\r\n"
           );
            output.Flush();
            StartCoroutine(Refresh());
        }
	
	 //Starting USER and NICK login commands 
           
}
	// Update is called once per frame
    IEnumerator Refresh()
    {
        while (true)
        {
            buf = input.ReadLine();
            command = buf.Split(splitter)[buf.Split(splitter).Length - 1];
            //Display received irc message
            Debug.Log(buf);

            switch (command)
            {
                case "ping":
                    Debug.Log("fuckyeah");
                    break;
            }
            if (buf.Split(' ')[1] == "001")
            {
                output.Write(
                   "MODE " + nick + " +B\r\n" +
                   "JOIN " + chan + "\r\n"
                );
                output.Flush();
            }
            yield return new WaitForSeconds(1f);
        }

    }
}
