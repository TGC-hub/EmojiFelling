using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : BaseMovement, IStart
{
    bool startGame = false;
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
    protected override void Start()
    {
        base.Start();
        ObserverStart.Instance.AddObserver(this);
    }
    public void OnStartting()
    {
        startGame = true;
    }

    protected override void FixedUpdate()
    {
        if (startGame == false) return;
        base.FixedUpdate();
        float distanceToStart = Vector3.Distance(transform.position, posStartGame.position);
        if (distanceToStart < 0.1 && startGame == true) 
        {
            startGame = false;
            SceneManager.LoadScene(1);
        }
    }

}
