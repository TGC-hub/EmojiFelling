using UnityEngine;

public class IconCtrl : MyMonoBehavior
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

    public virtual void SpawnIconEmoji(float typeEmoji)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.localRotation;
        
        switch (typeEmoji)
        {
            case 0:
                SpawnIcon("HappyIcon", pos, rot);
                break;
            case 1:
                SpawnIcon("AngryIcon", pos, rot);
                break;
            case 2:
                SpawnIcon("CryIcon", pos, rot);
                break;
            case 3:
                SpawnIcon("VomitingIcon", pos, rot);
                break;
            case 4:
                SpawnIcon("ClownIcon", pos, rot);
                break;
            default:
                DespawnIconEmoji();
                break;
            
        }
    }

    protected virtual void SpawnIcon(string nameTransform, Vector3 posSpawn, Quaternion rotSpawn)
    {
        DespawnIconEmoji();
        obj = IconSpawner.Instance.Spawn(nameTransform, posSpawn, rotSpawn);
        obj.gameObject.SetActive(true);
        obj.SetParent(transform);
    }
    public virtual void DespawnIconEmoji()
    {
        if (obj == null) return;
        IconSpawner.Instance.Despawn(this.obj);
    }
}
