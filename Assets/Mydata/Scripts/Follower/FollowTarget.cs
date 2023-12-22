using System.Collections;
using UnityEngine;

public class FollowTarget : MyMonoBehavior
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float smoothSpeed = 0.125f;
    [SerializeField] protected Vector3 offset;

    Vector3 desiredPositionss;
    Vector3 smoothedPosition;

    protected virtual void LateUpdate()
    {
        SetDesiredPositions();
        UpdatePos();
        LockPos();
    }

    protected virtual void SetDesiredPositions()
    {
        desiredPositionss = target.position + offset;
    }

    protected virtual void UpdatePos()
    {
        smoothedPosition = Vector3.Lerp(transform.position, desiredPositionss, smoothSpeed);
        transform.position = smoothedPosition;
    }

    protected virtual void LockPos() { }
}
