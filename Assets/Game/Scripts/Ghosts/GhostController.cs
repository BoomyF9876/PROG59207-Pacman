using System;
using UnityEngine;
using System.Collections.Generic;
using AStarPathfinding;
using DG.Tweening;
using Unity.Behavior;

public enum GhostType
{
	Blinky,
	Clyde,
	Inky,
	Pinky
}

public class GhostController : MonoBehaviour
{
	public GhostType ghostType;
	public Vector2 ReturnLocation = new Vector2(0, 0);

	private Animator _animator;
	private float chaseSpeed;
	public Transform PacMan;
	public float speed;

	[SerializeField] private Vector2 moveToLocation; // Allows editing in the inspector but forces method call to set

	private bool generatePath = true;
	private bool nextPoint = true;
	public int pathIndex = 0;
	public List<Vector3> path = new List<Vector3>();

	private bool pathCompleted = false;
	private BehaviorGraphAgent agent;
	public GhostObject ghostObject;

    public System.Action pathCompletedEvent;
    public System.Action moveCompletedEvent;
    
	public System.Action killedEvent;
    public System.Action resurrectEvent;
    public System.Action escapeEvent;
    public System.Action powerWearOffEvent;

    void Start()
	{
        _animator = GetComponent<Animator>();
		agent = GetComponent<BehaviorGraphAgent>();
        ghostObject = GetComponent<GhostObject>();
		chaseSpeed = speed;

        GameDirector.Instance.GameStateChanged += GameStateChanged;

        ghostObject.Init(gameObject, moveToLocation);

        killedEvent += () => { agent.SetVariableValue<bool>("isDead", true); };
        resurrectEvent += () => { agent.SetVariableValue<bool>("isDead", false); };
        escapeEvent += () => { agent.SetVariableValue<bool>("isInvincible", true); };
        powerWearOffEvent += () => { agent.SetVariableValue<bool>("isInvincible", false); };
    }

    private void OnDestroy()
    {
		if (GameDirector.Instance != null && GameDirector.Instance.GameStateChanged != null)
		{
            GameDirector.Instance.GameStateChanged -= GameStateChanged;
		}
    }

    public void SetMoveToLocation(Vector2 location)
	{
		moveToLocation = location;
		generatePath = true;
		pathCompleted = false;
	}

	public void Update()
	{
		if (GameDirector.Instance.gameOver == true)
		{
			return;
		}

		// Leave this here. Because the Pathfinding is in a DLL it doesn't get setup right away.
		// Call SetMoveToLocation if you want to set a new position for the Ghost.
		// BUT
		// Be aware that if you do this every frame it could cause a slowdown and you shouldn't anyway
		// You also can't change where your going instantly. You must wait till you get to your current
		// seek point
		if (generatePath == true && nextPoint == true)
		{
			generatePath = false;
			pathIndex = 0;
			PathFinding.Instance.generatePath(transform.position, moveToLocation, path);
			pathIndex++; // Go to next point. The first is where you are
		}

		if (pathIndex < path.Count && nextPoint == true)
		{
			nextPoint = false;
			transform.DOMove(new Vector3(path[pathIndex].x, path[pathIndex].y, 0), speed).OnComplete(onMoveCompleted).SetEase(Ease.Linear);
			pathIndex++;
		}
		else if (pathIndex == path.Count && pathCompleted == false && nextPoint == true)
		{
			pathCompleted = true;
			if (pathCompletedEvent != null)
			{
                pathCompletedEvent.Invoke();
            }
        }
	}

	public void onMoveCompleted()
	{
		nextPoint = true;
		if (moveCompletedEvent != null)
		{
            moveCompletedEvent.Invoke();
        }
    }

	public void Kill()
	{
		_animator.SetBool("IsDead", true);
		if (killedEvent != null)
		{
            killedEvent.Invoke();
		}
	}

	public void Resurrect()
	{
        _animator.SetBool("IsDead", false);
        if (resurrectEvent != null)
        {
            resurrectEvent.Invoke();
        }
    }

	public void ResetSpeed()
	{
		speed = chaseSpeed;
	}

	public void GameStateChanged(GameDirector.States _state)
	{
		switch (_state)
		{
			case GameDirector.States.enState_Normal:
				_animator.SetBool("IsGhost", false);
                if (powerWearOffEvent != null)
                {
                    powerWearOffEvent.Invoke();
                }
                break;

			case GameDirector.States.enState_PacmanInvincible:
				_animator.SetBool("IsGhost", true);
                if (escapeEvent != null)
                {
                    escapeEvent.Invoke();
                }
                break;

			case GameDirector.States.enState_GameOver:
				break;
		}
	}
}
