
using UnityEngine;

public class CanvasManager : MyMonoBehavior
{
    [SerializeField] protected UIAppear uiApear;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIApear();
    }
    protected virtual void LoadUIApear()
    {
        if (uiApear != null) return;
        uiApear = transform.GetComponentInChildren<UIAppear>();
    }

    protected override void Start()
    {
        base.Start();
        uiApear.Hide();
    }
    protected virtual void FixedUpdate()
    {
        if(PlaneCtrl.Instance.PlaneIntro.StartGame == false) 
        {
            Debug.Log("ok man");
            uiApear.Appear();
        }
    }
}
