using System;
public class Job : ThreadedJob
{
    public string action;
    public string commandFromOutside;

    public Job(){
        action = "x";
    }

    protected override void ThreadFunction()
    {

        int port;
        string buf, nick, owner, server, chan, pass, command;
        char[] splitter = { ':' };
        System.Net.Sockets.TcpClient sock = new System.Net.Sockets.TcpClient();
        System.IO.TextReader input;
        System.IO.TextWriter output;

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
                    action = "bomb";
                    break;
                case "up":
                    action = "up";
                    break;
                case "down":
                    action = "down";
                    break;
                case "left":
                    action = "left";
                    break;
                case "right":
                    action = "right";
                    break;

                case "quit":
                    input.Close();
                    output.Close();
                    sock.Close();
                    return;
            }
            if (commandFromOutside == "quit")
            {
                input.Close();
                output.Close();
                sock.Close();
                return;
            }

            //Send pong reply to any ping messages
            if (buf.StartsWith("PING"))
            {
                Console.WriteLine("ping");
            }
            //{ output.Write(buf.Replace("PING", "PONG") + "\r\n"); output.Flush(); }
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