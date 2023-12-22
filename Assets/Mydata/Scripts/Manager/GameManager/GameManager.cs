using UnityEngine;

public class GameManager : MyMonoBehavior
{
    protected override void Start()
    {
        base.Start();
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        SetTimeScale();
    }

    protected virtual void SetTimeScale()
    {
        if(InputManager.Instance.EnableZoom)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
