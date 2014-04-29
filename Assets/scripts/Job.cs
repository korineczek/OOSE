using System;
using System.Collections.Generic;

// Declare player class
public class Player
{
    public string name;
    public int team;

    // Player constructor
    public Player(string id, int allegiance)
    {
        name = id;
        team = allegiance;
    }
}

public class Command
{
    public string command;
    public int team;
}


public class Job : ThreadedJob
{
    // Variables
    public int numberofredplayers = 0;
    public int numberofblueplayers = 0;

    // Command Control
    public Command playerInput = new Command();
    public string rawData;
    public List<string> redAction = new List<string>();
    public List<string> blueAction = new List<string>();

    // Team Control
    public List<Player> teamRed = new List<Player>();
    public List<Player> teamBlue = new List<Player>();
    public Player isInTeamRed;
    public Player isInTeamBlue;

    public string redTemp, blueTemp, nickname, message;
    public string command, name;
    public bool democracy;
    public int[] optionHistogram = { 0, 0, 0, 0 };

    // TCP configuration, if not working, return it to ThreadFunction()
    public System.Net.Sockets.TcpClient sock = new System.Net.Sockets.TcpClient();
    public System.IO.TextReader input;
    public System.IO.TextWriter output;

    public Job()
    {
    }

    public global::explosionScript explosionScript
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    protected override void ThreadFunction()
    {

        int port;
        string buf, nick, owner, server, chan, pass;
        char[] splitter = { ':' };
        char[] nameSplitter = { '!' };


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
            // Get sender name and command from IRC
            name = buf.Split(nameSplitter)[0];
            rawData = buf.Split(splitter)[buf.Split(splitter).Length - 1];

            // Search player lists to identify player allegiance
            isInTeamRed = teamRed.Find(item => item.name == name);
           
            if (rawData == "joinred" || rawData == "joinblue")
            {
                playerInput.command = rawData;
            }
            else if (isInTeamRed == null)
            {
                isInTeamBlue = teamBlue.Find(item => item.name == name);
                
                if(isInTeamBlue != null){
                    playerInput.team = 1;
                    playerInput.command = rawData;
                }

                
            }
            else if (isInTeamRed != null)
            {
                playerInput.team = 0;
                playerInput.command = rawData;
            }
            else
            {
                    playerInput.command = null;
            }

            


            if (playerInput.command != null)
            {
                switch (playerInput.command)
                {
                    case "bomb":
                        if (playerInput.team == 0)
                        {
                            redTemp = "bomb";
                        }
                        else if (playerInput.team == 1)
                        {
                            blueTemp = "bomb";
                        }

                        break;
                    case "up":
                        if (playerInput.team == 0)
                        {
                            redTemp = "up";
                        }
                        else if (playerInput.team == 1)
                        {
                            blueTemp = "up";
                        }

                        break;
                    case "down":
                        if (playerInput.team == 0)
                        {
                            redTemp = "down";
                        }
                        else if (playerInput.team == 1)
                        {
                            blueTemp = "down";
                        }
                        break;
                    case "left":
                        if (playerInput.team == 0)
                        {
                            redTemp = "left";
                        }
                        else if (playerInput.team == 1)
                        {
                            blueTemp = "left";
                        }

                        break;
                    case "right":
                        if (playerInput.team == 0)
                        {
                            redTemp = "right";
                        }
                        else if (playerInput.team == 1)
                        {
                            blueTemp = "right";
                        }

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

                    // Join the red team
                    case "joinred":

                        isInTeamBlue = teamBlue.Find(item => item.name == name);
                        if (isInTeamBlue != null)
                        {
                            teamBlue.Remove(isInTeamBlue);
                            isInTeamBlue = null;
                            numberofblueplayers--;
                        }

                        isInTeamRed = teamRed.Find(item => item.name == name);
                        if (isInTeamRed == null)
                        {
                            teamRed.Add(new Player(name, 0));
                            isInTeamRed = null;
                            numberofredplayers++;
                        }
                        break;

                    // Join the blue team
                    case "joinblue":
                        isInTeamRed = teamRed.Find(item => item.name == name);
                        if (isInTeamRed != null)
                        {
                            teamRed.Remove(isInTeamRed);
                            isInTeamRed = null;
                            numberofredplayers--;
                        }
                        isInTeamBlue = teamBlue.Find(item => item.name == name);
                        if (isInTeamBlue == null)
                        {
                            teamBlue.Add(new Player(name, 1));
                            isInTeamBlue = null;
                            numberofblueplayers++;
                        }
                        break;


                    // Quit command to disconnect IRC via chat
                    case "quit":
                        input.Close();
                        output.Close();
                        sock.Close();
                        return;
                }
            }


            // Add selected option to list, if there is too many options, the oldest one gets deleted to make space
            // Team Red
            if (redAction.Count < 6)
            {
                redAction.Add(redTemp);
            }
            else
            {
                redAction.RemoveAt(0);
                redAction.Add(redTemp);
            }

            // Team Blue
            if (blueAction.Count < 6)
            {
                blueAction.Add(blueTemp);
            }
            else
            {
                blueAction.RemoveAt(0);
                blueAction.Add(blueTemp);
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