using UnityEngine;

public class PlaneIntroMovement : PlaneMovement
{
    bool startGame = true;
    public bool StartGame => startGame;
    [SerializeField] protected Transform posStartGame;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPosStartGame();
    }

    protected virtual void LoadPosStartGame()
    {
        if (posStartGame != null) return;
        posStartGame = GameObject.FindGameObjectWithTag("PointStart").GetComponent<Transform>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        InputManager.Instance.lockInput = true;
        float distanceToStart = Vector3.Distance(transform.position, posStartGame.position);
        if (distanceToStart < 0.1 && startGame == true)
        {
            startGame = false;
            InputManager.Instance.lockInput = false;
        }
    }
}
