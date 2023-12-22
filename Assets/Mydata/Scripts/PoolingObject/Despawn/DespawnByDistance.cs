
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform cameraPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (cameraPos != null) return;
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(this.transform.position,cameraPos.position);
        if (distance > disLimit) { return true; }
        else
        {
            return false;
        }
    }
}
