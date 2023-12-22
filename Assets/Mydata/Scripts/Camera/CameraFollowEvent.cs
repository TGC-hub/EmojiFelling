using UnityEngine;

public class CameraFollowEvent : MyMonoBehavior
{
    [SerializeField] protected float followSpeed = 5.0f;
    protected Vector3 vector3 = Vector3.zero;
    [SerializeField] protected Vector3 offset;

    private bool followEvent = false;
    public bool FollowEvent => followEvent;

    [SerializeField] protected Transform cameraFollowEvent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCameraFollowEvent();
    }

    protected virtual void LoadCameraFollowEvent()
    {
        if (cameraFollowEvent != null) return;
        cameraFollowEvent = GameObject.FindGameObjectWithTag("CameraFollowEvent").GetComponent<Transform>();

    }

    protected virtual void Update()
    {
        GetPos();
    }

    protected virtual void GetPos()
    {
        if (ObserverAngry.Instance.TagetPos == vector3 
            && ObserverCry.Instance.TagetPos == vector3
            && ObserverHappy.Instance.TagetPos == vector3
            && ObserverClown.Instance.TagetPos == vector3
            && ObserverVomiting.Instance.TagetPos == vector3
            ) followEvent = false;
        else if (ObserverAngry.Instance.TagetPos != vector3)
        {
            OnActiveFollowEvent(ObserverAngry.Instance.TagetPos);
        }else if(ObserverCry.Instance.TagetPos != vector3)
        {
            OnActiveFollowEvent(ObserverCry.Instance.TagetPos);
        }else if(ObserverHappy.Instance.TagetPos != vector3)
        {
            OnActiveFollowEvent(ObserverHappy.Instance.TagetPos);
        }else if(ObserverVomiting.Instance.TagetPos != vector3)
        {
            OnActiveFollowEvent(ObserverVomiting.Instance.TagetPos);
        }else if(ObserverClown.Instance.TagetPos != vector3) 
        {
            OnActiveFollowEvent(ObserverClown.Instance.TagetPos);
        }
    }

    protected virtual void OnActiveFollowEvent(Vector3 vector3)
    {
        Vector3 pos = vector3 + offset;
        cameraFollowEvent.transform.position = pos;
        followEvent = true;
    }
}
