using UnityEngine;

public class LockRotationIcon : MyMonoBehavior
{
    protected Camera cameraToLookAt;

    void Update()
    {
        cameraToLookAt = CameraController.Instance.currentCamera;
        
        transform.LookAt(cameraToLookAt.transform);
    }
}
