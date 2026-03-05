using System;
using UnityEngine;

public class GhostObject : MonoBehaviour
{
    public Vector2 ScatterPos { get; set; }
    public Vector2 ResetPos { get; set; }
    public Vector2 Prediction { get; set; }
    public PacmanController Pacman { get; set; }

    private float nextActionTime = 0.0f;
    private float gapTime = 1.0f;

    public void Init(GameObject _owner, Vector2 _pos)
    {
        Pacman = _owner.GetComponent<GhostController>().PacMan.gameObject.GetComponent<PacmanController>();
        ScatterPos = _pos;
        ResetPos = new Vector2(0, 0);
    }

    public void TimerUpdate(Action _func)
    {
        // Wait for 1s before setting the next destination
        if (nextActionTime < gapTime)
        {
            nextActionTime += Time.deltaTime;
        }
        else
        {
            nextActionTime = 0;
            _func();
        }
    }
}
