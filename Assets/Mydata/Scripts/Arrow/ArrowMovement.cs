using UnityEngine;

public class ArrowMovement : MyMonoBehavior
{
    [SerializeField] protected float moveSpeed = 10.0f;

    protected Camera m_Camera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCameraZoom();
    }

    protected virtual void LoadCameraZoom()
    {
        if (m_Camera != null) return;
        m_Camera = GameObject.FindGameObjectWithTag("CameraZoom").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        OnArrowMove();
    }

    protected virtual void OnArrowMove()
    {
        transform.Translate(m_Camera.transform.forward * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
}
