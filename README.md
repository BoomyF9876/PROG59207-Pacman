

# Artificial Intelligence for Games PROG59207 
# Assignment #1

## Due Date:
* See SLATE 

## Assignment Type:
* All assignments must be completed as individual efforts unless stated otherwise. Please refer to the Academic Dishonesty Policy.
* Any attempt at cheating on an assignment/quiz/exam will result in a grade of zero for that particular assessment. Documentation on Student Code of Conduct can be found here.

## Submission: 
* Your Unity project should be a ZIP submitted through SLATE. 
* Only the last submission is accepted and marked, all other submissions are ignored.
* Your project must compile and run to receive any marks. Programs that do not run or compile will receive a grade of zero
* You MUST remove unnecessary files to submit so your archive size is small
* It is recommended to download the repo as a ZIP from GitLab. This will contain only what is stored in the repo and should be a working build

## Summary: 
* This assignment is based off FSM
* Make sure you follow the instructions
* If you have any questions regarding the assignment, contact me.
* If there are any issues within the loading engine do not hesitate to contact me.

## Assignment:

Pac-Man!! Your task is to implement the AI for the Ghosts. You must create AI for all 4 ghosts and they should act differently than each other (similar to Pac-Man if possible but not required). For this assignment you must create an FSM using the Unity Animator Controller as in class.

Based off our FSM drawings we made in class you must implement the following States (and any others you feel necessary):
* Shared States:
    * Die 
    * Respawn/Resurrect
* Shared yet different:
    * Return to base
* Unique state
    * Chase Player
    * Run-away

As you can see from above the Chase Player and Run-away state must be different for each Ghost implemented (each must go after Pac-Man in a different manner and each should run away differently).

Your game must be data driven. There shouldn't be any hardcoded values in your code. If it is a variable that can be and should be modified by a designer it should be visible in the Inspector.

I have provided you with a project that lets the Pac-Man move through the world using the Arrow keys. There is also a pathfinding A* algorithm implemented for you that the Ghosts already use. You must interface with this to move your Ghost.

There are a few classes with a System.Action event that you will need to understand (if you are not familiar with the System.Action I suggest looking it up and understanding how the callback system works).

## Classes with Callbacks
* GameDirector Class 
    * public GameStateChangedEvent GameStateChanged
        * An Action that can notify you when a game state changes
        * These events can be triggered when Pac-Man picks up a power pellet or when the timer runs out and he is not invincible.
        * An event will also happen when it is game over
* GhostController Class
    * public Action pathCompletedEvent
        * Notified when the Ghost finishes the path and is at the destination
    * public Action moveCompletedEvent
        * Notified when the Ghost finishes moving to the next point in the path
    * public Action killedEvent
        * Notified when a ghost is killed by Pac-Man

## IMPORTANT: 
* The ghost animation, movement, and looks are controlled by the GhostController. 
* There should be no need to change the following classes: Pac-Man, Pellet, PowerPellet.
* You can modify the GhostController class to cache data only.
 
Here is a link to some reading about the Ghosts in Pac-Man: https://pacman.holenet.info/
You can also find the PDF on SLATE
