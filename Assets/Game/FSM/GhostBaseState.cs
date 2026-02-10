using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GhostBaseState : StateMachineBehaviour
{
    protected GhostController ghost;
    protected PacmanController pacman;

    protected Vector2 scatterPos;
    protected Vector2 resetPos;
    protected Vector2 prediction;

    protected float nextActionTime = 0.0f;
    public float gapTime = 1.0f;

    public void Init(GameObject _owner, Vector2 _pos)
    {
        ghost = _owner.GetComponent<GhostController>();
        pacman = ghost.PacMan.gameObject.GetComponent<PacmanController>();
        scatterPos = _pos;
        resetPos = new Vector2(0, 0);
    }
}
