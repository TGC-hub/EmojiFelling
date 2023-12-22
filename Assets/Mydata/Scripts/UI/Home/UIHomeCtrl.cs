using System.Collections;
using UnityEngine;

public class UIHomeCtrl : MyMonoBehavior, IStart
{
    [SerializeField] protected UIBottom bottomUI;
    [SerializeField] protected UICenter centerUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBottomUI();
        LoadCenterUI();
    }

    protected virtual void LoadBottomUI()
    {
        if (bottomUI != null) return;
        bottomUI = transform.GetComponentInChildren<UIBottom>();
    }

    protected virtual void LoadCenterUI()
    {
        if (centerUI != null) return;
        centerUI = transform.GetComponentInChildren<UICenter>();
    }

    protected override void Start()
    {
        ObserverStart.Instance.AddObserver(this);
    }

    public void OnStartting()
    {
        bottomUI.Hide();
        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(2.0f);
        centerUI.Appear();
    }
}
