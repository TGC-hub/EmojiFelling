using UnityEngine;

public class DoubleEffectCtrl : MyMonoBehavior
{
    [SerializeField] protected Transform obj;
    private bool onSpawn = true;
    protected HumanController controller;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadController();
    }

    protected virtual void LoadController()
    {
        if (controller != null) return;
        controller = transform.parent.GetComponent<HumanController>();
    }

    public virtual void SpawnDoubleEffect(float typeEmoji, Vector3 posSpawn)
    {
        if (controller.HumanMoveToEvent.Distance > 1) return;
        if (posSpawn == Vector3.zero) return;
        Vector3 pos = posSpawn;
        Quaternion rot = transform.localRotation;
        switch (typeEmoji)
        {
            case 0:
                SpawnEffect("HappyEffect", pos, rot);
                break;
            case 1:
                SpawnEffect("AngryEffect", pos, rot);
                break;
            case 2:
                SpawnEffect("CryEffect", pos, rot);
                break;
            case 3:
                SpawnEffect("VomitingEffect", pos, rot);
                break;
            case 4:
                SpawnEffect("ClownEffect", pos, rot);
                break;
            default:
                DespawnEffect();
                break;

        }
    }

    protected virtual void SpawnEffect(string nameTransform, Vector3 posSpawn, Quaternion rotSpawn)
    {
        if (onSpawn == false) return;
        DespawnEffect();
        obj = DoubleEffectSpawner.Instance.Spawn(nameTransform, posSpawn, rotSpawn);
        obj.gameObject.SetActive(true);
        onSpawn = false;
    }
    public virtual void DespawnEffect()
    {
        if (obj == null) return;
        obj.position = Vector3.zero;
        DoubleEffectSpawner.Instance.Despawn(this.obj);
        onSpawn = true;
    }

}
