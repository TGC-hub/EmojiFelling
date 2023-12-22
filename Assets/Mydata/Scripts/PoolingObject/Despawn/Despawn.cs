public abstract class Despawn : MyMonoBehavior
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) { return; }
        else
        {
            DespawnObject();
        }
    }
    public virtual void DespawnObject()
    {
    }

    protected abstract bool CanDespawn();
}
