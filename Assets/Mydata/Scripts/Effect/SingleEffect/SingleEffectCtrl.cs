using UnityEngine;
public class SingleEffectCtrl : MyMonoBehavior
{
    [SerializeField] protected HumanController humanCtrl;
    [SerializeField] protected Transform obj;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (humanCtrl != null) return;
        humanCtrl = transform.parent.GetComponent<HumanController>();
    }

    public virtual void SpawnEffect(float typeEmoji)
    {
        Vector3 pos = transform.position;
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
        DespawnEffect();
        obj = SingleEffectSpawner.Instance.Spawn(nameTransform, posSpawn, rotSpawn);
        obj.gameObject.SetActive(true);
        obj.SetParent(transform);
    }
    public virtual void DespawnEffect()
    {
        if (obj == null) return;
        SingleEffectSpawner.Instance.Despawn(this.obj);
    }
}
