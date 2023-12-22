
using UnityEngine;
using UnityEngine.UI;

public class ScopeController : MyMonoBehavior
{
    [SerializeField] protected Image imageScope;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadImageScope();
    }

    protected virtual void LoadImageScope()
    {
        if (imageScope != null) return;
        imageScope = transform.Find("ImageScope").GetComponent<Image>();
        imageScope.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();
        imageScope.gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        SetActiveImageScope();
    }

    protected virtual void SetActiveImageScope()
    {
        if(InputManager.Instance.EnableZoom == true)
        {
            imageScope.gameObject.SetActive(true);
        }
        else
        {
            imageScope.gameObject.SetActive(false);
        }
    }
}
