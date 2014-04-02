using UnityEngine;
using System.Collections;
using System;

public class bot : MonoBehaviour
{
    // Variable list
    // Controls and IRC setup;
    public string gameCommand;
    int port;
    string buf, nick, owner, server, chan, pass, command;
    char[] splitter = { ':' };
    System.Net.Sockets.TcpClient sock = new System.Net.Sockets.TcpClient();
    System.IO.TextReader input;
    System.IO.TextWriter output;
    private string compare = "test";

    // Democracy
    public int option1, option2, option3, option4;

    // Use this for initialization
    void Awake()
    {

        //Get nick, owner, server, port, and channel from user
        pass = "oauth:qi7ukj6jfg0qudzxg08eso6gr3du4bw";
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
            //Input credentials
            input = new System.IO.StreamReader(sock.GetStream());
            output = new System.IO.StreamWriter(sock.GetStream());
            output.Write(
              "PASS " + pass + "\r\n" + "USER " + nick + " 0 * :" + owner + "\r\n" +
              "NICK " + nick + "\r\n"
           );
            output.Flush();
            //Initialize IRC checking
            StartCoroutine("Refresh");
        }

    }
    // Update is called once per frame

    void Update()
    {
        /*
                if (Time.time > nextRead)
                {
                    buf = input.ReadLine();
                    nextRead = Time.time + readRate;
                }

                if (Input.GetKeyUp("p"))
                {
                    read();
                    Debug.Log("DEMOCRACY STARTED");
                    //StartCoroutine("Democracy");
                }
          */
    }

    IEnumerator Refresh()
    {
        while (true)
        {
            Debug.Log(compare);
            //Split command line input to only display message
            if (compare != buf)
            {
                buf = input.ReadLine();
                compare = buf;
                command = buf.Split(splitter)[buf.Split(splitter).Length - 1];
                //Display received irc message
                Debug.Log(buf);

                //Filter messages
                switch (command)
                {
                    case "bomb":
                        gameCommand = "bomb";
                        break;
                    case "up":
                        gameCommand = "up";
                        break;
                    case "down":
                        gameCommand = "down";
                        break;
                    case "left":
                        gameCommand = "left";
                        break;
                    case "right":
                        gameCommand = "right";
                        break;

                    //Close IRC Stream
                    case "quit":
                        input.Close();
                        output.Close();
                        sock.Close();
                        StopCoroutine("Refresh");
                        break;
                }
                /*  if (buf.Split(' ')[1] == "001")
                  {
                      output.Write(
                         "MODE " + nick + " +B\r\n" +
                         "JOIN " + chan + "\r\n"
                      );
                      output.Flush();
                  }
                 * */
            }
            yield return new WaitForSeconds(0.1f);
        }

    }
    IEnumerator Democracy()
    {
        switch (command)
        {
            case "option1":
                option1 += 1;

                break;

            case "option2":
                option2 += 1;
                break;

            case "option3":
                option3 += 1;

                break;

            case "option4":
                option4 += 1;

                break;
        }
        yield return new WaitForEndOfFrame();
    }
}