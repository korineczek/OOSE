28/04/2014 - v1.0 - CURRENT VERSION
Changelog
---------------------

FIRST RELEASE VERSION
---------------------

MAJOR
---------------------
Game is now in a playable state, both characters can be controlled, 95% of the game mechanics are in place.

HOW TO SET UP
---------------------
The game is a bomberman-like game controlled via IRC chat. The game can be set up on any IRC channel, even
though it is optimized for twitch.tv IRC channels.

In order to set up the IRC bot that passes the commands, it is necessary to input the credentials into the
IRChandler.cs script. IRChandler takes care of all command acquisition and parsing from the IRC and subsequently
allows the game to be played.

Once the bot is set up, the game can be launched.
Once the game is launched, it is advisable to wait a few seconds before inputting any commands, since the bot
is connecting to the IRC at that point.

HOW TO PLAY
---------------------
Once the game is initialized, it is ready to play. To start playing, the players have to join a team of their choice first.
That is done by using the command "joinred" or joinblue". Once assigned, other commands are unlocked. These are:

up
down
left
right
bomb

These input commands are sent to the IRChandler where they are executed every second, making for a turn-based
game.
---------------------



11/04/2014 - v0.3
Changelog
---------------------

Third playable version

---------------------
MAJOR
---------------------
-Added team system
-Player now have to pick a team  prior to being able to participate in the game
-Their team picks are reflected in the two team lists that are the players added to.
-Commands are now compared with the list to see which team are they playing for.

---------------------
MINOR
---------------------
-Irrelevant commands will not be passed to the main command switch anymore.

09/04/2014 - v0.2
Changelog
---------------------

Second playable version

---------------------
MAJOR
---------------------
-Added collision system, it is now impossible to move through obstacles

 
08/04/2014 - v0.1
Changelog
---------------------

First playable version, Twitch chat integration working as intended.

---------------------
MAJOR
---------------------
-Player 1 is now controllable via chat online

-Added controls include - Movement (up, down, left, right)

---------------------
MINOR
---------------------
-Fixed pseudo-democracy bug

-Commands are now passed correctly. In previous versions, if a command was passed to the player, the next non-command line would still register as the last command used.
This is fixed by clearing all variables after every 5.0s turn.

-Map size changed to 10x10 for testing purposes

-Started tracking changes in README.