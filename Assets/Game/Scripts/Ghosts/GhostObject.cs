using Unity.AppUI.MVVM;
using UnityEngine;

public class GhostObject : MonoBehaviour
{
    private Vector2 scatterPos;
    private Vector2 resetPos = new Vector2(0, 0);
    private Vector2 prediction;
    private PacmanController pacman;

    private float nextActionTime = 0.0f;
    private float gapTime = 1.0f;

    public void Init(GameObject _owner, Vector2 _pos)
    {
        pacman = _owner.GetComponent<GhostController>().PacMan.gameObject.GetComponent<PacmanController>();
        scatterPos = _pos;
        resetPos = new Vector2(0, 0);
    }
}
