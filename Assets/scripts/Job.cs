using System;
using System.Collections.Generic;

public class Job : ThreadedJob
{
    // Variables

    // Command Control
    public List<string> action = new List<string>();
    public string temp;
    public string commandFromOutside;
    public bool democracy;
    public int[] optionHistogram = { 0, 0, 0, 0 };

    // TCP configuration, if not working, return it to ThreadFunction()
    public System.Net.Sockets.TcpClient sock = new System.Net.Sockets.TcpClient();
    public System.IO.TextReader input;
    public System.IO.TextWriter output;

    public Job(){
    }

    protected override void ThreadFunction()
    {

        int port;
        string buf, nick, owner, server, chan, pass, command;
        char[] splitter = { ':' };
       

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
            Console.WriteLine("Failed to connect!");
            return;
        }
        input = new System.IO.StreamReader(sock.GetStream());
        output = new System.IO.StreamWriter(sock.GetStream());

        //Starting USER and NICK login commands 
        output.Write(
           "PASS " + pass + "\r\n" + "USER " + nick + " 0 * :" + owner + "\r\n" +
           "NICK " + nick + "\r\n"
        );
        output.Flush();

        //Process each line received from irc server
        for (buf = input.ReadLine(); ; buf = input.ReadLine())
        {
            command = buf.Split(splitter)[buf.Split(splitter).Length - 1];
            //Display received irc message
            Console.WriteLine(buf);

            switch (command)
            {
                case "bomb":
                    temp = "bomb";
                    
                    break;
                case "up":
                    temp = "up";
                   
                    break;
                case "down":
                    temp = "down";
                    
                    break;
                case "left":
                    temp = "left";
                    
                    break;
                case "right":
                    temp = "right";
                    
                    break;

                case "option1":
                    if (democracy == true)
                    {
                        optionHistogram[0] += 1;
                    
                    }
                    break;
                case "option2":
                    if (democracy == true)
                    {
                        optionHistogram[1] += 1;

                    }
                    break;
                case "option3":
                    if (democracy == true)
                    {
                        optionHistogram[2] += 1;

                    }
                    break;
                case "option4":
                    if (democracy == true)
                    {
                        optionHistogram[3] += 1;

                    }
                    break;

                case "quit":
                    input.Close();
                    output.Close();
                    sock.Close();
                    return;
            }

            // Add selected option to list, if there is too many options, the oldest one gets deleted to make space
            if (action.Count < 6)
            {
                action.Add(temp);
            }
            else
            {
                action.RemoveAt(0);
                action.Add(temp);
            }
            
           
            
            
            // Send pong reply to any ping messages
            if (buf.StartsWith("PING"))
            {
                Console.WriteLine("ping");
            }
            // { output.Write(buf.Replace("PING", "PONG") + "\r\n"); output.Flush(); }
            if (buf[0] != ':') continue;

            /* IRC commands come in one of these formats:
             * :NICK!USER@HOST COMMAND ARGS ... :DATA\r\n
             * :SERVER COMAND ARGS ... :DATA\r\n
             */

            //After server sends 001 command, we can set mode to bot and join a channel
            if (buf.Split(' ')[1] == "001")
            {
                output.Write(
                   "MODE " + nick + " +B\r\n" +
                   "JOIN " + chan + "\r\n"
                );
                output.Flush();
            }
        }

    }


    protected override void OnFinished()
    {

    }
}