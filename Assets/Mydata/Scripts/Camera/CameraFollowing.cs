using UnityEngine;

public class CameraFollowing : FollowTarget
{

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (target != null) return;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        smoothSpeed = 1f;
    }

}
