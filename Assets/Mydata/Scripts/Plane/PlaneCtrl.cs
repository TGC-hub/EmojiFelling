
using UnityEngine;

public class PlaneCtrl : MyMonoBehavior
{
    private static PlaneCtrl instance;
    public static PlaneCtrl Instance => instance;

    [SerializeField] protected PlaneIntroMovement planeIntro;
    public PlaneIntroMovement PlaneIntro => planeIntro; 

    [SerializeField] protected PlaneMovement planeInPlayGame;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayIntro();
        LoadPlayInPlayGame();
    }

    protected virtual void LoadPlayIntro()
    {
        if (planeIntro != null) return;
        planeIntro = transform.GetComponentInChildren<PlaneIntroMovement>();
    }

    protected virtual void LoadPlayInPlayGame()
    {
        if (planeInPlayGame != null) return;
        planeInPlayGame = transform.GetComponentInChildren<PlaneMovement>();
    }


    protected virtual void FixedUpdate()
    {
        if(planeIntro.StartGame == false) 
        {
            planeInPlayGame.transform.parent.gameObject.SetActive(true);
            planeIntro.transform.parent.gameObject.SetActive(false);
        }
    }

}
