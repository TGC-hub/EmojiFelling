public class ArrowDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        ArrowSpawner.Instance.Despawn(transform.parent);
    }

}
