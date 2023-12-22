using UnityEngine;

public class ArrowFollowing : FollowTarget
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (target != null) return;
        target = GameObject.FindGameObjectWithTag("CameraZoom").GetComponent<Transform>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        smoothSpeed = 1.0f;
    }
}
