11/04/2014 - v0.3 - CURRENT VERSION
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